using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;


namespace QRbert;

public partial class WelcomeScreen : Window
{
    public WelcomeScreen()
    {
        InitializeComponent();
        StartCloseTimer();
        Window GetStarted = new GetStarted();
        this.Close();
        GetStarted.Show();
    }
    
    private void StartCloseTimer()
    {
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(10d);
        timer.Tick += TimerTick;
        timer.Start();
    }

    private void TimerTick(object sender, EventArgs e)
    {
        DispatcherTimer timer = (DispatcherTimer) sender;
        timer.Stop();
        timer.Tick -= TimerTick;
    }
    /*
    private void WelcomeScreenButton_Click(object sender, EventArgs e)
    {
        Window MainWindow = new MainWindow();
        this.Content = MainWindow;
    }
    */
}