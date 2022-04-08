using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class VolunteerMyAccount : Window
{
    public VolunteerMyAccount()
    {
        InitializeComponent();
        Switcher.VolunteerMyAccountSwitcher = this;
    }
    
    /// <summary>
    /// Public function that allows to navigate to the next desired page
    /// </summary>
    /// <param name="nextWindow">
    /// Type Page, represents the next page to redirect to
    /// </param>
    public void Navigate(Window nextWindow)
    {
        nextWindow.Show();
        this.Close();
    }
    
    /// <summary>
    /// Redirects volunteer to VolunteerChangeEmail page so that they may change their email
    /// Since the MyAccount and the ChangeEmail contents are pages, we should be able to change the content easily
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerChangeEmailBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerMyAcctSwitch(new VolunteerChangeEmail());
        this.Close();
    }

    /// <summary>
    /// Redirects volunteer to change their password via the button click
    /// Since this content and the ChangePassword forms are both pages, we should be able to navigate to them easily
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerChangePasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        // Missing Change Password page, waiting on Marisol
    }

    /// <summary>
    /// I don't know what the difference is and left a messagebox to reflect that...
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerForgotPasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Um, what's the difference between the one above and this one?");
    }

    /// <summary>
    /// Redirects volunteer to change their personal info on the ChangePersonalInfo page via a button click
    /// Since the current content and the ChangePersonalInfo forms are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerChangePersonalInfoBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerMyAcctSwitch(new VolunteerChangePersonalInformation());
    }

    /// <summary>
    /// Logs out Volunteer and redirects user to the Log In page via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogOutSwitch();
        this.Close();
    }

    /// <summary>
    /// Redirects user to home page - volunteer portal via QRbert image click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeVolunteerPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectVolunteerPortal();
        this.Close();
    }
}