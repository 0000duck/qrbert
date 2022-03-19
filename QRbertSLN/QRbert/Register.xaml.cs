using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
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

    public static string[] makeStateList()
    {
        string[] stateAbbr = new string[50];
        stateAbbr[0] = "AL"; //Alabama
        stateAbbr[1] = "AK"; //Alaska
        stateAbbr[2] = "AZ"; //Arizona
        stateAbbr[3] = "AR"; //Arkansas
        stateAbbr[4] = "CA"; //California
        stateAbbr[5] = "CO"; //Colorado
        stateAbbr[6] = "CT"; //Connecticut
        stateAbbr[7] = "DE"; //Delaware
        stateAbbr[8] = "FL"; //Florida
        stateAbbr[9] = "GA"; //Georgia
        stateAbbr[10] = "HI"; //Hawaii
        stateAbbr[11] = "ID"; //Idaho
        stateAbbr[12] = "IL"; //Illinois
        stateAbbr[13] = "IN"; //Indiana
        stateAbbr[14] = "IA"; //Iowa
        stateAbbr[15] = "KS"; //Kansas
        stateAbbr[16] = "KY"; //Kentucky
        stateAbbr[17] = "LA"; //Louisiana
        stateAbbr[18] = "ME"; //Maine
        stateAbbr[19] = "MD"; //Maryland
        stateAbbr[20] = "MA"; //Massachusetts
        stateAbbr[21] = "MI"; //Michigan
        stateAbbr[22] = "MN"; //Minnesota
        stateAbbr[23] = "MS"; //Mississippi
        stateAbbr[24] = "MO"; //Missouri
        stateAbbr[25] = "MT"; //Montana
        stateAbbr[26] = "NE"; //Nebraska
        stateAbbr[27] = "NV"; //Nevada
        stateAbbr[28] = "NH"; //New Hampshire
        stateAbbr[29] = "NJ"; //New Jersey
        stateAbbr[30] = "NM"; //New Mexico
        stateAbbr[31] = "NY"; //New York
        stateAbbr[32] = "NC"; //North Carolina
        stateAbbr[33] = "ND"; //North Dakota
        stateAbbr[34] = "OH"; //Ohio
        stateAbbr[35] = "OK"; //Oklahoma
        stateAbbr[36] = "OR"; //Oregon
        stateAbbr[37] = "PA"; //Pennsylvania
        stateAbbr[38] = "RI"; //Rhode Island
        stateAbbr[39] = "SC"; //South Carolina
        stateAbbr[40] = "SD"; //South Dakota
        stateAbbr[41] = "TN"; //Tennessee
        stateAbbr[42] = "TX"; //Texas
        stateAbbr[43] = "UT"; //Utah
        stateAbbr[44] = "VT"; //Vermont
        stateAbbr[45] = "VA"; //Virginia
        stateAbbr[46] = "WA"; //Washington
        stateAbbr[47] = "WV"; //West Virginia
        stateAbbr[48] = "WI"; //Wisconsin
        stateAbbr[49] = "WY"; //Wyoming
        return stateAbbr;
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

    public static bool IsWithinRange(string textBox)
    {
        //decimal number = Convert.ToDecimal(textBox.Text);
        //This is incorrect but it's just a school project so it's alright
        //Zipcodes can be 4 digits in older states like Massachusetts
        int min = 10000;
        int max = 99999;

        int length = textBox.Length;
        int number = 0;
        char[] charArray = new char[length];
        charArray = textBox.ToCharArray();
        if(IsInt32(textBox))
            number = Convert.ToInt32(textBox);
        else
        {
            //MessageBox.Show("Enter an actual number");
            return false;
        }
        
        

        

        if (number < min || number > max)
        {
            MessageBox.Show(textBox + " must be between " + min+ " and " + max + ".");
            //textBox.Focus();
            return false;
        }
        else
        {
            MessageBox.Show(number.ToString());
        }
        return true;
    }

    //checks to see if it has the right symbols in the textbox
    public static bool IsValidEmail(string textBox)
    {
        string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);
         
        if (re.IsMatch(textBox))
            return true;
        else
            return false;
        
    }

    public static bool isValidState(TextBox state)
    {
        if (state.Text.Length > 2)
        {
            MessageBox.Show("Needs to be 2 letters only. (ex. CA for California)");
            return false;
        }
        string[] states = makeStateList();
        for (int i = 0; i < 50; i++)
        {
            if (states[i] == state.Text)
            {
                return true;
            }
        }

        return false;

    }
    
    

    

    //First name, last name, email, Driver's license, address, city, state, zipcode, password, and confirmpassword
    public bool Authenticate(TextBox firstName, TextBox lastName, TextBox email, TextBox driver, TextBox address,
        TextBox city, TextBox state, TextBox zipcode, PasswordBox password, PasswordBox confirmPassword)
    {
        bool isGood = false;
        if (firstName.Text == "")
        {
            return isGood;
        }

        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            txtFirstName.Text = "Enter text here...";

        if (lastName.Text == "")
        {
            return isGood;
        }

        if (!IsValidEmail(email.Text))
        {
            return isGood;
        }

        if (driver.Text == null || driver.Text == "")
        {
            return isGood;
        }

        if (address.Text == null || address.Text == "")
        {
            return isGood;
        }

        if (city.Text == null || address.Text == "")
        {
            return isGood;
        }

        if (state.Text == null || state.Text == "")
        {
            return isGood;
        }

        if (!IsWithinRange(zipcode.Text) || zipcode.Text == "")
        {
            return isGood;
        }

        if (password.Password.Length < 8 || password.Password == "")
        {
            return isGood;
        }

        if (confirmPassword.Password != password.Password || confirmPassword.Password == "")
        {
            return isGood;
        }

        isGood = true;
        return isGood;
    }

    
    
    
    // Link the "sign Up" button to DB to save user registration info
    private void RegUser_Button(object sender, EventArgs e)
    {
        // make sure mandatory fields are typed in
        //Made minor adjustment to the if statement (isValidEmail)
        if (!Authenticate(txtFirstName,txtLastName,txtEmail,txtDriver,txtAddress,City,State,txtZipcode,Password,ConfirmPassword))
        {
            
            MessageBox.Show("Please fill out all mandatory fields on the page.");
        }
        
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

    /*private void ConfirmPassword_OnLostFocus(object sender, RoutedEventArgs e)
    {
        if (ConfirmPassword.Password.Length < 8)
        {
            MessageBox.Show("You need to write at least 8 characters");
        }
    }*/
    
}
    