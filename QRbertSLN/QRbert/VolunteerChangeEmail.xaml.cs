using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class VolunteerChangeEmail : Window
{
    public VolunteerChangeEmail()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// Redirects volunteer user to their MyAccountPage via a button click on the menu item
    /// Since the portal and the MyAccount page are both Pages, we should be able to save the previous pages visited
    /// and go back to them if needed
    ///
    /// Scratch the above, this comment was for the commented out code in the function that creates a page and
    /// makes the content change to that page
    /// Currently, we can switch to the page given the code that functions below and written in the Switcher class
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerMyAcctBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerMyAccount());
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