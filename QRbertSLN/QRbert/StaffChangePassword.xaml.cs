using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class StaffChangePassword
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
            Close();
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
        Close();
    }

    /// <summary>
    /// Logs out Staff and redirects user to the Log In page via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogOutSwitch();
        Close();
    }

    /// <summary>
    /// Redirects user to home page - staff portal via QRbert image click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeStaffPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectStaffPortal();
        Close();
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
        Close();
    }

    /// <summary>
    /// Redirects user to Pet Reports window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetReportsBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffPetReport());
        Close();
    }

    /// <summary>
    /// Redirects user to Track Active Volunteers window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TrackActiveVolunteersBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new TrackActiveVolunteers());
        Close();
    }

    /// <summary>
    /// Redirects user to Staff Search window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffSearchBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffSearch());
        Close();
    }

    /// <summary>
    /// Redirects user to Lock Timesheet window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LockTimesheetsBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffLockTimesheet());
        Close();
    }

    /// <summary>
    /// Redirects user to Rounding rules window via button click 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RoundingRulesBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffRoundingRules());
        Close();
    }
    
    /// <summary>
    /// Redirects user to the FAQ window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FAQRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffFAQs());
        Close();
    }

    /// <summary>
    /// If input is in password, makes textblock visible
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        TxtCurrentPassword.Visibility = Visibility.Visible;
        if (CurrentPasswordBox.Password.Length > 0)
        {
            TxtCurrentPassword.Visibility = Visibility.Hidden;
        }
    }

    /// <summary>
    /// If New password input is observed, makes new password textbox visible
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NewPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        txtNewPassword.Visibility = Visibility.Visible;
        if (NewPasswordBox.Password.Length > 0)
        {
            txtNewPassword.Visibility = Visibility.Hidden;
        }
    }

    /// <summary>
    /// If confirm new password box input is observed, makes textbox visible
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        string verifyCurrentPwd = Switcher.VerifyRole("Select Password From QRbertDB.QRbertTables.Registration Where email = '" +
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
                // Opens connection, gets needed info for command and executes and updates the email
                SqlConnection sqlConnection = new SqlConnection(Switcher.ConnectionString);
                sqlConnection.Open();
                try
                {
                    string facultyRole =
                        Switcher.VerifyRole(
                            "Select [Faculty-Role] From QRbertDB.QRbertTables.Registration Where Email = '" +
                            Switcher.CurrentSessionEmail + "';");
                    string firstName = 
                        Switcher.VerifyRole(
                            "Select FirstName From QRbertDB.QRbertTables.Registration Where Email = '" + 
                            Switcher.CurrentSessionEmail + "';");
                    string lastName = 
                        Switcher.VerifyRole(
                            "Select LastName From QRbertDB.QRbertTables.Registration Where Email = '" + 
                            Switcher.CurrentSessionEmail + "';");
                    SqlCommand sqlCmd = new SqlCommand("updateEmailPwd", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@CurrentEmail", Switcher.CurrentSessionEmail);
                    sqlCmd.Parameters.AddWithValue("@NewEmail", "");
                    sqlCmd.Parameters.AddWithValue("@OldPassword", CurrentPasswordBox.Password);
                    sqlCmd.Parameters.AddWithValue("@NewPassword", NewPasswordBox.Password);
                    sqlCmd.Parameters.AddWithValue("@Faculty_Role", facultyRole);
                    sqlCmd.Parameters.AddWithValue("@FirstName", firstName);
                    sqlCmd.Parameters.AddWithValue("@LastName", lastName);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Password has been updated.");
                }
                catch (SqlException sqlException)
                {
                    MessageBox.Show(sqlException.Message);
                }
                Switcher.StaffPageSwitch(new StaffMyAccount());
                Close();
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
        Close();
    }
    
    /// <summary>
    /// Redirects user to Staff Terms of Privacy via btn click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TermsOfPrivacyBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffTermsofPrivacy());
        Close();
    }

    /// <summary>
    /// Redirects user to Staff Track Animal Activity via btn click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewPetActivityBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffTrackAnimalActivity());
        Close();
    }

    /// <summary>
    /// Redirects user to Staff View Pet Treatment via btn click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewPetTreatmentBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffViewPetTreatment());
        Close();
    }
    
    /// <summary>
    /// Redirects user to Scan Pet QR Code, new function allows Staff to Remove pet via btn click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RemoveAnimalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RemoveAnimal = true;
        Switcher.StaffPageSwitch(new StaffScanPetQrCode());
        Close();
    }
}