using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class StaffMatchVolunteerAnimals : Window
{
    public StaffMatchVolunteerAnimals()
    {
        InitializeComponent();
        // Sets content of all volunteers to their respective textboxes
        // I set all textboxes to be read only
        // The volunteers that don't have another pet assigned have those second pet textboxes hidden
        /*VolFirst1.Text = Switcher.VerifyRole
        ("SELECT FirstName FROM QRbertDB.QRbertTables.Registration where Email ='" + "Bee@gmail.com" + "'");
        VolLast1.Text = Switcher.VerifyRole
        ("SELECT LastName FROM QRbertDB.QRbertTables.Registration where Email ='" +
                                            "Bee@gmail.com" +
                                            "'");
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
        Id5.Text = "604";

        // Sets the Pet textboxes to necessary content, mixing and matching with matched volunteers
        V1Pet1Name.Text = Switcher.VerifyRole(
            "SELECT PetName From QRbertDB.QRbertTables.Pet where PetID = '" + 800 + "'");
        V1Pet1Id.Text = "800";
        V1Pet2Name.Visibility = Visibility.Hidden;
        V1Pet2Id.Visibility = Visibility.Hidden;
        
        V2Pet1Name.Text = Switcher.VerifyRole(
                "SELECT PetName From QRbertDB.QRbertTables.Pet where PetID = '" + 801 + "'");
        V2Pet1Id.Text = "801";
        V2Pet2Name.Text = Switcher.VerifyRole(
            "SELECT PetName From QRbertDB.QRbertTables.Pet where PetID = '" + 802 + "'");
        V2Pet2Id.Text = "802";
        
        V3Pet1Name.Text = Switcher.VerifyRole(
            "SELECT PetName From QRbertDB.QRbertTables.Pet where PetID = '" + 803 + "'");
        V3Pet1Id.Text = "803";
        V3Pet2Name.Text = Switcher.VerifyRole(
            "SELECT PetName From QRbertDB.QRbertTables.Pet where PetID = '" + 800 + "'");
        V3Pet2Id.Text = "800";
        
        V4Pet1Name.Text = Switcher.VerifyRole(
            "SELECT PetName From QRbertDB.QRbertTables.Pet where PetID = '" + 801 + "'");
        V4Pet1Id.Text = "801";
        V4Pet2Name.Visibility = Visibility.Hidden;
        V4Pet2Id.Visibility = Visibility.Hidden;
        
        V5Pet1Name.Text = Switcher.VerifyRole(
            "SELECT PetName From QRbertDB.QRbertTables.Pet where PetID = '" + 802 + "'");
        V5Pet1Id.Text = "802";
        V5Pet2Name.Text = Switcher.VerifyRole(
            "SELECT PetName From QRbertDB.QRbertTables.Pet where PetID = '" + 803 + "'");
        V5Pet2Id.Text = "803";*/

        if (Switcher.IsPetNeglected)
        {
            AlertStaffBellIcon.Visibility = Visibility.Visible;
        }
        
        // Populate the volunteer table
        using SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
        sqlCon.Open();
        string query = 
            ("Select FirstName, LastName from QRbertDB.QRbertTables.Registration where [Faculty-Role] = 'Volunteer'");
        SqlCommand sqlCmdVolunteers = new SqlCommand(query, sqlCon);
        sqlCmdVolunteers.ExecuteNonQuery();
        SqlDataAdapter adpt = new SqlDataAdapter(sqlCmdVolunteers);
        DataTable dtable = new DataTable("VolunteerNames");
        adpt.Fill(dtable);
        VolunteerNames.ItemsSource = dtable.DefaultView;
        adpt.Update(dtable);

        // Populate the pets table
        string query2 = 
            ("Select PetID, PetName from QRbertDB.QRbertTables.Pet where PetID >= '800'");
        SqlCommand sqlCmdPets = new SqlCommand(query, sqlCon);
        sqlCmdVolunteers.ExecuteNonQuery();
        SqlDataAdapter adpt2 = new SqlDataAdapter(sqlCmdPets);
        DataTable dtable2 = new DataTable("VolunteerNames");
        adpt2.Fill(dtable2);
        PetDataGrid.ItemsSource = dtable2.DefaultView;
        adpt.Update(dtable2);
        sqlCon.Close();
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
}