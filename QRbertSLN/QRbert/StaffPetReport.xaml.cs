using System.Windows;

namespace QRbert;

public partial class StaffPetReport : Window
{
    public StaffPetReport()
    {
        InitializeComponent();
        Switcher.StaffPetReportSwitcher = this;
    }
    
    /// <summary>
    /// Public function that allows to navigate to the next desired page
    /// </summary>
    /// <param name="nextPage">
    /// Type Page, represents the next page to redirect to
    /// </param>
    public void Navigate(Window nextWindow)
    {
        nextWindow.Show();
        this.Close();
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
    /// Redirects staff user to View Pet Report window via button click and closes the current window
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffViewPetReportBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPetReportSwitch(new StaffViewPetReport());
        this.Close();
    }

    /// <summary>
    /// Redirects staff user to Create Pet Report window via button click and closes the current window
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffCreatePetReportBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPetReportSwitch(new StaffCreatePetReport());
        this.Close();
    }
}