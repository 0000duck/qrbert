using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class GetStarted : Window
{
    public GetStarted()
    {
        // Added below line that maximizes the window at runtime
        // this.WindowState = WindowState.Maximized;
        InitializeComponent();
    }

    private void GetStartedBtn_Click(object sender, RoutedEventArgs e)
    {
        Window LogInWindow = new MainWindow();
        this.Close();
        LogInWindow.Show();
    }
}