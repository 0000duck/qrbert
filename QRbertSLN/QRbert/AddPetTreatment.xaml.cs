using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class AddPetTreatment
{
    /// <summary>
    /// Upon loading the page, Window checks if boolean is true to turn on Bell Icon
    /// </summary>
    public AddPetTreatment()
    {
        InitializeComponent();
        // Load Pet ID, Pet Name, and current Date when Window loads
        PetId.Content = "Pet ID: " + Switcher.PetId;
        SqlConnection sqlConnection = new SqlConnection(Switcher.ConnectionString);
        sqlConnection.Open();
        try
        {
            string petName = "Select PetName From QRbertDB.QRbertTables.Pet Where PetID = '" + 
                             Switcher.PetId + "';";
            string PetNum = "Select PetID From QRbertDB.QRbertTables.Pet Where PetID = '" + 
                            Switcher.PetId + "';";
            SqlCommand sqlCommandForPetName = new SqlCommand(petName, sqlConnection);
            PetName.Content = sqlCommandForPetName.ExecuteScalar().ToString();
            sqlCommandForPetName.Dispose();
            
            SqlCommand sqlCommandForPetID = new SqlCommand(PetNum, sqlConnection);
            PetId.Content = sqlCommandForPetID.ExecuteScalar().ToString();
            sqlCommandForPetID.Dispose();
        }
        catch (SqlException sqlException)
        {
            MessageBox.Show(sqlException.Message);
        }
        if (Switcher.IsPetNeglected)
        {
            AlertStaffBellIcon.Visibility = Visibility.Visible;
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
    /// Adds New Pet Treatment to the Pet Treatment table via button click
    /// Redirects user to My Pets page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddPetTreatmentBtn_Click(object sender, RoutedEventArgs e)
    {
        using SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand("PetTreatment", sqlCon);
        string pID =  Switcher.VerifyRole("Select PetId From QRbertDB.QRbertTables.Pet Where PetID = '" + 
                                          Switcher.PetId + "';");
        string pName =  Switcher.VerifyRole("Select PetName From QRbertDB.QRbertTables.Pet Where PetID = '" + 
                                            Switcher.PetId + "';");
        
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.AddWithValue("@PetID", pID);
        sqlCmd.Parameters.AddWithValue("@PetName", pName);
        sqlCmd.Parameters.AddWithValue("@InjuryType", InjuryTypeTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Incident_Date", IncidentDatePicker.SelectedDate.GetValueOrDefault().Date.ToString());
        sqlCmd.Parameters.AddWithValue("@Recovered_Date", RecoveredDatePicker.SelectedDate.GetValueOrDefault().Date.ToString());
        sqlCmd.Parameters.AddWithValue("@Vet_Assign", VetAssignedTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Rx", RxTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Notes", NotesTxt.Text);
        /*
        string petName =
            Switcher.VerifyRole(
                "Select QRbertDB.QRbertTables.Pet.PetName from QRbertDB.QRbertTables.Pet where PetID = '" +
                Switcher.PetId + "'");
        SqlCommand sqlCmd = new SqlCommand("AddPetTreatment", new SqlConnection(Switcher.ConnectionString));
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.AddWithValue("@PetName", petName);
        sqlCmd.Parameters.AddWithValue("@PetID", Switcher.PetId.ToString());
        sqlCmd.Parameters.AddWithValue("@Incident_Date", IncidentDatePicker.SelectedDate.GetValueOrDefault().Date.ToString());
        sqlCmd.Parameters.AddWithValue("@InjuryType", InjuryTypeTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Recovered_Date", RecoveredDatePicker.SelectedDate.GetValueOrDefault().Date.ToString());
        sqlCmd.Parameters.AddWithValue("@Vet_Assign", VetAssignedTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Rx", RxTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Notes", NotesTxt.Text);
*/
        sqlCmd.ExecuteNonQuery();
        MessageBox.Show("Successfully saved Pet Treatment.");
        Switcher.StaffPageSwitch(new StaffViewPetTreatment());
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

    private void InjuryTypeTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtInjuryTypeBlock.Visibility = Visibility.Visible;
        if (InjuryTypeTxt.Text.Length > 0)
        {
            txtInjuryTypeBlock.Visibility = Visibility.Hidden;
        }
    }

    private void RecoveredDateTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtRecoveredDateBlock.Visibility = Visibility.Visible;
        if (RecoveredDateTxt.Text.Length > 0)
        {
            txtRecoveredDateBlock.Visibility = Visibility.Hidden;
        }
    }

    private void VetAssignedTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtVetAssignedBlock.Visibility = Visibility.Visible;
        if (VetAssignedTxt.Text.Length > 0)
        {
            txtVetAssignedBlock.Visibility = Visibility.Hidden;
        }
    }

    private void RxTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtRxBlock.Visibility = Visibility.Visible;
        if (RxTxt.Text.Length > 0)
        {
            txtRxBlock.Visibility = Visibility.Hidden;
        }
    }

    private void NotesTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtNotesBlock.Visibility = Visibility.Visible;
        if (NotesTxt.Text.Length > 0)
        {
            txtNotesBlock.Visibility = Visibility.Hidden;
        }
    }
}