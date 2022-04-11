using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Windows.Navigation;
using System.Text.RegularExpressions;
using System.Windows.Media;
//using System.Windows.Interactivity
using Microsoft.Xaml.Behaviors;
using QRCoder;
using QRCoder.Xaml;


//using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;


namespace QRbert;

public partial class Register : Window
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

  private string facultyRole;
  private string staff = "Staff";
  
  /// <summary>
  /// Function that initializes the Register window
  /// </summary>
    public Register()
    {
        InitializeComponent();
        
    }

    
    /// <summary>
    /// Function that makes a list of state abbrevations
    /// </summary>
    /// <returns>string[]</returns>
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


    
    /*private void runSignUp(object sender, RoutedEventArgs e)
    {
        
        //Console.WriteLine("Here");
        bool firstNameCheck = isFirstNameValid(RegFirst.Text);
        if (firstNameCheck)
        {
            //accept the sign up form
            MessageBox.Show("Good to submit");
        }
        else
        {
            //reload page and show what needs to be changed
            MessageBox.Show("Not good to submit");
        }
        MessageBox.Show(Password.Password);
    }*/
    

/// <summary>
/// Function that makes sure that it is a valid string
/// </summary>
/// <param name="words"></param>
/// <returns></returns>
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
/// <summary>
/// Function that makes sure that there is some text in the TextBox
/// </summary>
/// <param name="textBox"></param>
/// <param name="textBoxName"></param>
/// <returns>bool</returns>
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
/// <summary>
/// Function that makes sure the string is a decimal
/// </summary>
/// <param name="textBox"></param>
/// <returns>bool</returns>
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
/// <summary>
/// Function that checks to make sure the string can be turned into an integer
/// </summary>
/// <param name="textBox"></param>
/// <returns>bool</returns>
    public static bool IsInt32(string textBox)
    {
        int number = 0;
        if (Int32.TryParse(textBox, out number))
        {
            return true;
        }
        else
        {
            MessageBox.Show("This should be an integer.");
            //textBox.Focus();
            return false;
        }
    }
/// <summary>
/// Function that determines if the string is in range.
/// </summary>
/// <param name="textBox"></param>
/// <returns>bool</returns>

    public static bool IsWithinRange(string textBox)
    {
        
        //Zipcodes can be 4 digits in older states like Massachusetts
        //This is incorrect but it's just a school project so it's alright
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
            MessageBox.Show("Zipcode must be between " + min+ " and " + max + ".");
            //textBox.Focus();
            return false;
        }
        else
        {
            MessageBox.Show(number.ToString());
        }
        return true;
    }
/// <summary>
/// Function that checks for a valid email
/// </summary>
/// <param name="textBox"></param>
/// <returns>bool</returns>
    
    public static bool IsValidEmail(string textBox)
    {
        string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        string strRegex2 = @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}";
        Regex re = new Regex(strRegex2, RegexOptions.IgnoreCase);

        if (re.IsMatch(textBox))
        {
            //MessageBox.Show("A valid email");
            return true;
        }
            
        else
        {
            //MessageBox.Show("Not a valid email");
            return false;
        }
            
        
    }
/// <summary>
/// Function that checks for two letters to represent the state
/// </summary>
/// <param name="state"></param>
/// <returns>bool</returns>
    //Checks to make sure that a valid state abbrevation
    public static bool isValidState(TextBox state)
    {
        if (state.Text.Length != 2)
        {
            MessageBox.Show("Needs to be 2 letters only. (ex. CA for California)");
            return false;
        }
        string[] states = makeStateList();
        for (int i = 0; i < 50; i++)
        {
            if (states[i] == state.Text)
            {
                //MessageBox.Show("Wee is good");
                return true;
            }
        }

        //MessageBox.Show("What's good bro?!");
        return false;

    }
    /// <summary>
    /// Function that validates the driver's license
    /// </summary>
    /// <param name="driver"></param>
    /// <returns>bool</returns>
    //Checks for a valid driver's license
    public static bool isValidDriver(string driver)
    {
        string regexDriver = @"[A-Z]{1}[0-9]{7}";
        Regex re = new Regex(regexDriver, RegexOptions.IgnoreCase);

        if (re.IsMatch(driver)&&driver.Length<9)
        {
            //MessageBox.Show("Solid bro");
            return true;
        }

        //MessageBox.Show("No good bro");
        return false;
    }
/// <summary>
/// Function that determines if the string in the TextBox is valid
/// </summary>
/// <param name="number"></param>
/// <returns>bool</returns>
    //Checks for a valid phone number
    public static bool isValidPhone(TextBox number)
    {
        /*if (!IsInt32(number.Text))
        {
            MessageBox.Show("Can't have any characters. Only numbers");
            return false;
        }
        */
        //this looks for a pattern that has 10 numbers to make up a phone number
        string regexPhone = @"[0-9]{10}";
        Regex re = new Regex(number.Text);
        if(re.IsMatch(number.Text)&&number.Text.Length < 11)
        {
            //MessageBox.Show("Very based");
            return true;
        }

        //MessageBox.Show("Not based");
        return false;
    }
    
    /// <summary>
    /// Function that checks all information in the Register page is filled out before entering it to the database.
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <param name="driver"></param>
    /// <param name="address"></param>
    /// <param name="city"></param>
    /// <param name="state"></param>
    /// <param name="zipcode"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="password"></param>
    /// <param name="confirmPassword"></param>
    /// <returns>bool</returns>

    

    //First name, last name, email, Driver's license, address, city, state, zipcode, password, and confirmpassword
    //Used to authenticate everything on the Register.xaml
    public bool Authenticate(TextBox firstName, TextBox lastName, TextBox email, TextBox driver, TextBox address,
        TextBox city, TextBox state, TextBox zipcode, TextBox phoneNumber, PasswordBox password, PasswordBox confirmPassword)
    {
        bool isGood = false;
        if (firstName.Text == "")
        {
            return isGood;
        }

        if (lastName.Text == "")
        {
            return isGood;
        }

        if (!IsValidEmail(email.Text))
        {
            return isGood;
        }

        if (!isValidDriver(driver.Text))
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

        if (!isValidState(state) || state.Text == "")
        {
            return isGood;
        }

        if (!IsWithinRange(zipcode.Text) || zipcode.Text == "")
        {
            return isGood;
        }

        if (!isValidPhone(phoneNumber)|| phoneNumber.Text == "")
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

    
    /// <summary>
    /// Function that when a button is clicked, it validates all textbox information before sending it to the database.
    /// If anything is not filled out properly, it does not get added to the database. Otherwise, add it to the
    /// database and displays the QR code for the user to save. Then, redirects them to the LogIn Window.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    
    // Link the "sign Up" button to DB to save user registration info
    private void RegUser_Button(object sender, EventArgs e)
    {
        // make sure mandatory fields are typed in
        //Made minor adjustment to the if statement (isValidEmail)

        if (!Authenticate(txtFirstName,txtLastName,txtEmail,txtDriver,txtAddress,txtCity,txtState,txtZipcode,txtPhone,Password,ConfirmPassword))
        {
            MessageBox.Show("Please fill out all mandatory fields on the page.");
        }
        
        

        else
        {
            /* creates and opens a connection to the Database. connectionString was declared in line #27
              * which validates the DB credentials 
              */
            using SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            
            /* User Input stored in Registration table
             * RegUser is the stored procedure created in the DB that inserts data into each row of the Registration table
            */ 
            SqlCommand sqlCmd = new SqlCommand("RegUser", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlCmd.Parameters.AddWithValue("@Password", ConfirmPassword.Password);
            sqlCmd.Parameters.AddWithValue("@Faculty_Role", facultyRole);
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            
            // Contact Info stored in Contact_Info Table using Contact stored procedure created in database
            SqlCommand contact = new SqlCommand("Contact", sqlCon);
            contact.CommandType = CommandType.StoredProcedure;
            contact.Parameters.AddWithValue("@Email", txtEmail.Text);
            contact.Parameters.AddWithValue("@Password", ConfirmPassword.Password);
            contact.Parameters.AddWithValue("@Faculty_Role", facultyRole);
            contact.Parameters.AddWithValue("@Street", txtAddress.Text);
            contact.Parameters.AddWithValue("@City", txtCity.Text);
            contact.Parameters.AddWithValue("@State", txtState.Text);
            contact.Parameters.AddWithValue("@ZipCode", txtZipcode.Text);
            contact.Parameters.AddWithValue("@PhoneNum", txtPhone.Text);
            contact.Parameters.AddWithValue("@DL_ID", txtDriver.Text);

            // connection to Staff input stored procedure from Database
           SqlCommand staffCon = new SqlCommand("StaffInput", sqlCon);
           // connection to Volunteer input stored procedure from Database
           SqlCommand volCon = new SqlCommand("VolInput", sqlCon);
           
           /* verify what faculty role was created during Registration , if it is a Staff
            * then store and create a New staff profile in the Staff table database
            * if Volunteer, then skip the Staff stored procedure and use the Volunteer stored procedure instead
            * to create a New and save Volunteer profile
            */
            if (string.Equals(facultyRole, staff))
            {
                // Staff credentials created and stored in Contact_Info Table 

                staffCon.CommandType = CommandType.StoredProcedure;
                staffCon.Parameters.AddWithValue("@Email", txtEmail.Text);
                staffCon.Parameters.AddWithValue("@Password", ConfirmPassword.Password);
                staffCon.Parameters.AddWithValue("@Faculty_Role", facultyRole);
                sqlCmd.ExecuteNonQuery();
                contact.ExecuteNonQuery();
                staffCon.ExecuteNonQuery();
            }
            
            else
            {
                // Volunteer credentials created and stored in Contact_Info Table 
                
                volCon.CommandType = CommandType.StoredProcedure;
                volCon.Parameters.AddWithValue("@Email", txtEmail.Text);
                volCon.Parameters.AddWithValue("@Password", ConfirmPassword.Password);
                volCon.Parameters.AddWithValue("@Faculty_Role", facultyRole);
                sqlCmd.ExecuteNonQuery();
                contact.ExecuteNonQuery();
                volCon.ExecuteNonQuery();
                
            }
            
            MessageBox.Show("Sign up successful. Please log in.");

            
            // Creating the user's QR code and displaying it
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            // Saves the email, password, and facultyrole as a string for the QR code, this can be changed later
            String userInfo = txtEmail.Text + " "  + ConfirmPassword.Password + " " + facultyRole;
            QRCodeData data = qrCodeGenerator.CreateQrCode(userInfo, QRCodeGenerator.ECCLevel.Q);
            XamlQRCode qrCode = new XamlQRCode(data);
            DrawingImage qrCodeImage = qrCode.GetGraphic(20);
            // Creates a new window to display the QR code and shows it
            ShowQRCode showQRCode = new ShowQRCode();
            showQRCode.QRCodeViewer.Source = qrCodeImage;
            showQRCode.QRCodeViewer.Visibility = Visibility.Visible;
            MessageBox.Show("Sign up successful. Save your QR code and log in.");
            this.Close();
            showQRCode.Show();
            while (showQRCode.IsLoaded)
            {
                if (!showQRCode.IsLoaded)
                {
                    break;
                }
            }

            // After a successful registration, user is redirected to 
            // the Log In window to login with their new credentials
            Window redirectNewUser = new LogIn_Register();      // Creates the new window
            redirectNewUser.Show();     // Opens the new window
            this.Close();       // Closes the current window
        }
    }

    
    /// <summary>
    /// Function that when the first name textbox has any text, the first name textblock disappears. The textblock reappears when no text is found
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    
    private void txtFirstNameBlock_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        txtFirstNameBlock.Visibility = Visibility.Visible;
        if (txtFirstName.Text.Length > 0)
        {
            txtFirstNameBlock.Visibility = Visibility.Hidden;
        }
    }
    /// <summary>
    /// Function that when the passwordbox has any text, the password textblock disappears. The textblock reappears when no text is found
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Function that creates a watermark-like text for Password
    private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        
        txtHintPassword.Visibility = Visibility.Visible;
        if (Password.Password.Length > 0)
        {
            txtHintPassword.Visibility = Visibility.Hidden;
        }
    }
    
    //Function that I have no idea what it does but it is still here
    void PrintText(object sender, SelectionChangedEventArgs args)
    {
        ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
        MessageBox.Show("You selected " + lbi.Content.ToString() + ".");
    }
/// <summary>
/// Function that when the confirm passwordbox has any text, the confirm password textblock disappears.
/// The textblock reappears when no text is found
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    
    private void ConfirmPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        txtHintConfirmPassword.Visibility = Visibility.Visible;
        if (ConfirmPassword.Password.Length > 0)
        {
            txtHintConfirmPassword.Visibility = Visibility.Hidden;
        }
    }
/// <summary>
/// Function that when the last name textbox has any text, the last name textblock disappears. The textblock reappears when no text is found
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    //Function that creates a watermark-like text for Last Name
    private void TxtLastName_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtLastNameBlock.Visibility = Visibility.Visible;
        if (txtLastName.Text.Length > 0)
        {
            txtLastNameBlock.Visibility = Visibility.Hidden;
        }
        
    }
/// <summary>
/// Function that when the email textbox has any text, the email textblock disappears. The textblock reappears when no text is found
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    //Function that creates a watermark-like text for Email
    private void TxtEmail_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtEmailBlock.Visibility = Visibility.Visible;
        if (txtEmail.Text.Length > 0)
        {
            txtEmailBlock.Visibility = Visibility.Hidden;
        }
    }
/// <summary>
/// Function that when the driver's license textbox has any text, the driver's license textblock disappears.
/// The textblock reappears when no text is found
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    //Function that creates a watermark-like text for Driver's License
    private void TxtDriver_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtDriverBlock.Visibility = Visibility.Visible;
        if (txtDriver.Text.Length > 0)
        {
            txtDriverBlock.Visibility = Visibility.Hidden;
        }
    }
/// <summary>
/// Function that when the address textbox has any text, the address textblock disappears. The textblock reappears when no text is found
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    //Function that creates a watermark-like text for Address
    private void TxtAddress_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtAddressBlock.Visibility = Visibility.Visible;
        if (txtAddress.Text.Length > 0)
        {
            txtAddressBlock.Visibility = Visibility.Hidden;
        }
    }
/// <summary>
/// Function that when the city textbox has any text, the city textblock disappears. The textblock reappears when no text is found
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    //Function that creates a watermark-like text for City
    private void TxtCity_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtCityBlock.Visibility = Visibility.Visible;
        if (txtCity.Text.Length > 0)
        {
            txtCityBlock.Visibility = Visibility.Hidden;
        }
    }
/// <summary>
/// Function that when the state textbox has any text, the state textblock disappears. The textblock reappears when no text is found
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    //Function that creates a watermark-like text for State
    private void TxtState_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtStateBlock.Visibility = Visibility.Visible;
        if (txtState.Text.Length > 0)
        {
            txtStateBlock.Visibility = Visibility.Hidden;
        }
    }
    /// <summary>
    /// Function that when the phone textbox has any text, the phone textblock disappears. The textblock reappears when no text is found
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Function that creates a watermark-like text for Phone Number
    private void TxtPhone_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtPhoneBlock.Visibility = Visibility.Visible;
        if (txtPhone.Text.Length > 0)
        {
            txtPhoneBlock.Visibility = Visibility.Hidden;
        }
    }
/// <summary>
/// Function that when the zipcode textbox has any text, the zipcode textblock disappears. The textblock reappears when no text is found
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    //Function that creates a watermark-like text for Zipcode
    private void TxtZipcode_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtZipcodeBlock.Visibility = Visibility.Visible;
        if (txtZipcode.Text.Length > 0)
        {
            txtZipcodeBlock.Visibility = Visibility.Hidden;
        }
    }
/// <summary>
/// Function that when the radio button is selected, the text for that specific button is added to a string variable
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    //Function that gathers the Faculty Role from the Radio Buttons
    void FacultyChoice (object sender, RoutedEventArgs e)
    {
        RadioButton li = (sender as RadioButton);
        //MessageBox.Show("You clicked " + li.Content.ToString() + ".");
        facultyRole = li.Content.ToString();
    }

    /* This can be used for letting the user know about how they need more than 8 characters
     private void ConfirmPassword_OnLostFocus(object sender, RoutedEventArgs e)
    {
        if (ConfirmPassword.Password.Length < 8)
        {
            MessageBox.Show("You need to write at least 8 characters");
        }
    }*/
    
}
    