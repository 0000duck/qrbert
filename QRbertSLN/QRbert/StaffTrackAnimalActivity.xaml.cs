using System;
using System.Data;
using System.Windows;
using System.Data.SqlClient;

namespace QRbert;

public partial class StaffTrackAnimalActivity 
{
    public StaffTrackAnimalActivity()
    {
        InitializeComponent();
        PetNameTxt.Text =
            Switcher.VerifyRole("Select PetName from QRbertDB.QRbertTables.Pet where PetID = '" +
                                Switcher.PetId + "'");
        SqlConnection sqlConnection = new SqlConnection(Switcher.ConnectionString);
        try
        {
            sqlConnection.Open();
            string query = "Select * From QRbertDB.QRbertTables.Pet_Activity Where PetName = '" + PetNameTxt.Text +
                           "';";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable("Pet Activity");
            sqlDataAdapter.Fill(dataTable);
            DataGV.ItemsSource = dataTable.DefaultView;
            sqlDataAdapter.Update(dataTable);
        }
        catch (SqlException sqlException)
        {
            MessageBox.Show(sqlException.Message);
        }
        finally
        {
            sqlConnection.Close();
        }
        
        if (Switcher.IsPetNeglected)
        {
            AlertStaffBellIcon.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Adds a 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetActivityBtn(object sender, EventArgs e)
    {
        using SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
        sqlCon.Open();
        string query =  ("Select * From QRbertDB.QRbertTables.Pet_Activity Where PetName = '" + PetNameTxt.Text + "'");
        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        sqlCmd.ExecuteNonQuery();

        SqlDataAdapter adpt = new SqlDataAdapter(sqlCmd);
        DataTable dtable = new DataTable("QRbertDB.QRbertTables.Pet_Activity");

        adpt.Fill(dtable);
        DataGV.ItemsSource = dtable.DefaultView;
        adpt.Update(dtable);
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
    /// Redirects user to Add Pet Activity window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddPetActivityBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new AddPetActivity());
        this.Close();
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