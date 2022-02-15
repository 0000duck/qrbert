using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using QRCoder;
using QRCoder.Xaml;

namespace QRbert;

public partial class GenerateQrCode : Page
{
    public GenerateQrCode()
    {
        InitializeComponent();
    }

    private void Generate_QR_Click(object sender, EventArgs e)
    {
        QRCodeGenerator gen = new QRCodeGenerator();
        Random rand = new Random();
        /*
         * Currently using user's full name, date of birth, and random integer as encoded data
         * Use of random integer reduces chance of collision, reduces chance of someone guessing the encoded data,
         * and allows for a user to easily reset their QR code with a new one.
         */
        String userInfo = NameInput.Text + DoBInput.Text + rand.Next(0, 10000);
        QRCodeData data = gen.CreateQrCode(userInfo, QRCodeGenerator.ECCLevel.Q);
        XamlQRCode qrCode = new XamlQRCode(data);
        DrawingImage qrCodeImage = qrCode.GetGraphic(20);
        QRcodeViewer.Source = qrCodeImage;
        QRcodeViewer.Visibility = Visibility.Visible;
    }
    
}