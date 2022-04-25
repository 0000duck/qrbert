using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class VolunteerChangeEmail : Window
{
    public VolunteerChangeEmail()
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
    /// Updates user email in Registration with new inputted email; then takes them to the MyAccount Page
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
                string userType = 
                        Switcher.VerifyRole("Select [Faculty-Role] From QRbertTables.Registration Where email = '" 
                                            + Switcher.CurrentSessionEmail + "'");
                SqlCommand sqlCmd =
                    new SqlCommand(
                        "Update Registration Set Email = '" + NewEmailInput.Text + "' Where Faculty-role = '" +
                        userType + "'", new SqlConnection(Switcher.ConnectionString));
                sqlCmd.ExecuteScalar();
                MessageBox.Show("Email has been updated.");
                Switcher.VolunteerPortalSwitch(new VolunteerMyAccount());
                this.Close();
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