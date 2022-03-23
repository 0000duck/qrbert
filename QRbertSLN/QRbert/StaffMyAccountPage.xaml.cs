using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class StaffMyAccountPage : Page
{
    public StaffMyAccountPage()
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
        Page redirectStaffChangeEmail = new StaffChangeEmail();
        this.Content = redirectStaffChangeEmail;
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
        Page redirectStaffChangePersonalInfo = new StaffChangePersonalInfo();
        this.Content = redirectStaffChangePersonalInfo;
    }
}