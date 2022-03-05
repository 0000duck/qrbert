using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows;
using System.Data.SqlClient;


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
        if (RegFirst.Text == "Enter text here...") 
        {
            RegFirst.Text = "";
        }
    }

    public void AddText(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(RegFirst.Text))
            RegFirst.Text = "Enter text here...";
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
            SqlCommand sqlCmd = new SqlCommand("RegUser", sqlCon);

            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlCmd.Parameters.AddWithValue("@Password", ConfirmPassword.Password);
            sqlCmd.Parameters.AddWithValue("@Faculty_Role", txtFacultyRole.Text);
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text);

            sqlCmd.ExecuteNonQuery();
            MessageBox.Show("Sign Up Complete ");
        }
    }
    
}

    