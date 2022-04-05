using System;

using OpenCvSharp;
using OpenCVDemo;


namespace QRbert
{
    class QRCodeScanner
    {
        private string result;
        public string DecodeQRCode()
        { 
            IBarcodeReaderImage reader = new BarcodeReaderImage();
             var capture = new VideoCapture(0);
             var window = new Window("Scan QR Code");
            while (true)
            {
                using var image = new Mat();
                capture.Read(image);
                if (image.Empty())
                    break; 
                window.ShowImage(image);
                if (image != null && image.Height > 0)
                {
                    // decode it
                    result = reader.Decode(image).Text;
                    if (result != null)
                    {
                        return result;
                    }
                }
                if (Cv2.WaitKey(1) == 113)
                    break;
            }

            return null;
        }
    }
}