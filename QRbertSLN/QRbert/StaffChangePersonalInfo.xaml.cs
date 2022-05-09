using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class StaffChangePersonalInfo
{
    /// <summary>
    /// Upon loading the page, Window checks if boolean is true to turn on Bell Icon
    /// </summary>
    public StaffChangePersonalInfo()
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
    private void LockTimesheetBtn_Click(object sender, RoutedEventArgs e)
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
            
            /*if (AddressInputTxt.Text != "")
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
            }*/
            sqlCmd.Parameters.AddWithValue("@Street-Add", AddressInputTxt.Text);
            sqlCmd.Parameters.AddWithValue("@City", CityInputTxt.Text);
            sqlCmd.Parameters.AddWithValue("@State", StateInputTxt.Text);
            sqlCmd.Parameters.AddWithValue("@ZipCode", ZipcodeInputTxt.Text);
            sqlCmd.Parameters.AddWithValue("@PhoneNum", PhoneNumberInputTxt.Text);
            sqlCmd.Parameters.AddWithValue("@DL_ID", dl);
            
            sqlCmd.ExecuteNonQuery();
            MessageBox.Show("Your info has been updated.");
        }
        catch (SqlException sqlException)
        {
            MessageBox.Show(sqlException.Message);
        }

        
        MessageBox.Show("All information updated.");
        Switcher.StaffPageSwitch(new StaffMyAccount());
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

    private void AddressInputTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtAddressBlock.Visibility = Visibility.Visible;
        if (AddressInputTxt.Text.Length > 0)
        {
            txtAddressBlock.Visibility = Visibility.Hidden;
        }
    }

    private void CityInputTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtCityBlock.Visibility = Visibility.Visible;
        if (CityInputTxt.Text.Length > 0)
        {
            txtCityBlock.Visibility = Visibility.Hidden;
        }    
    }

    private void StateInputTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtStateBlock.Visibility = Visibility.Visible;
        if (StateInputTxt.Text.Length > 0)
        {
            txtStateBlock.Visibility = Visibility.Hidden;
        }
    }

    private void ZipcodeInputTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtZipcodeBlock.Visibility = Visibility.Visible;
        if (ZipcodeInputTxt.Text.Length > 0)
        {
            txtZipcodeBlock.Visibility = Visibility.Hidden;
        }
    }

    private void PhoneNumberInputTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtPhoneNumberBlock.Visibility = Visibility.Visible;
        if (PhoneNumberInputTxt.Text.Length > 0)
        {
            txtPhoneNumberBlock.Visibility = Visibility.Hidden;
        }    
    }
}