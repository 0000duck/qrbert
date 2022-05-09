using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class VolunteerChangeEmail
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
        Close();
    }

    /// <summary>
    /// Logs out Volunteer and redirects user to the Log In page via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogOutSwitch();
        Close();
    }

    /// <summary>
    /// Redirects user to home page - volunteer portal via QRbert image click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeVolunteerPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectVolunteerPortal();
        Close();
    }
    
    /// <summary>
    /// Redirects user to view timesheet window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewTimesheetBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerViewTimesheets());
        Close();
    }

    /// <summary>
    /// Redirects user to scan pet qr code window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScanPetQRCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        Close();
    }

    /// <summary>
    /// Redirects user to pet report window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetReportBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        Close();
    }
    
    /// <summary>
    /// Redirects user to the FAQ window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FAQRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerFAQs());
        Close();
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
                // Opens connection, gets needed info for command and executes and updates the email
                SqlConnection sqlConnection = new SqlConnection(Switcher.ConnectionString);
                sqlConnection.Open();
                try
                {
                    string facultyRole = "Select [Faculty-Role] From QRbertDB.QRbertTables.Registration Where Email = '" + 
                                         Switcher.CurrentSessionEmail + "';";
                    string password = "Select Password From QRbertDB.QRbertTables.Registration Where Email = '" +
                                      Switcher.CurrentSessionEmail + "';";
                    string firstName = "Select FirstName From QRbertDB.QRbertTables.Registration Where Email = '" +
                                       Switcher.CurrentSessionEmail + "';";
                    string lastName = "Select LastName From QRbertDB.QRbertTables.Registration Where Email = '" +
                                      Switcher.CurrentSessionEmail + "';";
                    SqlCommand sqlCmd = new SqlCommand("updateEmailPwd", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Email", Switcher.CurrentSessionEmail);
                    sqlCmd.Parameters.AddWithValue("@Password", password);
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
                Switcher.VolunteerPortalSwitch(new VolunteerMyAccount());
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

    private void NewEmailInput_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtNewEmailCode.Visibility = Visibility.Visible;
        if (NewEmailInput.Text.Length > 0)
        {
            txtNewEmailCode.Visibility = Visibility.Hidden;
        }
    }

    private void ConfirmNewEmailInput_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtConfirmNewEmailCode.Visibility = Visibility.Visible;
        if (ConfirmNewEmailInput.Text.Length > 0)
        {
            txtConfirmNewEmailCode.Visibility = Visibility.Hidden;
        }
    }
}