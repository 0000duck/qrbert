using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class StaffChangePassword : Window
{
    /// <summary>
    /// Upon loading the page, Window checks if boolean is true to turn on Bell Icon
    /// </summary>
    public StaffChangePassword()
    {
        InitializeComponent();
        if (Switcher.IsPetNeglected)
        {
            AlertStaffBellIcon.Visibility = Visibility.Visible;
        }
    }
    
    /// <summary>
    /// If the Icon is not visible, method does nothing
    /// Else redirects user to Staff Neglected Animals page and closes portal 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NotificationBtn_Click(object sender, RoutedEventArgs e)
    {
        if (AlertStaffBellIcon.IsVisible) 
        {
            // At least one Pet is Neglected
            // Means that Switcher.IsPetNeglected = true
            Switcher.StaffPageSwitch(new StaffNeglectedAnimals());
            this.Close();
        }
    }
    
    /// <summary>
    /// Redirects staff to their MyAccount page via button click
    /// Since the portal and the MyAccount are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffMyAccountBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }

    /// <summary>
    /// Logs out Staff and redirects user to the Log In page via button click
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
    
    /// <summary>
    /// Redirects user to scan pet's QR Code in PetQrcodeScanner window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScanPetQRCodeRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        if (Equals(RemoveAnimal.Header, "RemoveAnimal"))
        {
            Switcher.RemoveAnimal = true;
        }
        Switcher.StaffPageSwitch(new StaffScanPetQrCode());
        this.Close();
    }

    /// <summary>
    /// Redirects user to Pet Reports window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetReportsBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffPetReport());
        this.Close();
    }

    /// <summary>
    /// Redirects user to Track Active Volunteers window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TrackActiveVolunteersBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new TrackActiveVolunteers());
        this.Close();
    }

    /// <summary>
    /// Redirects user to Staff Search window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffSearchBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffSearch());
        this.Close();
    }

    /// <summary>
    /// Redirects user to Lock Timesheet window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LockTimesheetsBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffLockTimesheet());
        this.Close();
    }

    /// <summary>
    /// Redirects user to Rounding rules window via button click 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RoundingRulesBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffRoundingRules());
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
                Switcher.StaffPageSwitch(new StaffMyAccount());
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
        Switcher.StaffPageSwitch(new StaffForgotPassword());
        this.Close();
    }
}