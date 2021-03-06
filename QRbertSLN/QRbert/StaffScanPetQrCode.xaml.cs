using System.Data.SqlClient;
using System.Windows;
using ZXing;

namespace QRbert;

public partial class StaffScanPetQrCode : Window
{
    public StaffScanPetQrCode()
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
    private void LockTimesheetBtn_Click(object sender, RoutedEventArgs e)
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
            // Parses decoded result to integer
            int petId = int.Parse(qrResult[0]);
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
                
                /*
                 * here's the thing, when i click the remove animal button it takes me to scan the pet qr code which
                 * is working
                 * then i call this method
                 * it goes into the if statement correctly, the one below
                 * i then call the verify role method below given the following query
                 * the query looks fine, but it may be the fact that the verify role method does this
                 */
                if (Switcher.RemoveAnimal)
                {
                    SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
                    string sqlStatement = "Delete From QRbertDB.QRbertTables.Pet where PetID = '" + petId + "';";
                    try
                    {
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand(sqlStatement, sqlCon);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Pet successfully removed.");
                        Switcher.PetId = 0;
                        Switcher.RedirectStaffPortal();
                        Close();
                    }
                    catch (SqlException sqlException)
                    {
                        MessageBox.Show(sqlException.Message);
                    }
                    finally
                    {
                        sqlCon.Close();
                    }
                }
                else
                {
                    // Saves PetID to active session
                    Switcher.PetId = petId;
                    Switcher.IsPetScanned = true;
                    if (Switcher.IsPetTreatment)
                    {
                        Switcher.StaffPageSwitch(new StaffViewPetTreatment());
                    }
                    else
                    {
                        Switcher.StaffPageSwitch(new StaffTrackAnimalActivity());
                            
                    }
                    Close();
                }
            }
        }
        else
        {
            MessageBox.Show("Invalid QR code. Please try scanning again.");
        }
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

}