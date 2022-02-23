using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using QRbert;

namespace qrbertApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void StartCamera(object sender, RoutedEventArgs e)
        {
            /*Process process = new Process();
            process.StartInfo.FileName = "";
            process.Start();*/
            Page generateQRCodePage = new GenerateQrCode();
            this.Content = generateQRCodePage;
        }
    }
}