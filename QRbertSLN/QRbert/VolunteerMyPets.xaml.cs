using System.Windows;

namespace QRbert;

public partial class VolunteerMyPets : Window
{
    public VolunteerMyPets()
    {
        InitializeComponent();
    }
    private void NotificationBtn_Click(object sender, RoutedEventArgs e) {}
    private void HomeStaffPortalBtn_Click(object sender, RoutedEventArgs e) {}
    private void ViewTimesheetBtn_Click(object sender, RoutedEventArgs e) {}
    private void ScanPetQRCodeBtn_Click(object sender, RoutedEventArgs e) {}
    private void PetReportBtn_Click(object sender, RoutedEventArgs e) {}
    private void VolunteerMyAcctBtn_Click(object sender, RoutedEventArgs e) {}
    private void LogOutBtn_Click(object sender, RoutedEventArgs e) {}
    
    private void AddPetBtn_Click(object sender, RoutedEventArgs e) {}
    
    /// <summary>
    /// Redirects user to the FAQ window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FAQRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerFAQs());
        Close();
    }
}