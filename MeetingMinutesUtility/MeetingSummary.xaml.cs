using NAudio.Wave;
using System.IO;
using System.Windows;
using System.Windows.Input;

using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Grpc.Auth;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.ProjectOxford.Text.Sentiment;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.KeyPhrase;

namespace MeetingMinutesUtility
{
    /// <summary>
    /// Interaction logic for MeetingSummary.xaml
    /// </summary>
    public partial class MeetingSummary : Window
    {
        public WaveOut waveOut;
        public WaveFileReader reader;

        public float sentimentPercentage = 0;

        public object ConfigurationManager { get; private set; }

        public MeetingSummary()
        {
            InitializeComponent();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void PlayAudio_Click(object sender, RoutedEventArgs e)
        {
            _textConversion.IsEnabled = false;

            waveOut = new WaveOut();
            if (File.Exists(Meeting.output))
            {
                reader = new WaveFileReader(Meeting.output);
                waveOut.Init(reader);
                waveOut.Play();
            }
            else
            {
                textBox.Text += "No Audio File Found";
            }

            _textConversion.IsEnabled = true;
        }

        private void GenerateText_Click(object sender, RoutedEventArgs e)
        {
            _playAudio.IsEnabled = false;
            _textConversion.IsEnabled = false;
            WriteLine("Converted Text:\n");
            string recognizedText = GenerateText();
            WriteLine(recognizedText);           
            
            WriteLine("\n\nKey Phrases:\n", KeyPhraseAnalysis(recognizedText));

            var task = SentimentPercentage(recognizedText);

            _playAudio.IsEnabled = true;
            _textConversion.IsEnabled = true;
        }


        private void WriteLine()
        {
            WriteLine(string.Empty);
        }


        private void WriteLine(string format, params object[] args)
        {
            var formattedStr = string.Format(format, args);
            Trace.WriteLine(formattedStr);
            Dispatcher.Invoke(() =>
            {
                textBox.Text += (formattedStr + " ");
                textBox.ScrollToEnd();

            });
        }

        private void WriteNewLine(string format, params object[] args)
        {
            var formattedStr = string.Format(format, args);
            Trace.WriteLine(formattedStr);
            Dispatcher.Invoke(() =>
            {
                textBox.Text += (formattedStr + "\n");
                textBox.ScrollToEnd();

            });
        }


        public string GenerateText()
        {
            //List<string> textList = new List<string>();

            if (File.Exists(Meeting.output))
            {

                GoogleCredential googleCredential;
                using (Stream m = new FileStream(System.Configuration.ConfigurationManager.AppSettings["SpeechToTextKey-JSON-FilePath"], FileMode.Open))
                    googleCredential = GoogleCredential.FromStream(m);
                var channel = new Grpc.Core.Channel(SpeechClient.DefaultEndpoint.Host,
                    googleCredential.ToChannelCredentials());


                var speech = SpeechClient.Create(channel);
                var response = speech.Recognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    SampleRateHertz = 16000,
                    LanguageCode = "en-In",
                }, RecognitionAudio.FromFile(Meeting.output));

                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        //WriteLine(alternative.Transcript);
                        return alternative.Transcript;
                    }
                }

                // if (textBox.Text.Length == 0)
                //   return "No Data";
                return null;
            }
            else
            {


                return "Audio File Missing";
            }
        }


        public async Task SentimentPercentage(string input)
        {
            var document = new SentimentDocument()
            {
                Id = "1",
                Text = input,
                Language = "en"
            };

            var request = new SentimentRequest();
            request.Documents.Add(document);

            var client = new SentimentClient(System.Configuration.ConfigurationManager.AppSettings["apikey"]);

            var response = await client.GetSentimentAsync(request);

            float sum = 0, average = 0;

            foreach (var doc in response.Documents)
            {
                sum += (doc.Score * 100);

            }
            average = sum / response.Documents.Count;

            WriteNewLine("\n\nSentiment analysis value is {0}",average.ToString());

        }

        public async Task KeyPhraseAnalysis(string input)
        {
            var document = new KeyPhraseDocument()
            {
                Id = "1",
                Text = input,
                Language = "en"
            };

            var request = new KeyPhraseRequest();
            request.Documents.Add(document);

            var client = new KeyPhraseClient(System.Configuration.ConfigurationManager.AppSettings["apikey"]);

            var response = await client.GetKeyPhrasesAsync(request);

            foreach (var doc in response.Documents)
            {

                foreach (var keyPhrase in doc.KeyPhrases)
                {
                    WriteNewLine("{0}", keyPhrase);
                }
            }

        }
    


    private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                Application.Current.Shutdown();
            });
        }

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
