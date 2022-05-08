using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class VolunteerScanPetQrCode
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
        string[] qrResult = QRCodeScanner.result.Split(' ');
        if (int.TryParse(qrResult[0], out int result))
        {
            // Queries DB to find PetID and verify it
            string msg = 
                Switcher.VerifyRole("SELECT count(*) From QRbertDB.QRbertTables.Pet where PetID = '" + result + "'");
            // Scans the QR Code and tries to get the amount of records in the database for that string
            // If there were no results
            if (int.Parse(msg) == 0)
            {
                MessageBox.Show("That QR code does not exist in the Database.\nPlease try a different one.");
            }
            // At least 1 result
            else
            {
                
                /*
                 * here's the thing, when i click the remove animal button it takes me to scan the pet qr code which
                 * is working
                 * then i call this method
                 * it goes into the if statement correctly, the one below
                 * i then call the verify role method below given the following query
                 * the query looks fine, but it may be the fact that the verify role method does this
                 */
                // Saves PetID to active session
                Switcher.PetId = result;
                Switcher.IsPetScanned = true;
                Switcher.VolunteerPortalSwitch(new VolunteerMyPets());
                Close();
            }
        }
        else
        {
            MessageBox.Show("Invalid QR code. Please try scanning again.");
        }
    }
}