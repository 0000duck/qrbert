using System.Windows;

using Microsoft.Expression.Encoder.Devices;
using System.Collections.ObjectModel;

namespace QRbert;

public partial class MainWindow2 : Window
{
    public Collection<EncoderDevice> VideoDevices { get; set; }
    public Collection<EncoderDevice> AudioDevices { get; set; }
    public MainWindow2()
    {
        InitializeComponent();
        this.DataContext = this;

        VideoDevices = EncoderDevices.FindDevices(EncoderDeviceType.Video);
        AudioDevices = EncoderDevices.FindDevices(EncoderDeviceType.Audio);
    }
    private void StartCaptureButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // Display webcam video
            WebcamViewer.StartPreview();
        }
        catch (Microsoft.Expression.Encoder.SystemErrorException ex)
        {
            MessageBox.Show("Device is in use by another application");
        }
    }

    private void StopCaptureButton_Click(object sender, RoutedEventArgs e)
    {
        // Stop the display of webcam video.
        WebcamViewer.StopPreview();
    }

    private void StartRecordingButton_Click(object sender, RoutedEventArgs e)
    {
        // Start recording of webcam video to harddisk.
        WebcamViewer.StartRecording();
    }

    private void StopRecordingButton_Click(object sender, RoutedEventArgs e)
    {
        // Stop recording of webcam video to harddisk.
        WebcamViewer.StopRecording();
    }

    private void TakeSnapshotButton_Click(object sender, RoutedEventArgs e)
    {
        // Take snapshot of webcam video.
        WebcamViewer.TakeSnapshot();
    }
}