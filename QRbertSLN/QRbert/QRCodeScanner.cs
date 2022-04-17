using System;
using System.Windows;
using System.Windows.Media;
using OpenCVDemo;
using OpenCvSharp;
using Window = OpenCvSharp.Window;
using QRCoder;
using QRCoder.Xaml;


namespace QRbert
{
    /// <summary>
    /// Class that retains webcam feed and decoded QR code
    /// Allows a webcam to be obtained as well QR codes to be decoded in string form
    /// </summary>
    public class QRCodeScanner
    {
        // Static string result saves final decoded QR code string
        public static string result = "";
        /// <summary>
        /// Function that decodes QR code from a webcam feed
        /// </summary>
        public static void DecodeQRCode()
        {
            /* IBarcodeReaderImage is an interface for a barcode reader class which can be used with the Mat type
                from OpenCVSharp. This polymorphic association to a a barcode reader class which can be used with the 
                Mat type from OpenCVSharp calls the constructor which uses a custom luminance source with Mat support
            */
            IBarcodeReaderImage reader = new BarcodeReaderImage();
            // Creates a new object from the VideoCapture class
            // Param 0 refers to the default video capturing device on the local machine
            using var capture = new VideoCapture(0);
            // Creates a new OpenCVSharp type Window which allows for other features as described below
            using var window = new Window("Scan QR Code");
            
            // While loop that doesn't break until a QR code is decoded
            while (true)
            {
                // Creates an object of type Mat
                using var image = new Mat();
                // Grabs, decodes and returns the next video frame
                // Read of type boolean which returns true if image is not null, false otherwise
                // This can lead to exceptions, however, for now, it is fine 
                capture.Read(image);
                // ElBruno kept this code and it hasn't given me errors so far
                if (image.Empty())
                    break; 
                // Sets the image as the image to display in the window created
                window.ShowImage(image);
                // If the image contains info
                if (image != null && image.Height > 0)
                {
                    // Decodes image using ZXing Decode function and saves it as type Result
                    var result = reader.Decode(image);
                    if (result != null)
                    {
                        // Saves the text into the static result class variable for global use and exits function
                        QRCodeScanner.result = result.Text;
                        break;
                    }
                }
                // Manually closes the window
                if (Cv2.WaitKey(1) == 113)
                    window.Close();
            }
        }
        
        public static DrawingImage Generate_QR_Click(string info)
        {
            QRCodeGenerator gen = new QRCodeGenerator();
            /*
             * Currently using user's full name, date of birth, and random integer as encoded data
             * Use of random integer reduces chance of collision, reduces chance of someone guessing the encoded data,
             * and allows for a user to easily reset their QR code with a new one.
             */
            QRCodeData data = gen.CreateQrCode(info, QRCodeGenerator.ECCLevel.Q);
            XamlQRCode qrCode = new XamlQRCode(data);
            DrawingImage qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}