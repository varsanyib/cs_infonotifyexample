using Notifications.Wpf;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfoNotifyExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer player;
        NotificationManager notify;
        public MainWindow()
        {
            InitializeComponent();
            player = new MediaPlayer();
            notify = new NotificationManager();
        }
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            notify.Show(new NotificationContent
            {
                Title = "Information",
                Message = "This message sent by application.",
                Type = NotificationType.Information,
            }, (cbWindow.IsChecked == true ? "AlertArea" : ""), onClick: PressedMessage, onClose: ClosedMessage, expirationTime: TimeSpan.FromSeconds(10)); //If you added expiration time, then messages close automatically
            if (cbSound.IsChecked == true)
            {
                player.Open(new Uri(@"Sounds/Information.mp3", UriKind.Relative));
                player.Play();
            }
        }

        private void btnWarning_Click(object sender, RoutedEventArgs e)
        {
            
            notify.Show(new NotificationContent
            {
                Title = "Warning",
                Message = "This message sent by application.",
                Type = NotificationType.Warning,
            }, (cbWindow.IsChecked == true ? "AlertArea" : ""));
            if (cbSound.IsChecked == true)
            {
                player.Open(new Uri(@"Sounds/Warning.mp3", UriKind.Relative));
                player.Play();
            }
        }

        private void btnDanger_Click(object sender, RoutedEventArgs e)
        {
            notify.Show(new NotificationContent
            {
                Title = "Error",
                Message = "This message sent by application.",
                Type = NotificationType.Error,
            }, (cbWindow.IsChecked == true ? "AlertArea" : ""));
            if (cbSound.IsChecked == true)
            {
                player.Open(new Uri(@"Sounds/Danger3.mp3", UriKind.Relative));
                player.Play();
            }
        }

        private void PressedMessage()
        {
            MessageBox.Show("Message Pressed!", "Notify");
        }
        private void ClosedMessage()
        {
            MessageBox.Show("Message Closed!", "Notify");
        }
    }
}