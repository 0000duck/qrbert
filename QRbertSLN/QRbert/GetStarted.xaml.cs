using System.Windows;

namespace QRbert;

public partial class GetStarted
{
    public GetStarted()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// Function that creates a new Register window
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GetStartedBtn_Click(object sender, RoutedEventArgs e)
    {
        Window register = new Register();
        register.Show();
        this.Close();
    }

    /// <summary>
    /// Function that creates a new LogInWindow window
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SignInBtn_Click(object sender, RoutedEventArgs e)
    {
        Window logIn = new LogIn_Register();
        logIn.Show();
        this.Close();
    }
}