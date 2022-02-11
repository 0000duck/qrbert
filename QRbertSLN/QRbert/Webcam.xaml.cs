using System;
using System.Drawing;
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
    
    /*
    public void StartPreview()
    {
        
        bool isPreviewing = true;
        try
        {
            if (isPreviewing)
                StopPreview();

            LiveJob job = new LiveJob();
            long frameDuration = System.Convert.ToInt64(30 * Math.Pow(10, 7));

            LiveDeviceSource deviceSource = job.AddDeviceSource();
            Size FrameSize = new Size(640, 480);
            deviceSource.PickBestVideoFormat(FrameSize, frameDuration);
            deviceSource.PreviewWindow = new PreviewWindow(new HandleRef(WebcamPanel, WebcamPanel.Handle));

            job.OutputFormat.VideoProfile = new AdvancedVC1VideoProfile() {Size = FrameSize, FrameRate = 30, Bitrate = new ConstantBitrate(Bitrate) };

            job.ActivateSource(deviceSource);

            isPreviewing = true;
        }
        catch (SystemErrorException ex)
        {
            throw new SystemErrorException();
        }
    }
    */
/*
    public void StopPreview()
    {
        
    }
    
*/
}