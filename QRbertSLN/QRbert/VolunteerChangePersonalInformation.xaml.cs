using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class VolunteerChangePersonalInformation : Window
{
    public VolunteerChangePersonalInformation()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Redirects volunteer user to their MyAccount window via a button click on the menu item
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerMyAcctBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerMyAccount());
        this.Close();
    }

    /// <summary>
    /// Logs out Volunteer and redirects user to the Log In page via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogOutSwitch();
        this.Close();
    }

    /// <summary>
    /// Redirects user to home page - volunteer portal via QRbert image click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeVolunteerPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectVolunteerPortal();
        this.Close();
    }
    
    /// <summary>
    /// Redirects user to view timesheet window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewTimesheetBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerViewTimesheets());
        this.Close();
    }

    /// <summary>
    /// Redirects user to scan pet qr code window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScanPetQRCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        this.Close();
    }

    /// <summary>
    /// Redirects user to pet report window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetReportBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerPetReport());
        this.Close();
    }

    /// <summary>
    /// Saves all personal information via button click
    /// Makes a new connection to the database for every non-empty textbox
    /// Redirects user to the my account page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        using SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
        sqlCon.Open();
        string userType = Switcher.VerifyRole("Select [Faculty-Role] From QRbertTables.Registration Where email = '"
                                              + Switcher.CurrentSessionEmail + "'");
        
        if (AddressInputTxt.Text != "")
        {
            SqlCommand sqlCmd = new SqlCommand(
                "Update Contact_Info Set Street-Add = '" + AddressInputTxt.Text + "' Where Faculty-role = ' " +
                userType + "'", new SqlConnection(Switcher.ConnectionString));
        }

        if (CityInputTxt.Text != "")
        {
            SqlCommand sqlCmd = new SqlCommand(
                "Update Contact_Info Set City ='" + CityInputTxt.Text + "' Where Faculty-role = ' " +
                userType + "'", new SqlConnection(Switcher.ConnectionString));
        }

        if (StateInputTxt.Text != "")
        {
            SqlCommand sqlCmd = new SqlCommand(
                "Update Contact_Info Set State ='" + StateInputTxt.Text + "' Where Faculty-role = ' " +
                userType + "'", new SqlConnection(Switcher.ConnectionString));
        }

        if (ZipcodeInputTxt.Text != "")
        {
            SqlCommand sqlCmd = new SqlCommand(
                "Update Contact_Info Set ZipCode ='" + ZipcodeInputTxt.Text + "' Where Faculty-role = ' " +
                userType + "'", new SqlConnection(Switcher.ConnectionString));
        }
        MessageBox.Show("All information updated.");
        Switcher.VolunteerPortalSwitch(new VolunteerMyAccount());
        this.Close();
    }
}