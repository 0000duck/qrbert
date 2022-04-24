using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class VolunteerChangePassword : Window
{
    public VolunteerChangePassword()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Redirects volunteer user to their MyAccount window via a button click on the menu item
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerMyAcctBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerMyAccount());
        this.Close();
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
    
    /// <summary>
    /// Redirects user to view timesheet window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewTimesheetBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerViewTimesheets());
        this.Close();
    }

    /// <summary>
    /// Redirects user to scan pet qr code window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScanPetQRCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        this.Close();
    }

    /// <summary>
    /// Redirects user to pet report window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetReportBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerPetReport());
        this.Close();
    }
    
    /// <summary>
    /// Changes staff user password to desired new password given inputted in textboxes and executed via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        // Verifies the current password the user has
        string verifyCurrentPwd = Switcher.VerifyRole("Select Password From QRbertTables.Registration Where email = '" +
                                                      Switcher.CurrentSessionEmail + "'");
        // If the verified password string isn't the same as the inputted current password,
        // then catch error and reset to empty textboxes
        if (verifyCurrentPwd != CurrentPwdInput.Text)
        {
            MessageBox.Show("The inputted current password was incorrect. Please try again.");
            CurrentPwdInput.Text = "";
            NewPwdInput.Text = "";
            ConfirmNewPwdInput.Text = "";
        }
        else
        {
            // If the new passwords don't match, catch the error and reset textboxes
            if (NewPwdInput.Text != ConfirmNewPwdInput.Text)
            {
                MessageBox.Show("Your new password did not match the other. Please type them again.");
                NewPwdInput.Text = "";
                ConfirmNewPwdInput.Text = "";
            }
            // If the length is too short
            else if (NewPwdInput.Text.Length < 8 || ConfirmNewPwdInput.Text.Length < 8)
            {
                MessageBox.Show("Your new password is too short. Please try a different password.");
                NewPwdInput.Text = "";
                ConfirmNewPwdInput.Text = "";
            }
            // Passes all the checks, updates password and takes to MyAccount page
            else
            {
                string userType = Switcher.VerifyRole("Select [Faculty-Role] From QRbertTables.Registration Where email = '" 
                                                      + Switcher.CurrentSessionEmail + "'");
                SqlCommand sqlCmd =
                    new SqlCommand(
                        "Update Registration Set Password = '" + ConfirmNewPwdInput.Text + "' Where Faculty-role = ' " +
                        userType + "'", new SqlConnection(Switcher.ConnectionString));
                sqlCmd.ExecuteScalar();
                MessageBox.Show("Password has been updated.");
                Switcher.VolunteerPortalSwitch(new VolunteerMyAccount());
                this.Close();
            }
        }
    }

    /// <summary>
    /// User clicks forgot password via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ForgotPasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerMyAccount());
        this.Close();
    }
}