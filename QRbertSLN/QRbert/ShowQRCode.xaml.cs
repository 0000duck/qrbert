using System.ComponentModel;
using System.Windows;
using System;
using System.ComponentModel;

namespace QRbert;

public partial class ShowQRCode : Window
{
    public ShowQRCode()
    {
        InitializeComponent();
    }
        
    void ShowQRCode_Closing(object sender, CancelEventArgs e)
    {
        MessageBoxResult response = MessageBox.Show("Have you saved your QR code?", 
            "Your QR Code", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (response == MessageBoxResult.No)
        {
            e.Cancel = true;
        }
    }
}