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
            ("Select PetName, PetID, Activity_Date from QRbertDB.QRbertTables.Pet_Activity where Activity_Date >= (SYSDATETIME() - 24) ");
        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        sqlCmd.ExecuteNonQuery();
        SqlDataAdapter adpt = new SqlDataAdapter(sqlCmd);
        DataTable dtable = new DataTable("QRbertDB.QRbertTables.Pet_Activity");
        adpt.Fill(dtable);
        DataGV.ItemsSource = dtable.DefaultView;
        adpt.Update(dtable);
        
        
        // Switcher.PetId = Int32.Parse(Switcher.VerifyRole("Select PetID From QRbertDB.QRbertTables.Pet_Activity where Activity_Date >= (SYSDATETIME() + 24)"));
        // PetIdTxtBl.Text = Switcher.PetId.ToString();
        // PetNameTxtBl.Text =
        //     Switcher.VerifyRole("Select PetName from QRbertDB.QRbertTables.Pet where PetID = '" + Switcher.PetId + "'");
        // PetTypeTxtBl.Text =
        //     Switcher.VerifyRole("Select Type from QRbertDB.QRbertTables.Pet where PetID = '" + Switcher.PetId + "'");
        // PetIdTxtBl.Visibility = Visibility.Visible;
        // PetNameTxtBl.Visibility = Visibility.Visible;
        // PetTypeTxtBl.Visibility = Visibility.Visible;
        
        // PetNeglectedChoiceRadBtn.Visibility = Visibility.Visible;
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
    /// Assigns Neglected Pet to volunteer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AssignPetToVolunteer(object sender, RoutedEventArgs e)
    {
        /*if (AssignPetToVolunteerBtn.IsVisible)
        {
            // Reset all text blocks to empty and hide them
            MessageBox.Show("Assigned to volunteer!");
            PetIdTxtBl.Text = "";
            PetIdTxtBl.Visibility = Visibility.Hidden;
            PetNameTxtBl.Text = "";
            PetIdTxtBl.Visibility = Visibility.Hidden;
            PetTypeTxtBl.Text = "";
            PetTypeTxtBl.Visibility = Visibility.Hidden;
            PetNeglectedChoiceRadBtn.IsChecked = false;
            PetNeglectedChoiceRadBtn.Visibility = Visibility.Hidden;
            AssignPetToVolunteerBtn.Visibility = Visibility.Hidden;
            Switcher.IsPetNeglected = false;
            Switcher.StaffPageSwitch(new TrackActiveVolunteers());
            this.Close();
        }*/
        MessageBox.Show("Assigned to Volunteer!");
        DataGV.SelectedCells.Clear();
    }

    /// <summary>
    /// Checks if Radio button has been checked to make assign button visible
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // private void IsPetRadBtnChecked(object sender, RoutedEventArgs e)
    // {
    //     if (PetNeglectedChoiceRadBtn.IsChecked == true)
    //     {
    //         AssignPetToVolunteerBtn.Visibility = Visibility.Visible;
    //     }
    // }

    /// <summary>
    /// Handles selected items in DataGrid
    /// If more than one item is selected, will show a message box that can only assign one pet at a time
    /// Deselects pets for them
    /// Makes Assign to Volunteer btn Visible to assign the pet
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGV_OnSelected(object sender, RoutedEventArgs e)
    {
        
    }

    private void DataGV_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        AssignPetToVolunteerBtn.Visibility = Visibility.Visible;
        // If more than one item is selected, present message and deselect items
        if (DataGV.SelectedItems.Count > 1)
        {
            MessageBox.Show("Please select one Pet at a time.");
            DataGV.UnselectAll();
        }
        // If no items are selected, hide button
        if (DataGV.SelectedItems.Count == 0)
        {
            AssignPetToVolunteerBtn.Visibility = Visibility.Hidden;
        }
    }
}