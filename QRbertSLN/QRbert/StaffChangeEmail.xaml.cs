using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class StaffChangeEmail
{
    /// <summary>
    /// Upon loading the page, Window checks if boolean is true to turn on Bell Icon
    /// </summary>
    public StaffChangeEmail()
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
    /// Updates the user email to a new email they register and redirects them to MyAccount Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        // If textboxes aren't empty
        if (NewEmailInput.Text != "" && ConfirmNewEmailInput.Text != "")
        {
            // If the textboxes do not contain the same email
            if (NewEmailInput.Text != ConfirmNewEmailInput.Text)
            {
                NewEmailInput.Text = "";
                ConfirmNewEmailInput.Text = "";
                MessageBox.Show("New emails don't match, please try again.");
            }
            // If they do contain the same email
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
                    string password = 
                        Switcher.VerifyRole(
                            "Select Password From QRbertDB.QRbertTables.Registration Where Email = '" + 
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
                    sqlCmd.Parameters.AddWithValue("@NewEmail", NewEmailInput.Text);
                    sqlCmd.Parameters.AddWithValue("@OldPassword", "");
                    sqlCmd.Parameters.AddWithValue("@NewPassword", password);
                    sqlCmd.Parameters.AddWithValue("@Faculty_Role", facultyRole);
                    sqlCmd.Parameters.AddWithValue("@FirstName", firstName);
                    sqlCmd.Parameters.AddWithValue("@LastName", lastName);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Email has been updated.");
                }
                catch (SqlException sqlException)
                {
                    MessageBox.Show(sqlException.Message);
                }
                Switcher.StaffPageSwitch(new StaffMyAccount());
                Close();
            }
        }
        // The textboxes are empty
        else 
        {
            NewEmailInput.Text = "";
            ConfirmNewEmailInput.Text = "";
            MessageBox.Show("One of the email fields is empty, please try again.");
        }
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

    private void NewEmailInput_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtNewEmailBlock.Visibility = Visibility.Visible;
        if (NewEmailInput.Text.Length > 0)
        {
            txtNewEmailBlock.Visibility = Visibility.Hidden;
        }
    }

    private void ConfirmNewEmailInput_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtConfirmNewEmailBlock.Visibility = Visibility.Visible;
        if (ConfirmNewEmailInput.Text.Length > 0)
        {
            txtConfirmNewEmailBlock.Visibility = Visibility.Hidden;
        }
    }
}