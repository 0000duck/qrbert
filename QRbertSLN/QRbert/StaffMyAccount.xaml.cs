using System.Configuration;
using System.Windows;

namespace QRbert;

public partial class StaffMyAccount
{
    /// <summary>
    /// Upon loading the page, Window checks if boolean is true to turn on Bell Icon
    /// </summary>
    public StaffMyAccount()
    {
        InitializeComponent();
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
        if (AlertStaffBellIcon.Visibility == Visibility.Hidden)
        {
            // do nothing
        }
        else
        {
            // At least one Pet is Neglected
            // Means that Switcher.IsPetNeglected = true
            Switcher.StaffPageSwitch(new StaffNeglectedAnimals());
            this.Close();
        }
    }
    
    /// <summary>
    /// Redirects Staff to the ChangeEmail page via a button click
    /// Since this and the ChangeEmail are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffChangeEmailBtn_Click(object sender, RoutedEventArgs e)
    {
        // Window redirectStaffToChangeEmail = new StaffChangeEmail();
        // this.Content = redirectStaffToChangeEmail;
        Switcher.StaffPageSwitch(new StaffChangeEmail());
        this.Close();
    }

    /// <summary>
    /// Redirects staff to change their password page via a button click
    /// Since this page and the ChangePassword are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffChangePasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffChangePassword());
        this.Close();
    }

    /// <summary>
    /// I don't know what the difference is and I put a messagebox to reflect my confusion
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffForgotPasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffForgotPassword());
        this.Close();
    }

    /// <summary>
    /// Redirects staff to the ChangePersonalInfo page via a button click
    /// Since the current page and the ChangePersonalInfo page are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffChangePersonalInfoBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffChangePersonalInfo());
        this.Close();
    }
    
    /// <summary>
    /// Logs out staff user and takes them to the Log In Page
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
}