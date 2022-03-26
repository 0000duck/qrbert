using System;
using System.Security.Cryptography;
using System.Text;
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
        var salt = "";
        byte[] bytes = new byte[128 / 8];
        using (var keyGenerator = RandomNumberGenerator.Create()) {
            keyGenerator.GetBytes(bytes);
            salt = BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        String userInfo = NameInput.Text + DoBInput.Text + salt;

        using(var sha256 = SHA256.Create()) {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(userInfo));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            MessageBox.Show(hash);
        }

        QRCodeGenerator gen = new QRCodeGenerator();
        QRCodeData data = gen.CreateQrCode(userInfo, QRCodeGenerator.ECCLevel.Q);
        XamlQRCode qrCode = new XamlQRCode(data);
        DrawingImage qrCodeImage = qrCode.GetGraphic(20);
        QRcodeViewer.Source = qrCodeImage;
        QRcodeViewer.Visibility = Visibility.Visible;
    }

}
