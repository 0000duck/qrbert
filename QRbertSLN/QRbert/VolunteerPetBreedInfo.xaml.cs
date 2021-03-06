using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class VolunteerPetBreedInfo
{
    public string[] breedType = new string[2];
    
    public VolunteerPetBreedInfo()
    {
        InitializeComponent();
        breedType[0] = "For this cat, DO NOT GIVE IT CATNIP...not worth.";
        breedType[1] = "For this dog, make sure you take it on for walks otherwise it will get fat...like obese.";
        using SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
        sqlCon.Open();
        string petBreed = "SELECT QRbertDB.QRbertTables.Pet.Type from QRbertDB.QRbertTables.Pet where PetID = '" +
                          Switcher.PetId + "'";
        SqlCommand sqlCmd = new SqlCommand(petBreed, sqlCon);
        if (sqlCmd.ExecuteScalar().ToString() == "Cat")
        {
            PetBreedLabel.Content = "Cat";
            PetBreedText.Text = breedType[0];
        }
        else
        {
            PetBreedLabel.Content = "Dog";
            PetBreedText.Text = breedType[1];
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
        Close();
    }

    /// <summary>
    /// Logs out Volunteer and redirects user to the Log In page via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogOutSwitch();
        Close();
    }

    /// <summary>
    /// Redirects user to home page - volunteer portal via QRbert image click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeVolunteerPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectVolunteerPortal();
        Close();
    }
    
    /// <summary>
    /// Redirects user to view timesheet window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewTimesheetBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerViewTimesheets());
        Close();
    }

    /// <summary>
    /// Redirects user to scan pet qr code window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScanPetQRCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        Close();
    }

    /// <summary>
    /// Redirects user to pet reports window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetReportsBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        Close();
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
    /// Returns user to their MyPets page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ReturnToMyPets_OnClick(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerMyPets());
        Close();
    }
}