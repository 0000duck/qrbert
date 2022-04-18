using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class StaffScanPetQrCode : Window
{
    public StaffScanPetQrCode()
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
    /// Redirects user to scan pet's QR Code in PetQrcodeScanner window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScanPetQRCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        QRCodeScanner.DecodeQRCode();
        string petId = QRCodeScanner.result;
        string msg = 
            verifyRole("SELECT count(*) From QRbertDB.QRbertTables.Pet where PetID = '" + petId + "'");
        // Scans the QR Code and tries to get the amount of records in the database for that string
        // If there were no results
        if (int.Parse(msg) == 0)
        {
            MessageBox.Show("Invalid Pet QR Code. Please try scanning again or try a different Pet QR Code.");
        }
        // At least 1 result
        else
        {
            Switcher.StaffPageSwitch(new StaffMyPets());
            this.Close();
        }
    }
    
    /// <summary>
    /// Verifies a string via an SQL connection to our database
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    private string verifyRole(string s)
    {
        using SqlConnection sqlCon = new SqlConnection(Switcher.connectionString);
        sqlCon.Open();
        SqlCommand command = new SqlCommand(s, sqlCon);
        string query = command.ExecuteScalar().ToString();
        return query;
    }
}