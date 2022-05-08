using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace QRbert;

public partial class AddPetActivity
{
    public string StaffId = "";
    /// <summary>
    /// Upon loading the page, Window checks if boolean is true to turn on Bell Icon
    /// </summary>
    public AddPetActivity()
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
            string date = "Select Reg_Date From QRbertDB.QRbertTables.Pet Where PetID = '" + 
                          Switcher.PetId + "';";
            SqlCommand sqlCommandForPetName = new SqlCommand(petName, sqlConnection);
            PetName.Content = sqlCommandForPetName.ExecuteScalar().ToString();
            sqlCommandForPetName.Dispose();
            SqlCommand sqlCommandForDate = new SqlCommand(date, sqlConnection);
            ActivityDate.Content = sqlCommandForDate.ExecuteScalar().ToString();
            sqlCommandForDate.Dispose();
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
    /// Adds Pet Activity to the Pet Activity Table via button click
    /// Redirects user to My Pets page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddPetActivityBtn_Click(object sender, RoutedEventArgs e)
    {
        SqlCommand sqlCmd = new SqlCommand("AddPetActivity", new SqlConnection(Switcher.ConnectionString));
        sqlCmd.Connection.Open();
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.AddWithValue("@PetName", PetName.Content.ToString());
        sqlCmd.Parameters.AddWithValue("@PetID", PetId.Content.ToString());
        sqlCmd.Parameters.AddWithValue("@Activity_Date", ActivityDatePicker.SelectedDate.GetValueOrDefault().Date.ToString());
        sqlCmd.Parameters.AddWithValue("@WaterGiven", WaterGivenTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Clean_Kennel", CleanKennelTxt.Text);
        sqlCmd.Parameters.AddWithValue("@Food_Given", FoodGivenTxt.Text);
        sqlCmd.Parameters.AddWithValue("@ID", StaffIdTxt.Text);

        sqlCmd.ExecuteNonQuery();
        MessageBox.Show("Successfully saved New Pet Activity.");
        Switcher.StaffPageSwitch(new StaffTrackAnimalActivity());
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

    private void WaterGivenTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtWaterGivenBlock.Visibility = Visibility.Visible;
        if (WaterGivenTxt.Text.Length > 0)
        {
            txtWaterGivenBlock.Visibility = Visibility.Hidden;
        }    
    }

    private void CleanKennelTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtCleanKennelBlock.Visibility = Visibility.Visible;
        if (CleanKennelTxt.Text.Length > 0)
        {
            txtCleanKennelBlock.Visibility = Visibility.Hidden;
        }   
    }

    private void FoodGivenTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        FoodGivenTxtBlock.Visibility = Visibility.Visible;
        if (FoodGivenTxt.Text.Length > 0)
        {
            FoodGivenTxtBlock.Visibility = Visibility.Hidden;
        }
    }


    private void StaffIdTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
    }
        
    private void FoodGivenTxt_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtFoodGivenBlock.Visibility = Visibility.Visible;
        if (FoodGivenTxt.Text.Length > 0)
        {
            txtFoodGivenBlock.Visibility = Visibility.Hidden;
        }
    }
}