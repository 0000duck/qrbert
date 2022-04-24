using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class StaffChangePersonalInfo : Window
{
    public StaffChangePersonalInfo()
    {
        InitializeComponent();
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

    /// <summary>
    /// Saves all personal information via button click
    /// Makes a new connection to the database for every non-empty textbox
    /// Redirects user to the my account page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        using SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
        sqlCon.Open();
        string userType = Switcher.VerifyRole("Select [Faculty-Role] From QRbertTables.Registration Where email = '"
                                              + Switcher.CurrentSessionEmail + "'");
        
        if (AddressInputTxt.Text != "")
        {
            SqlCommand sqlCmd = new SqlCommand(
                "Update Contact_Info Set Street-Add = '" + AddressInputTxt.Text + "' Where Faculty-role = ' " +
                userType + "'", new SqlConnection(Switcher.ConnectionString));
        }

        if (CityInputTxt.Text != "")
        {
            SqlCommand sqlCmd = new SqlCommand(
                "Update Contact_Info Set City ='" + CityInputTxt.Text + "' Where Faculty-role = ' " +
                userType + "'", new SqlConnection(Switcher.ConnectionString));
        }

        if (StateInputTxt.Text != "")
        {
            SqlCommand sqlCmd = new SqlCommand(
                "Update Contact_Info Set State ='" + StateInputTxt.Text + "' Where Faculty-role = ' " +
                userType + "'", new SqlConnection(Switcher.ConnectionString));
        }

        if (ZipcodeInputTxt.Text != "")
        {
            SqlCommand sqlCmd = new SqlCommand(
                "Update Contact_Info Set ZipCode ='" + ZipcodeInputTxt.Text + "' Where Faculty-role = ' " +
                userType + "'", new SqlConnection(Switcher.ConnectionString));
        }
        MessageBox.Show("All information updated.");
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }
}