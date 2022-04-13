using System.Configuration;
using System.Windows;

namespace QRbert;

public partial class StaffMyAccount
{
    public StaffMyAccount()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// Redirects Staff to the ChangeEmail page via a button click
    /// Since this and the ChangeEmail are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffChangeEmailBtn_Click(object sender, RoutedEventArgs e)
    {
        // Window redirectStaffToChangeEmail = new StaffChangeEmail();
        // this.Content = redirectStaffToChangeEmail;
        Switcher.StaffPageSwitch(new StaffChangeEmail());
        this.Close();
    }

    /// <summary>
    /// Redirects staff to change their password page via a button click
    /// Since this page and the ChangePassword are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffChangePasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffChangePassword());
        this.Close();
    }

    /// <summary>
    /// I don't know what the difference is and I put a messagebox to reflect my confusion
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffForgotPasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffForgotPassword());
        this.Close();
    }

    /// <summary>
    /// Redirects staff to the ChangePersonalInfo page via a button click
    /// Since the current page and the ChangePersonalInfo page are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffChangePersonalInfoBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffChangePersonalInfo());
        this.Close();
    }
    
    /// <summary>
    /// Logs out staff user and takes them to the Log In Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogOutSwitch();
        this.Close();
    }
    
    /// <summary>
    /// Redirects user to home page - staff portal via QRbert image click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeStaffPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectStaffPortal();
        this.Close();
    }
}