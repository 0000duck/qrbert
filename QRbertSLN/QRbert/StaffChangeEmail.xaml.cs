using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class StaffChangeEmail : Window
{
    public StaffChangeEmail()
    {
        InitializeComponent();
    }
    private void NotificationBtn_Click(object sender, RoutedEventArgs e)
    {
        
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
                MessageBox.Show("Emails don't match, please try again.");
            }
            // If they do contain the same email
            else
            {
                // Query the database and update email
                using (SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString))
                {
                    string msg = 
                        Switcher.VerifyRole("Select [Faculty-Role] From QRbertTables.Registration Where email = '" + Switcher.CurrentSessionEmail + "'");
                    string userType = msg;
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Update Registration Set Email = '" + NewEmailInput.Text + "' Where Faculty-role = '" + userType + "'", sqlCon);
                    sqlCmd.ExecuteScalar();
                    MessageBox.Show("Email has been updated.");
                    Switcher.StaffPageSwitch(new StaffMyAccount());
                    this.Close();
                }
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
}