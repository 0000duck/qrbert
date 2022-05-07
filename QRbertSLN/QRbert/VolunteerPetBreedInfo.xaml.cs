using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

public partial class VolunteerPetBreedInfo : Window
{
    public string[] breedType = new string[2];
    
    public VolunteerPetBreedInfo()
    {
        InitializeComponent();
        int petID = Switcher.PetId;
        petID = 806;
        breedType[0] = "For this cat, DO NOT GIVE IT CATNIP...not worth.";
        breedType[1] = "For this dog, make sure you take it on for walks otherwise it will get fat...like obese.";
        using SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
        sqlCon.Open();
        string petBreed = "SELECT QRbertDB.QRbertTables.Pet.Type from QRbertDB.QRbertTables.Pet where PetID == petID"; //THis is where the query goes
        SqlCommand sqlCmd = new SqlCommand(petBreed, sqlCon);
        //sqlCmd.ExecuteNonQuery();
        //PetBreedLabel.Content = (string)sqlCmd.ExecuteScalar();
        //MessageBox.Show((string)PetBreedLabel.Content);
        if (petBreed == "Cat")
        {
            PetBreedText.Text = breedType[0];
        }
        else
        {
            PetBreedText.Text = breedType[1];
        }
        //save bredd info using 
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
    /// Returns user to their MyPets page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ReturnToMyPets_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}