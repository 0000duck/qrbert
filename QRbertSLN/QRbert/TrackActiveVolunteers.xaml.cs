using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

/*
 * Window for Staff - To Track Active Volunteers
 */

public partial class TrackActiveVolunteers
{
    public TrackActiveVolunteers()
    {
        InitializeComponent();

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
    private void LockTimesheetsBtn_Click(object sender, RoutedEventArgs e)
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

    /// <summary>
    /// Redirects user to Match Volunteers to Pets window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MatchActiveVolunteersToPetsBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMatchVolunteerAnimals());
        Close();
    }
}
