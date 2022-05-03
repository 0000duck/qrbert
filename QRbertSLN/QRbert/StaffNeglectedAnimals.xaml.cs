using System;
using System.Windows;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using BitMiracle.Docotic.Pdf;

namespace QRbert;

public partial class StaffNeglectedAnimals : Window
{
    public StaffNeglectedAnimals()
    {
        
        InitializeComponent();
        Switcher.PetId =
            Int32.Parse(Switcher.VerifyRole(
                "Select PetID From QRbertDB.QRbertTables.Pet_Activity where Activity_Date >= (SYSDATETIME() + 24)"));
        PetIdTxtBl.Text = Switcher.PetId.ToString();
        PetNameTxtBl.Text =
            Switcher.VerifyRole("Select PetName from QRbertDB.QRbertTables.Pet where PetID = '" + Switcher.PetId + "'");
        PetTypeTxtBl.Text =
            Switcher.VerifyRole("Select Type from QRbertDB.QRbertTables.Pet where PetID = '" + Switcher.PetId + "'");
        PetIdTxtBl.Visibility = Visibility.Visible;
        PetNameTxtBl.Visibility = Visibility.Visible;
        PetTypeTxtBl.Visibility = Visibility.Visible;
        PetNeglectedChoiceRadBtn.Visibility = Visibility.Visible;
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
        if (AssignPetToVolunteerBtn.IsVisible)
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
        }
    }

    /// <summary>
    /// Checks if Radio button has been checked to make assign button visible
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void IsPetRadBtnChecked(object sender, RoutedEventArgs e)
    {
        if (PetNeglectedChoiceRadBtn.IsChecked == true)
        {
            AssignPetToVolunteerBtn.Visibility = Visibility.Visible;
        }
    }
}