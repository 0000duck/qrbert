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
/// <summary>
/// Function that creates a new LogInWindow window
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    private void GetStartedBtn_Click(object sender, RoutedEventArgs e)
    {
        Window LogInWindow = new LogIn_Register();
        LogInWindow.Show();
        this.Close();
    }
}