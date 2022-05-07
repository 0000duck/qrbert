using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class StaffNeglectedAnimals
{
    public StaffNeglectedAnimals()
    {
        InitializeComponent();
        
        using SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
        sqlCon.Open();
        string query =
            ("Select QRbertDB.QRbertTables.Pet.PetName, QRbertDB.QRbertTables.Pet.PetID from QRbertDB.QRbertTables.Pet left join QRbertDB.QRbertTables.Pet_Activity on QRbertDB.QRbertTables.Pet.PetName = QRbertDB.QRbertTables.Pet_Activity.PetName where QRbertDB.QRbertTables.Pet_Activity.Activity_Date is null;");
        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        sqlCmd.ExecuteNonQuery();
        SqlDataAdapter adpt = new SqlDataAdapter(sqlCmd);
        DataTable dtable = new DataTable("QRbertDB.QRbertTables.Pet_Activity");
        adpt.Fill(dtable);
        NeglectedAnimals.ItemsSource = dtable.DefaultView;
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
        if (Equals(RemoveAnimal.Header, "RemoveAnimal"))
        {
            Switcher.RemoveAnimal = true;
        }
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
    /// Assigns Neglected Pet to volunteer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AssignPetToVolunteer(object sender, RoutedEventArgs e)
    {
        if (AssignPetToVolunteerBtn.IsVisible)
        {
            // If more than one item is selected, present message and deselect items
            if (NeglectedAnimals.SelectedItems.Count > 1)
            {
                MessageBox.Show("Please select one Pet at a time.");
                NeglectedAnimals.UnselectAll();
            }
            else
            {
                // Reset all text blocks to empty and hide them
                MessageBox.Show("Assigned to volunteer!");
                AssignPetToVolunteerBtn.Visibility = Visibility.Hidden;
                NeglectedAnimals.SelectedItems.Remove(NeglectedAnimals.SelectedCells);
                Switcher.IsPetNeglected = false;
                if (NeglectedAnimals.Items.IsEmpty)
                {
                    Switcher.RedirectStaffPortal();
                    Close();
                }
            }
            
        }
    }

    /// <summary>
    /// Handles selection of Pet 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGV_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        AssignPetToVolunteerBtn.Visibility = Visibility.Visible;
        
        // If no items are selected, hide button
        if (NeglectedAnimals.SelectedItems.Count == 0)
        {
            AssignPetToVolunteerBtn.Visibility = Visibility.Hidden;
        }
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