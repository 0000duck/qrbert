using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class VolunteerScanPetQrCode : Window
{
    public VolunteerScanPetQrCode()
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
        // At least one result
        else
        {
            Switcher.StaffPageSwitch(new VolunteerMyPets());
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