using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

/*
 * Window for Staff - To Track Active Volunteers
 */

public partial class TrackActiveVolunteers : Window
{
    public TrackActiveVolunteers()
    {
        InitializeComponent();
        //Vol1.Text = Switcher.VerifyRole("SELECT VolName FROM QRbertDB.QRberttables.Volunteers where VolID = 
        /*VolFirst1.Text = Switcher.VerifyRole(
            ("SELECT FirstName FROM QRbertDB.QRbertTables.Registration where Email ='" + "Bee@gmail.com" +
             "'"));
        VolLast1.Text = Switcher.VerifyRole(("SELECT LastName FROM QRbertDB.QRbertTables.Registration where Email ='" +
                                             "Bee@gmail.com" +
                                             "'"));
        Id1.Text = "600";

        VolFirst2.Text = Switcher.VerifyRole(
            ("SELECT FirstName FROM QRbertDB.QRbertTables.Registration where Email ='" + "Cartman@gmail.com" +
             "'"));
        VolLast2.Text = Switcher.VerifyRole(("SELECT LastName FROM QRbertDB.QRbertTables.Registration where Email ='" +
                                             "Cartman@gmail.com" +
                                             "'"));
        Id2.Text = "601";

        VolFirst3.Text = Switcher.VerifyRole(
            ("SELECT FirstName FROM QRbertDB.QRbertTables.Registration where Email ='" + "fleck@gmail.com" +
             "'"));
        VolLast3.Text = Switcher.VerifyRole(("SELECT LastName FROM QRbertDB.QRbertTables.Registration where Email ='" +
                                             "fleck@gmail.com" +
                                             "'"));
        Id3.Text = "602";

        VolFirst4.Text = Switcher.VerifyRole(
            ("SELECT FirstName FROM QRbertDB.QRbertTables.Registration where Email ='" + "stark@gmail.com" +
             "'"));
        VolLast4.Text = Switcher.VerifyRole(("SELECT LastName FROM QRbertDB.QRbertTables.Registration where Email ='" +
                                             "stark@gmail.com" +
                                             "'"));
        Id4.Text = "603";
        VolFirst5.Text = Switcher.VerifyRole(
            ("SELECT FirstName FROM QRbertDB.QRbertTables.Registration where Email ='" + "Gibbons@gmail.com" +
             "'"));
        VolLast5.Text = Switcher.VerifyRole(("SELECT LastName FROM QRbertDB.QRbertTables.Registration where Email ='" +
                                             "Gibbons@gmail.com" +
                                             "'"));
        Id5.Text = "604";*/
        
        using SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
        sqlCon.Open();
        string query = 
            ("Select FirstName, LastName, Email from QRbertDB.QRbertTables.Registration where [Faculty-Role] = 'Volunteer'");
        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        sqlCmd.ExecuteNonQuery();
        SqlDataAdapter adpt = new SqlDataAdapter(sqlCmd);
        DataTable dtable = new DataTable("QRbertDB.QRbertTables.ActiveVolunteers");
        adpt.Fill(dtable);
        ActiveVolunteers.ItemsSource = dtable.DefaultView;
        adpt.Update(dtable);
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
            this.Close();
        }
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
    /// Redirects user to the FAQ window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FAQRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffFAQs());
        Close();

        
    }
    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {

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
