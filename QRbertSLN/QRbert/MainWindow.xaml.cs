using System;

using System.Diagnostics;
using System.IO;

using System.Windows;
using System.Windows.Threading;

namespace QRbert
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
            //Process process = new Process();
            //String pathfile = Path.GetFullPath("zbarcam");
            //Console.WriteLine(pathfile);
            //process.StartInfo.FileName = pathfile;
            //process.Start();
            
            
            //System.Diagnostics.Process.Start("zbarcam.exe");
            //Page generateQRCodePage = new GenerateQrCode();
            //this.Content = generateQRCodePage;
        }

    }
}