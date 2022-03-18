using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
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


        private void RegisterNewUserBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
            Process process = new Process();
            process.StartInfo.FileName = "zbarcam.exe";
            process.Start();
            */
            // Page generateQRCodePage = new GenerateQrCode();
            // this.Content = generateQRCodePage;
            // NavigationWindow redirectNewUser = new NavigationWindow();
            // redirectNewUser.Source = new Uri("Register.xaml", UriKind.Relative);
            Page registerNewUser = new Register();
            this.Content = registerNewUser; 
        }
    }
}
