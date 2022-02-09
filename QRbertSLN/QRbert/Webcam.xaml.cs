using System;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using Microsoft.Expression.Encoder;
using Microsoft.Expression.Encoder.Live;
using Microsoft.Expression.Encoder.Profiles;

namespace QRbert;

public partial class Webcam : UserControl
{
    public Webcam()
    {
        InitializeComponent();
    }
    public void StartPreview()
    {
        try
        {
            if (isPreviewing)
                StopPreview();

            LiveJob job = new LiveJob();
            long frameDuration = System.Convert.ToInt64(30 * Math.Pow(10, 7));

            deviceSource = job.AddDeviceSource(_videoDevice, null);
            deviceSource.PickBestVideoFormat(FrameSize, frameDuration);
            deviceSource.PreviewWindow = new PreviewWindow(new HandleRef(WebcamPanel, WebcamPanel.Handle));

            Job.OutputFormat.VideoProfile = new AdvancedVC1VideoProfile() { Size = FrameSize, FrameRate = FrameRate, Bitrate = new ConstantBitrate(Bitrate) };

            Job.ActivateSource(deviceSource);

            isPreviewing = true;
        }
        catch (SystemErrorException ex)
        {
            throw new SystemErrorException();
        }
    }
    

}