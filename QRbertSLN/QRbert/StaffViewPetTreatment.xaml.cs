using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class StaffViewPetTreatment 
{
    /// <summary>
    /// Upon loading the page, Window checks if boolean is true to turn on Bell Icon
    /// </summary>
    public StaffViewPetTreatment()
    {
        InitializeComponent();
        if (Switcher.IsPetNeglected)
        {
            AlertStaffBellIcon.Visibility = Visibility.Visible;
        }
        
        // Load Pet ID, Pet Name, and current Date when Window loads
        SqlConnection sqlConnection = new SqlConnection(Switcher.ConnectionString);
        try
        {
            sqlConnection.Open();
            string petName = "Select PetName From QRbertDB.QRbertTables.Pet Where PetID = '" + 
                             Switcher.PetId + "';";
            SqlCommand sqlCommandForPetName = new SqlCommand(petName, sqlConnection);
            PetName.Text = sqlCommandForPetName.ExecuteScalar().ToString();
            sqlCommandForPetName.Dispose();
            
            string sqlStatement = "Select PetID, InjuryType, Incident_Date, Rx from QRbertDB.QRbertTables.Pet_Treatment where PetID = '" 
                                  + Switcher.PetId + "';";
            SqlCommand sqlCmd = new SqlCommand(sqlStatement, sqlConnection);
            sqlCmd.ExecuteNonQuery();
            SqlDataAdapter adpt = new SqlDataAdapter(sqlCmd);
            DataTable dtable = new DataTable("Pet Treatment");
            adpt.Fill(dtable);
            DataGV.ItemsSource = dtable.DefaultView;
            adpt.Update(dtable);
        }
        catch (SqlException sqlException)
        {
            MessageBox.Show(sqlException.Message);
        }
        finally
        {
            sqlConnection.Close();
        }
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
    private void LockTimesheetBtn_Click(object sender, RoutedEventArgs e)
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
    /// Redirects user to the Add Pet Treatment window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddPetTreatmentBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new AddPetTreatment());
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
}