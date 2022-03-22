using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
//using System.Windows.Interactivity
using Microsoft.Xaml.Behaviors;



//using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;


namespace QRbert;

public partial class Register : Page
{
    /*
     * connects DB to Register Page
     * Data source is the name of the DB server
     * Initial Catalog the QRbert database we want to connect to
     * User name and Password -> temp log in solution until we find a more secure way to log into the DB
     * so that the log in credentials aren't in the code for all to see
     */ 
  String connectionString = @"Data Source = qrbert-rds1.cfe8s1xr87h2.us-west-1.rds.amazonaws.com; 
                                Initial Catalog = QRbertDB; User ID = rds1_admin; Password = rds1_admin;";


    public Register()
    {
        InitializeComponent();
    }


    private void runSignUp(object sender, RoutedEventArgs e)
    {
        
        //Console.WriteLine("Here");
        /*bool firstNameCheck = isFirstNameValid(RegFirst.Text);
        if (firstNameCheck)
        {
            //accept the sign up form
            MessageBox.Show("Good to submit");
        }
        else
        {
            //reload page and show what needs to be changed
            MessageBox.Show("Not good to submit");
        }*/
        MessageBox.Show(Password.Password);
    }
    
    public static bool isFirstNameValid(string text)
    {
        return checkString(text);

    }

    public static bool isLastNameValid(string text)
    {
        return checkString(text);
    }

    public static bool isEmailValid(string text)
    {
        return IsValidEmail(text);
    }

    public static bool isLicenseValid(string text)
    {
        return checkString(text);
    }

    public static bool isAddressValid(string text)
    {
        return checkString(text);
    }

    public static bool isCityValid(string text)
    {
        return checkString(text);
    }
    public static bool isStateValid(string text)
    {
        return checkString(text);
    }

    public static bool isZipCodeValid(string text)
    {
        return checkString(text);
        //possibly add a range check for zipcode
    }

    public static bool checkString(string words)
    {
        if (words == null || words == "")
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }
    public static bool isPresent(string textBox, string textBoxName)
    {
        if (textBox == null || textBox == "")
        {
            MessageBox.Show(textBoxName + " is required.");
            //textBox.Focus();
            return false;
        }

        return true;
    }
    public static bool isDecimal(string textBox)
    {
        decimal number = 0m;
        if (Decimal.TryParse(textBox, out number))
        {
            return true;
        }
        else
        {
            MessageBox.Show(textBox + " must be a decimal value.");
            //textBox.Focus();
            return false;
        }
    }

    public static bool IsInt32(string textBox)
    {
        int number = 0;
        if (Int32.TryParse(textBox, out number))
        {
            return true;
        }
        else
        {
            MessageBox.Show(textBox + " must be an integer.");
            //textBox.Focus();
            return false;
        }
    }

    public static bool IsWithinRange(string textBox, decimal min, decimal max)
    {
        //decimal number = Convert.ToDecimal(textBox.Text);

        int number = textBox.Length;

        if (number < min || number > max)
        {
            MessageBox.Show(textBox + " must be between " + min
                            + " and " + max + ".");
            //textBox.Focus();
            return false;
        }
        return true;
    }

    //checks to see if it has the right symbols in the textbox
    public static bool IsValidEmail(string textBox)
    {
        if (textBox.IndexOf("@") == -1 ||
            textBox.IndexOf(".") == -1)
        {
            //MessageBox.Show(textBox + " must be a valid email address.");
            //textBox.Focus();
            return false;
        }
        else
        {
            return true;
        }
        
    }

    private void clearFirstName(object sender, RoutedEventArgs e)
    {
        
    }
    public void RemoveText(object sender, EventArgs e)
    {
        if (txtFirstName.Text == "Enter text here...") 
        {
            txtFirstName.Text = "";
        }
    }

    public void AddText(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            txtFirstName.Text = "Enter text here...";
    }
    
    // Link the "sign Up" button to DB to save user registration info
    private void RegUser_Button(object sender, EventArgs e)
    {
        // make sure mandatory fields are typed in
        //Made minor adjustment to the if statement (isValidEmail)
        if (!IsValidEmail(txtEmail.Text) || Password.Password == "")
            MessageBox.Show("Please fill out all mandatory fields");
        else if (Password.Password != ConfirmPassword.Password)
            MessageBox.Show("Passwords Do Not Match");
        else
        {
            using SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            
            // User Input stored in Registration table 
            SqlCommand sqlCmd = new SqlCommand("RegUser", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlCmd.Parameters.AddWithValue("@Password", ConfirmPassword.Password);
            sqlCmd.Parameters.AddWithValue("@Faculty_Role", txtFacultyRole.Text);
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text);

            SqlCommand contact = new SqlCommand("Contact", sqlCon);
            contact.CommandType = CommandType.StoredProcedure;
            contact.Parameters.AddWithValue("@Email", txtEmail.Text);
            contact.Parameters.AddWithValue("@Password", ConfirmPassword.Password);
            contact.Parameters.AddWithValue("@Faculty_Role", txtFacultyRole.Text);
            contact.Parameters.AddWithValue("@Street", txtAddress.Text);
            contact.Parameters.AddWithValue("@City", City.Text);
            contact.Parameters.AddWithValue("@State", State.Text);
            contact.Parameters.AddWithValue("@ZipCode", txtZipcode.Text);
            contact.Parameters.AddWithValue("@PhoneNum", txtPhone.Text);
            contact.Parameters.AddWithValue("@DL_ID", txtDriver.Text);
            
            sqlCmd.ExecuteNonQuery(); 
            contact.ExecuteNonQuery();

            MessageBox.Show("Sign Up Complete ");
        }
    }

    /*private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (Password.Password.Length == 0)
            Password.Background.Opacity = 1;
        else
            Password.Background.Opacity = 0;
    }
    */
    private void FacultyRole_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        txtFacultyRoleBlock.Visibility = Visibility.Visible;
        if (txtFacultyRole.Text.Length > 0)
        {
            txtFacultyRoleBlock.Visibility = Visibility.Hidden;
        }
    }
    private void txtFirstNameBlock_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        txtFirstNameBlock.Visibility = Visibility.Visible;
        if (txtFirstName.Text.Length > 0)
        {
            txtFirstNameBlock.Visibility = Visibility.Hidden;
        }
    }
    private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        
        txtHintPassword.Visibility = Visibility.Visible;
        if (Password.Password.Length > 0)
        {
            txtHintPassword.Visibility = Visibility.Hidden;
        }
    }
    void PrintText(object sender, SelectionChangedEventArgs args)
    {
        ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
        MessageBox.Show("You selected " + lbi.Content.ToString() + ".");
    }

    private void ConfirmPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        txtHintConfirmPassword.Visibility = Visibility.Visible;
        if (ConfirmPassword.Password.Length > 0)
        {
            txtHintConfirmPassword.Visibility = Visibility.Hidden;
        }
    }

    private void TxtLastName_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtLastNameBlock.Visibility = Visibility.Visible;
        if (txtLastName.Text.Length > 0)
        {
            txtLastNameBlock.Visibility = Visibility.Hidden;
        }
        
    }

    private void TxtEmail_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtEmailBlock.Visibility = Visibility.Visible;
        if (txtEmail.Text.Length > 0)
        {
            txtEmailBlock.Visibility = Visibility.Hidden;
        }
    }

    private void TxtDriver_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtDriverBlock.Visibility = Visibility.Visible;
        if (txtDriver.Text.Length > 0)
        {
            txtDriverBlock.Visibility = Visibility.Hidden;
        }
    }

    private void TxtAddress_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtAddressBlock.Visibility = Visibility.Visible;
        if (txtAddress.Text.Length > 0)
        {
            txtAddressBlock.Visibility = Visibility.Hidden;
        }
    }

    private void City_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtCityBlock.Visibility = Visibility.Visible;
        if (City.Text.Length > 0)
        {
            txtCityBlock.Visibility = Visibility.Hidden;
        }
    }

    private void State_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtStateBlock.Visibility = Visibility.Visible;
        if (State.Text.Length > 0)
        {
            txtStateBlock.Visibility = Visibility.Hidden;
        }
    }
    private void TxtPhone_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtPhoneBlock.Visibility = Visibility.Visible;
        if (txtPhone.Text.Length > 0)
        {
            txtPhoneBlock.Visibility = Visibility.Hidden;
        }
    }

    private void TxtZipcode_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtZipcode.Visibility = Visibility.Visible;
        if (txtZipcode.Text.Length > 0)
        {
            txtZipcodeBlock.Visibility = Visibility.Hidden;
        }
    }
}
/*public class PasswordBoxMonitor : DependencyObject {
    public static bool GetIsMonitoring(DependencyObject obj) {
        return (bool)obj.GetValue(IsMonitoringProperty);
    }

    public static void SetIsMonitoring(DependencyObject obj, bool value) {
        obj.SetValue(IsMonitoringProperty, value);
    }

    public static readonly DependencyProperty IsMonitoringProperty =
        DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(PasswordBoxMonitor), new UIPropertyMetadata(false, OnIsMonitoringChanged));

    public static int GetPasswordLength(DependencyObject obj) {
        return (int)obj.GetValue(PasswordLengthProperty);
    }

    public static void SetPasswordLength(DependencyObject obj, int value) {
        obj.SetValue(PasswordLengthProperty, value);
    }

    public static readonly DependencyProperty PasswordLengthProperty =
        DependencyProperty.RegisterAttached("PasswordLength", typeof(int), typeof(PasswordBoxMonitor), new UIPropertyMetadata(0));

    private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        var pb = d as PasswordBox;
        if (pb == null) {
            return;
        }
        if ((bool) e.NewValue) {
            pb.PasswordChanged += PasswordChanged;
        } else {
            pb.PasswordChanged -= PasswordChanged;
        }
    }

    static void PasswordChanged(object sender, RoutedEventArgs e) {
        var pb = sender as PasswordBox;
        if (pb == null) {
            return;
        }
        SetPasswordLength(pb, pb.Password.Length);
    }
}
*/
//public class PasswordBoxWatermarkBehavior : System.Windows.Interactivity.Behavior<PasswordBox>



    