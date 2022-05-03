using System.Data;
using System.Data.SqlClient;
using System.Windows;

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
        PetIdLabel.Content = Switcher.PetId.ToString();
        string petName =
            Switcher.VerifyRole("Select PetName From QRbertDB.QRbertTables.Pet Where PetID = '" + Switcher.PetId + "'");
        string date =
            Switcher.VerifyRole("Select Activity_Date From QRbertDB.QRbertTables.Pet_Activity Where PetID = '" + Switcher.PetId + "'");
        PetNameLabel.Content = petName;
        IncidentDateLabel.Content = date;
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
    /// Adds New Pet Treatment to the Pet Treatment table via button click
    /// Redirects user to My Pets page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddPetTreatmentBtn_Click(object sender, RoutedEventArgs e)
    {
        SqlCommand sqlCmd = new SqlCommand("AddPetTreatment", new SqlConnection(Switcher.ConnectionString));
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.AddWithValue("@PetName", PetNameLabel.Content.ToString());
        sqlCmd.Parameters.AddWithValue("@PetID", PetIdLabel.Content.ToString());
        sqlCmd.Parameters.AddWithValue("@Incident_Date", IncidentDateLabel.Content.ToString());
        sqlCmd.Parameters.AddWithValue("@InjuryType", InjuryTypeTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Recovered_Date", RecoveredDateTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Vet_Assign", VetAssignedTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Rx", RxTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Notes", NotesTxt.Text);

        sqlCmd.ExecuteNonQuery();
        MessageBox.Show("Successfully saved Pet Treatment.");
        Switcher.StaffPageSwitch(new StaffMyPets());
        this.Close();
    }
}