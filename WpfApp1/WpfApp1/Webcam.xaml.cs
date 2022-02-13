using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using Microsoft.Expression.Encoder;
using Microsoft.Expression.Encoder.Live;
using Microsoft.Expression.Encoder.Profiles;
using Emgu.CV;

namespace WpfApp1;

public partial class Webcam : UserControl
{
    public Webcam()
    {
        InitializeComponent();
    }
    public void StartPreview()
    {
        bool isPreviewing = false;
        try
        {
            if (isPreviewing)
                StopPreview();

            LiveJob job = new LiveJob();
            VideoCapture videoCapture = new VideoCapture(V)
            long frameDuration = System.Convert.ToInt64(30 * Math.Pow(10, 7));
            Size FrameSize = new Size(640, 480);
            //Panel WebcamPanel = new DockPanel();

            LiveDeviceSource deviceSource = job.AddDeviceSource(_videoDevice, null);
            deviceSource.PickBestVideoFormat(FrameSize, frameDuration);
            deviceSource.PreviewWindow = new PreviewWindow(new HandleRef(WebcamPanel, WebcamPanel.Handle));

            job.OutputFormat.VideoProfile = new AdvancedVC1VideoProfile() { Size = FrameSize, FrameRate = 30, Bitrate = new ConstantBitrate(Bitrate) };

            job.ActivateSource(deviceSource);

            isPreviewing = true;
        }
        catch (SystemErrorException ex)
        {
            throw new SystemErrorException();
        }
    }
    

}