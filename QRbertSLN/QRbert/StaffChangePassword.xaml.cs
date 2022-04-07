using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class StaffChangePassword : Window
{
    public StaffChangePassword()
    {
        InitializeComponent();
        Switcher.StaffChangePasswordSwitcher = this;
    }
    
    /// <summary>
    /// Public function that allows to navigate to the next desired window
    /// </summary>
    /// <param name="nextWindow">
    /// Type window, represents the next window to redirect to
    /// </param>
    public void Navigate(Window nextWindow)
    {
        nextWindow.Show();
        this.Close();
    }

    /// <summary>
    /// Redirects staff to their MyAccount window via button click
    /// Since the portal and the MyAccount are both windows, they are easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffAccountBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffChangeEmailSwitch(new StaffMyAccount());
    }

    /// <summary>
    /// Logs out staff and redirects user to the Log In window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogOutSwitch();
    }
}