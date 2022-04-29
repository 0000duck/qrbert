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
    /// Redirects user to scan pet's QR Code in PetQrcodeScanner window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScanPetQRCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        // Opens camera
        QRCodeScanner.DecodeQRCode();
        // Parses decoded result to integer
        int petId = int.Parse(QRCodeScanner.result);
        // Queries DB to find PetID and verify it
        string msg = 
            Switcher.VerifyRole("SELECT count(*) From QRbertDB.QRbertTables.Pet where PetID = '" + petId + "'");
        // Scans the QR Code and tries to get the amount of records in the database for that string
        // If there were no results
        if (int.Parse(msg) == 0)
        {
            MessageBox.Show("Invalid Pet QR Code. Please try scanning again or try a different Pet QR Code.");
        }
        // At least 1 result
        else
        {
            // Saves PetID to active session
            Switcher.PetId = petId;
            Switcher.VolunteerPortalSwitch(new ());
            this.Close();
        }
    }
}