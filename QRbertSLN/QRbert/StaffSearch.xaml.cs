using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace QRbert;

public partial class StaffSearch
{
    /*
    * connects DB to Register Page
    * Data source is the name of the DB server
    * Initial Catalog the QRbert database we want to connect to
    * User name and Password -> temp log in solution until we find a more secure way to log into the DB
    * so that the log in credentials aren't in the code for all to see
    */
    public StaffSearch()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// Checks if search is valid input, calls checkString function
    /// </summary>
    /// <param name="text"></param>
    /// <returns>
    /// True if valid, false otherwise
    /// </returns>
    private static bool IsSearchValid(string text)
    {
        return CheckString(text);
    }
    
    /// <summary>
    /// Function that checks for empty string
    /// </summary>
    /// <param name="words"></param>
    /// <returns>
    /// False if no words inputted in search, true otherwise
    /// </returns>
    private static bool CheckString(string words)
    {
        if (words == "")
        {
            return false;
        }

        return true;

    }
    
    
    private void Search(object sender, EventArgs e)
    {
        if (!IsSearchValid(SearchInput.Text))
        {
            MessageBox.Show("Search invalid. Please try again.");
        }
        else
        {
            // Separate input into first and last names for searching
            String[] nameList = SearchInput.Text.Split(' ');
            String firstName = nameList[0];
            String lastName = String.Join(' ', nameList.Skip(1));
            
            // Execute query in database and display results
            using SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
            sqlCon.Open();
            string query = ("SELECT [Faculty-Role], FirstName, LastName, Email FROM QRbertDB.QRbertTables.Registration WHERE FirstName LIKE '" + firstName + "' OR LastName LIKE '" + lastName + "'");
            SqlCommand command = new SqlCommand(query, sqlCon);
            command.ExecuteNonQuery();
            
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            DataTable dtable = new DataTable("QRbert.QRbertTables.Registration");
            adpt.Fill(dtable);
            SearchResults.ItemsSource = dtable.DefaultView;
            adpt.Update(dtable);
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
}

