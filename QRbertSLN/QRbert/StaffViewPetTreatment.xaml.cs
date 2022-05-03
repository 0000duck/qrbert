using System.Windows;

namespace QRbert;

public partial class StaffViewPetTreatment : Window
{
    public StaffViewPetTreatment()
    {
        InitializeComponent();
    }
    private void NotificationBtn_Click(object sender, RoutedEventArgs e)
    {
        
    }
    private void HomeStaffPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }
    private void LockTimesheetsBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }
    private void RoundingRulesBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }
    private void TrackActiveVolunteersBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }
    private void StaffSearchBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }
    private void ScanPetQRCodeRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }
    private void PetReportsBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }
    private void StaffMyAccountBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }
}