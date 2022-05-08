using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class VolunteerMyPets
{
    public VolunteerMyPets()
    {
        InitializeComponent();
        PetId.Content = "Pet ID: " + Switcher.PetId;
        SqlConnection sqlConnection = new SqlConnection(Switcher.ConnectionString);
        try
        {
            sqlConnection.Open();
            string petName = "Select PetName From QRbertDB.QRbertTables.Pet Where PetID = '" + 
                             Switcher.PetId + "';";
            SqlCommand sqlCommandForPetName = new SqlCommand(petName, sqlConnection);
            PetName.Content = sqlCommandForPetName.ExecuteScalar().ToString();
            sqlCommandForPetName.Dispose();
            
            string petBreed = "Select Breed  From QRbertDB.QRbertTables.Pet Where PetID = '" + Switcher.PetId + "';";
            SqlCommand sqlCommandForBreedType = new SqlCommand(petBreed, sqlConnection);
            BreedType.Content = sqlCommandForBreedType.ExecuteScalar().ToString();
            sqlCommandForBreedType.Dispose();
            
            string petDOB = "Select DOB From QRbertDB.QRbertTables.Pet Where PetID = '" + Switcher.PetId + "';";
            SqlCommand sqlCommandForDob = new SqlCommand(petDOB, sqlConnection);
            Dob.Content = sqlCommandForDob.ExecuteScalar().ToString();
            sqlCommandForDob.Dispose();
        }
        catch (SqlException sqlException)
        {
            MessageBox.Show(sqlException.Message);
        }
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
    /// Redirects user to pet reports window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetReportsBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        this.Close();
    }
    
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

    /// <summary>
    /// Redirects user to the View Pet Breed info for Volunteers via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewPetBreedInfoBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerPetBreedInfo());
        Close();
    }
}