using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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
        

        private void StartCamera(object sender, RoutedEventArgs e)
        {
            /*Process process = new Process();
            process.StartInfo.FileName = "";
            process.Start();*/
            // Page generateQRCodePage = new GenerateQrCode();
            // this.Content = generateQRCodePage;
            Page registerPage = new Register();
            this.Content = registerPage;
        }
        /*private void StartCamera(object sender, RoutedEventArgs e)
        {
            //Process process = new Process();
            //String pathfile = Path.GetFullPath("zbarcam");
            //Console.WriteLine(pathfile);
            //process.StartInfo.FileName = pathfile;
            //process.Start();
            
            
            //System.Diagnostics.Process.Start("zbarcam.exe");
            //Page generateQRCodePage = new GenerateQrCode();
            //this.Content = generateQRCodePage;
        }*/
    }
}
