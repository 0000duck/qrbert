using System.Windows;

namespace QRbert;

public partial class StaffMyPets : Window
{
    public StaffMyPets()
    {
        InitializeComponent();
        // Loads information when windows loads
        PetId.Text = Switcher.PetId.ToString();
        PetName.Content =
                Switcher.VerifyRole("SELECT PetName From QRbertDB.QRbertTables.Pet where PetID = '" + PetId + "''");
        BreedType.Text =
                Switcher.VerifyRole("SELECT Breed From QRbertDB.QRbertTables.Pet where PetID = '" + PetId + "'");
        DOB.Text =
                Switcher.VerifyRole("SELECT DOB From QRbertDB.QRbertTables.Pet where PetID = '" + PetId + "'");
    }
    private void NotificationBtn_Click(object sender, RoutedEventArgs e)
    {
        
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
    /// Redirects user to Add Pet Treatment window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddPetTreatmentBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new AddPetTreatment());
        this.Close();
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
}