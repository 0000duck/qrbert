using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class VolunteerChangePersonalInformation
{
    public VolunteerChangePersonalInformation()
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
    /// Saves all personal information via button click
    /// Makes a new connection to the database for every non-empty textbox
    /// Redirects user to the my account page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveBtn_Click(object sender, RoutedEventArgs e)
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
            string streetAddr = 
                Switcher.VerifyRole(
                    "Select [Street-Add] From QRbertDB.QRbertTables.Contact_Info Where Email = '" + 
                    Switcher.CurrentSessionEmail + "';");
            string city = Switcher.VerifyRole(
                "Select City From QRbertDB.QRbertTables.Contact_Info Where Email = '" + Switcher.CurrentSessionEmail +
                "';");
            string state = Switcher.VerifyRole(
                "Select State From QRbertDB.QRbertTables.Contact_Info Where Email = '" + Switcher.CurrentSessionEmail +
                "';");
            string zipCode = Switcher.VerifyRole(
                "Select ZipCode From QRbertDB.QRbertTables.Contact_Info Where Email = '" +
                Switcher.CurrentSessionEmail + "';");
            string phone = Switcher.VerifyRole(
                "Select PhoneNum From QRbertDB.QRbertTables.Contact_Info Where Email = '" +
                Switcher.CurrentSessionEmail + "';");
            string dl = Switcher.VerifyRole(
                "Select [DL_ID] From QRbertDB.QRbertTables.Contact_Info Where Email = '" +
                Switcher.CurrentSessionEmail + "';");
            
            SqlCommand sqlCmd = new SqlCommand("UpdateContactInfo", sqlConnection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Email", Switcher.CurrentSessionEmail);
            sqlCmd.Parameters.AddWithValue("@Password", password);
            sqlCmd.Parameters.AddWithValue("@Faculty_Role", facultyRole);
            
            if (AddressInputTxt.Text != "")
            {
                sqlCmd.Parameters.AddWithValue("@Street-Add", AddressInputTxt.Text);
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@Street-Add", streetAddr);
            }

            if (CityInputTxt.Text != "")
            {
                sqlCmd.Parameters.AddWithValue("@City", CityInputTxt.Text);
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@City", city);
            }

            if (StateInputTxt.Text != "")
            {
                sqlCmd.Parameters.AddWithValue("@State", StateInputTxt.Text);
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@State", state);
            }

            if (ZipcodeInputTxt.Text != "")
            {
                sqlCmd.Parameters.AddWithValue("@ZipCode", ZipcodeInputTxt.Text);
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipCode);
            }

            if (PhoneNumberInputTxt.Text != "")
            {
                sqlCmd.Parameters.AddWithValue("@PhoneNum", PhoneNumberInputTxt.Text);
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@ZipCode", phone);
            }
            sqlCmd.Parameters.AddWithValue("@DL_ID", dl);
            
            sqlCmd.ExecuteNonQuery();
            MessageBox.Show("Your info has been updated.");
        }
        catch (SqlException sqlException)
        {
            MessageBox.Show(sqlException.Message);
        }
        MessageBox.Show("All information updated.");
        Switcher.VolunteerPortalSwitch(new VolunteerMyAccount());
        Close();
    }

    private void AddressInputTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtAddress.Visibility = Visibility.Visible;
        if (AddressInputTxt.Text.Length > 0)
        {
            txtAddress.Visibility = Visibility.Hidden;
        }
    }

    private void CityInputTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtCity.Visibility = Visibility.Visible;
        if (CityInputTxt.Text.Length > 0)
        {
            txtCity.Visibility = Visibility.Hidden;
        }
    }

    private void StateInputTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtState.Visibility = Visibility.Visible;
        if (StateInputTxt.Text.Length > 0)
        {
            txtState.Visibility = Visibility.Hidden;
        }
    }

    private void ZipcodeInputTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtZipcode.Visibility = Visibility.Visible;
        if (ZipcodeInputTxt.Text.Length > 0)
        {
            txtZipcode.Visibility = Visibility.Hidden;
        }
    }

    private void PhoneNumberInputTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtPhoneNumber.Visibility = Visibility.Visible;
        if (PhoneNumberInputTxt.Text.Length > 0)
        {
            txtPhoneNumber.Visibility = Visibility.Hidden;
        }
    }
}