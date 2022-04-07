using System.Windows;

namespace QRbert;

public partial class StaffMyAccount
{
    public StaffMyAccount()
    {
        InitializeComponent();
        Switcher.staffMyAccountPageSwitcher = this;
    }
    
    /// <summary>
    /// Public function that allows to navigate to the next desired page
    /// </summary>
    /// <param name="nextPage">
    /// Type Page, represents the next page to redirect to
    /// </param>
    public void Navigate(Window nextWindow)
    {
        nextWindow.Show();
        this.Close();
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
        Switcher.StaffMyAccountSwitch(new StaffChangeEmail());
    }

    /// <summary>
    /// Redirects staff to change their password page via a button click
    /// Since this page and the ChangePassword are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffChangePasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        // Missing change password page, waiting on Marisol
    }

    /// <summary>
    /// I don't know what the difference is and I put a messagebox to reflect my confusion
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffForgotPasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("What is the difference between Change Password and this one?");
    }

    /// <summary>
    /// Redirects staff to the ChangePersonalInfo page via a button click
    /// Since the current page and the ChangePersonalInfo page are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffChangePersonalInfoBtn_Click(object sender, RoutedEventArgs e)
    {
        // Window redirectStaffToChangePersonalInfo = new StaffChangePersonalInfo();
        // this.Content = redirectStaffToChangePersonalInfo;
        Switcher.StaffMyAccountSwitch(new StaffChangePersonalInfo());
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