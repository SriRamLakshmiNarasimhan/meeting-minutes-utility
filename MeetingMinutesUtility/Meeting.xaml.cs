using System;
using System.Windows;
using System.Windows.Input;
using NAudio.Wave;
using System.IO;
using System.Threading;

namespace MeetingMinutesUtility
{
    /// <summary>
    /// Interaction logic for Meeting.xaml
    /// </summary>
    public partial class Meeting : Window
    {
        
        public WaveIn waveSource = null;
        public WaveFileWriter waveFile = null;

        public static string output;
        public int totalHours = Convert.ToInt32(MainWindow.hrsDuration);
        public int totalMinutes = Convert.ToInt32(MainWindow.minsDuration);

        private Timer _timer;
        private int _secondDuration;

        public Meeting()
        {
            InitializeComponent();
            _meetingNameLabel_Value.Content = MainWindow.meetingName;
            _meetingHostLabel_Value.Content = MainWindow.meetingHost;
            _durationLabel_Value.Content = MainWindow.hrsDuration + " hr : " + MainWindow.minsDuration + " mins";
            setFilePath();
            _timer = new Timer(OnDispatcherTimer_Tick, null, 0, 1000);
            recordVoice();
        }

        private void setFilePath()
        {
            string outputFolder = Path.Combine(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "AudioFiles");
            Directory.CreateDirectory(outputFolder);
            output = outputFolder + "\\audio.raw";
        }


        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }


        private void OnDispatcherTimer_Tick(object sender)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                _secondDuration += 1;
                int currentValue = ((totalHours * 3600) + (totalMinutes * 60)) - _secondDuration;
                TimeSpan timespan = TimeSpan.FromSeconds(currentValue);
                int hour = timespan.Hours;
                int min = timespan.Minutes;
                int sec = timespan.Seconds;
                _durationLabel_Value.Content = hour + " : " + min + " : " + sec;
            }
                    ));
        }


        private void EndMeeting(object sender, RoutedEventArgs e)
        {
            stopRecording();
            _timer.Dispose();
            Hide();
            MeetingSummary obj = new MeetingSummary();
            obj.Show();
        }

        private void recordVoice()
        {
            Dispatcher.Invoke((Action)(() =>
            {
                if (WaveIn.DeviceCount < 1)
                {
                    Console.WriteLine("No microphone!");
                    return;
                }
                waveSource = new WaveIn();
                waveSource.WaveFormat = new WaveFormat(16000, 1);

                waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
                waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);


                if (File.Exists(output))
                {
                    File.Delete(output);
                }

                waveFile = new WaveFileWriter(output, waveSource.WaveFormat);

                waveSource.StartRecording();

            }
                    ));
        }

        void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }

        }

        private void stopRecording()
        {
            waveSource.StopRecording();
            waveSource.Dispose();
            //waveSource = null;
        }


    }
}
