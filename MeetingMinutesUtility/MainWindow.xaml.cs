using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MeetingMinutesUtility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string meetingName { get; set; }

        public static string meetingHost { get; set; }

        public static string hrsDuration { get; set; }

        public static string minsDuration { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            _meetingNameTextBox.Text = "sample";
            _meetingHostTextBox.Text = "myself";
            _hrsDurationTextBox.Text = "1";
            _minsDurationTextBox.Text = "30";

        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void MeetingNameTextChanged(object sender, TextChangedEventArgs e)
        {
            meetingName = _meetingNameTextBox.Text;
        }

        private void MeetingHostTextChanged(object sender, TextChangedEventArgs e)
        {
            meetingHost = _meetingHostTextBox.Text;
        }

        private void HrsDurationTextChanged(object sender, TextChangedEventArgs e)
        {
            hrsDuration = _hrsDurationTextBox.Text;
        }

        private void MinutesDurationTextChanged(object sender, TextChangedEventArgs e)
        {
            minsDuration = _minsDurationTextBox.Text;
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        private void BeginMeeting(object sender, RoutedEventArgs e)
        {
            if (_meetingNameTextBox.Text == string.Empty || _meetingHostTextBox.Text == string.Empty || _hrsDurationTextBox.Text == string.Empty || _minsDurationTextBox.Text == string.Empty)
            {
                MessageBox.Show("Fill all the fields","Error");
            }
            else {
                Hide();
                Meeting obj = new Meeting();
                obj.Show();
            }
        }
    }
}
