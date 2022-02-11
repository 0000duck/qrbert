using System;
using System.Windows;
using System.Windows.Threading;

namespace QRbert
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // private Window WelcomeScreen = new WelcomeScreen();
        // private Window SignIn_QRCode = new SignIn_QRCode();
        private Window CaptureTheWebcam1 = new CaptureTheWebcam();
        public MainWindow()
        {
            CaptureTheWebcam1.Show();
            this.Hide();
            // WelcomeScreen.Show();
            // SignIn_QRCode.Show();
            StartCloseTimer();
            this.Activate();
            // InitializeComponent();
        }

        private void ActivateCameraButton_Click(object sender, EventArgs e)
        {
            CaptureTheWebcam1.Show();
        } 
        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5d);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer) sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            // WelcomeScreen.Close();
        }
        
    }
}