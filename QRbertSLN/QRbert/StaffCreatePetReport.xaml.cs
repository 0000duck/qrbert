using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Media;

namespace QRbert;

public partial class StaffCreatePetReport : Window
{
    /// <summary>
    /// Upon loading the page, Window checks if boolean is true to turn on Bell Icon
    /// </summary>
    public StaffCreatePetReport()
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
        if (AlertStaffBellIcon.IsVisible) 
        {
            // At least one Pet is Neglected
            // Means that Switcher.IsPetNeglected = true
            Switcher.StaffPageSwitch(new StaffNeglectedAnimals());
            this.Close();
        }
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
    /// Redirects user to the FAQ window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FAQRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffFAQs());
        Close();
    }
    
    /// <summary>
    /// Creates Pet in DB and redirects user to MyPets page for staff
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CreatePet_Button(object sender, RoutedEventArgs e)
    {
        using SqlConnection sqlCon = new SqlConnection(Switcher.ConnectionString);
        sqlCon.Open();
            
        /* User Input stored in Pet table
         * NewPet is the stored procedure created in the DB that inserts data into each row of the Pet table
        */ 
        SqlCommand sqlCmd = new SqlCommand("NewPet", sqlCon);
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.AddWithValue("@PetName", txtPetName.Text);
        sqlCmd.Parameters.AddWithValue("@DOB",txtDOB.Text);
        sqlCmd.Parameters.AddWithValue("@Type", txtType.Text);
        sqlCmd.Parameters.AddWithValue("@Breed", txtBreed.Text);
        sqlCmd.Parameters.AddWithValue("@Gender ", txtGender.Text);
        sqlCmd.ExecuteNonQuery();
        MessageBox.Show("You have Registered a New Pet");
        Switcher.PetId =
           int.Parse(Switcher.VerifyRole(
                "SELECT PetID From QRbertDB.QRbertTables.Pet where PetName = '" + txtPetName.Text + "' and DOB = '" + txtDOB.Text + "'"));
        // Creating the user's QR code and displaying it
        // Saves the email, password, and faculty-role as a string for the QR code, this can be changed later
        string petInfo = Switcher.PetId + " " + txtPetName.Text + " " + txtType.Text;
        DrawingImage qrCodeImage = QRCodeScanner.Generate_QR_Click(petInfo);
        // Creates a new window to display the QR code and shows it
        ShowQRCode showQRCode = new ShowQRCode();
        showQRCode.QRCodeViewer.Source = qrCodeImage;
        showQRCode.QRCodeViewer.Visibility = Visibility.Visible;
        MessageBox.Show("Please save your Pet's QR Code.");
        showQRCode.Show();  // Show QR Code
        Switcher.RedirectStaffPortal();     // redirects you to the staff portal
        showQRCode.Topmost = true;
        Close();   // close create pet page
    }
    
    /// <summary>
    /// Redirects user to Staff Terms of Privacy via btn click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TermsOfPrivacyBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffTermsofPrivacy());
        Close();
    }
    
    /// <summary>
    /// Redirects user to Staff Track Animal Activity via btn click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewPetActivityBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffTrackAnimalActivity());
        Close();
    }

    /// <summary>
    /// Redirects user to Staff View Pet Treatment via btn click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewPetTreatmentBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffViewPetTreatment());
        Close();
    }
    
    /// <summary>
    /// Redirects user to Scan Pet QR Code, new function allows Staff to Remove pet via btn click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RemoveAnimalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RemoveAnimal = true;
        Switcher.StaffPageSwitch(new StaffScanPetQrCode());
        Close();
    }

    private void TxtPetName_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtPetNameBlock.Visibility = Visibility.Visible;
        if (txtPetName.Text.Length > 0)
        {
            txtPetNameBlock.Visibility = Visibility.Hidden;
        }    
    }

    private void TxtDOB_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtDOBBlock.Visibility = Visibility.Visible;
        if (txtDOB.Text.Length > 0)
        {
            txtDOBBlock.Visibility = Visibility.Hidden;
        }    
    }

    private void TxtType_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtTypeBlock.Visibility = Visibility.Visible;
        if (txtType.Text.Length > 0)
        {
            txtTypeBlock.Visibility = Visibility.Hidden;
        }    
    }

    private void TxtBreed_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtBreedBlock.Visibility = Visibility.Visible;
        if (txtBreed.Text.Length > 0)
        {
            txtBreedBlock.Visibility = Visibility.Hidden;
        }        
    }

    private void TxtGender_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtGenderBlock.Visibility = Visibility.Visible;
        if (txtGender.Text.Length > 0)
        {
            txtGenderBlock.Visibility = Visibility.Hidden;
        }    }

    
        


    private void TxtWeight_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtWeightBlock.Visibility = Visibility.Visible;
        if (txtWeight.Text.Length > 0)
        {
            txtWeightBlock.Visibility = Visibility.Hidden;
        }
        
    }

    private void TxtColor_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtColorBlock.Visibility = Visibility.Visible;
        if (txtColor.Text.Length > 0)
        {
            txtColorBlock.Visibility = Visibility.Hidden;
        }    
    }
}