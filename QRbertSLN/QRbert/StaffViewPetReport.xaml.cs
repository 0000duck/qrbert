using System.Windows;

namespace QRbert;

public partial class StaffViewPetReport : Window
{
    public StaffViewPetReport()
    {
        InitializeComponent();
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
    /// Redirects user to Pet Report window via button click after giving a pet ID
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffViewPetReportViewerBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffPetReportViewer());
        this.Close();
    }

    /// <summary>
    /// Allows user to open camera and scan QR code which is decoded and passed to the database for verification
    /// The user is then redirected to the PDF viewer window to view the pet report
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetSearchViaQRCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        QRCodeScanner.DecodeQRCode();
        // Have to get result string and verify in database that it is correct
        /* 
        if (QRCodeScanner.result is in the database) 
        */
        {
            Switcher.StaffPageSwitch(new StaffPetReportViewer());
            this.Close();
        }
    }
}