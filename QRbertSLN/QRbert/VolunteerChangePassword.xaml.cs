using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class VolunteerChangePassword
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

    private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        txtCurrentPassword.Visibility = Visibility.Visible;
        if (CurrentPasswordBox.Password.Length > 0)
        {
            txtCurrentPassword.Visibility = Visibility.Hidden;
        }
    }

    private void NewPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        txtNewPassword.Visibility = Visibility.Visible;
        if (NewPasswordBox.Password.Length > 0)
        {
            txtNewPassword.Visibility = Visibility.Hidden;
        }
    }

    private void ConfirmNewPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        txtConfirmNewPassword.Visibility = Visibility.Visible;
        if (ConfirmNewPasswordBox.Password.Length > 0)
        {
            txtConfirmNewPassword.Visibility = Visibility.Hidden;
        }
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
        if (verifyCurrentPwd != CurrentPasswordBox.Password)
        {
            MessageBox.Show("The inputted current password was incorrect. Please try again.");
            CurrentPasswordBox.Password = "";
            NewPasswordBox.Password = "";
            ConfirmNewPasswordBox.Password = "";
        }
        else
        {
            // If the new passwords don't match, catch the error and reset textboxes
            if (NewPasswordBox.Password != ConfirmNewPasswordBox.Password)
            {
                MessageBox.Show("Your new password did not match the other. Please type them again.");
                NewPasswordBox.Password = "";
                ConfirmNewPasswordBox.Password = "";
            }
            // If the length is too short
            else if (NewPasswordBox.Password.Length < 8 || ConfirmNewPasswordBox.Password.Length < 8)
            {
                MessageBox.Show("Your new password is too short. Please try a different password.");
                NewPasswordBox.Password = "";
                ConfirmNewPasswordBox.Password = "";
            }
            // Passes all the checks, updates password and takes to MyAccount page
            else
            {
                string userType = Switcher.VerifyRole("Select [Faculty-Role] From QRbertTables.Registration Where email = '" 
                                                      + Switcher.CurrentSessionEmail + "'");
                SqlCommand sqlCmd =
                    new SqlCommand(
                        "Update Registration Set Password = '" + ConfirmNewPasswordBox.Password + "' Where Faculty-role = ' " +
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