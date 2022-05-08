using System.Windows;
using System.Windows.Controls;
using static QRbert.QRCodeScanner;

namespace QRbert
{
    /// <summary>
    /// Interaction logic for LogIn_Register.xaml
    /// </summary>
    public partial class LogIn_Register
    {
        public LogIn_Register()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Signs the user in given their account type and redirects them to the correct portal page
        /// Given the portals are pages, they will be able to navigate between the pages
        /// When having to logout, a function will be created that makes a new window and closes the current one
        ///
        /// User is authenticated via password and identified via username
        /// This is done via a database query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignInUserBtn_Click(object sender, RoutedEventArgs e)
        {
            // Takes them to the correct portal depending on the type of user
            // Given the username, Denise will query the database to retrieve the account type
            string staff = "Staff";

            // email and password input from the user
            string emailInput = TxtEmail.Text;
            string pwInput = TxtPassword.Password;

            // Given the username, Denise will query the database to retrieve the account type
            string msg = Switcher.VerifyRole("SELECT count(*) From QRbertDB.QRbertTables.Registration where email = '" + emailInput +
                                    "' and password ='" + pwInput + "'");
            // David will get the password salt/hash thing to validate their credentials and make sure they match
            // If statement will control whether this is correct or not
            // Else will throw a message box displaying incorrect credentials
            if (msg.Equals("0"))
            {
                MessageBox.Show("One of the inputted credentials is incorrect. Please try again.");
            }
            // If statement will control whether they are taken to the staff/volunteer portal
            // For now, true means staff, false means volunteer, but this must be changed according to the above
            else
            {
                // finds a matching email and password and retrieves the faculty role to store in "msg" 
                msg = Switcher.VerifyRole("Select [Faculty-Role] From QRbertDB.QRbertTables.Registration Where email = '" + emailInput +
                                 "' and password ='" + pwInput + "'");
                // Staff user
                if (string.Equals(msg, staff))
                {
                    // Save current user connection email for current session
                    Switcher.CurrentSessionEmail = emailInput;
                   // if email and password match a Staff faculty role
                    Switcher.LogIn_RegisterSwitch(new StaffPortal());
                    this.Close();
                }
                // Volunteer user
                else
                {
                    // Save current user connection email for current session
                    Switcher.CurrentSessionEmail = emailInput;
                    // if email and password match a Volunteer faculty role
                    Switcher.LogIn_RegisterSwitch(new VolunteerPortal());
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Redirects user to the ForgotPassword Window where they will be able to reset their password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForgotPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.LogIn_RegisterSwitch(new UserForgotPassword());
            Close();
        }

        /// <summary>
        /// Takes user to a new window to scan their QR code via the device webcam
        /// Calls DecodeQRCode function from ScanQRCode class and verifies via a query to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignInViaQRCodeBtn_Click(object sender, RoutedEventArgs e)
        {
            DecodeQRCode();

            // saves the result QR code string into an array qrResult
            string[] qrResult = result.Split(' ');

            // first element of the QR string is the email
            string qrEmail = qrResult[0];
            // second element of the QR string is the password
            string qrPwd = qrResult[1];

            string staff = "Staff";
            string volunteer = "Volunteer";

            if (!qrEmail.Contains('.'))
            {
                MessageBox.Show("Invalid QR Code. Please try again.");
            }
            else
            {
                // finds a matching email and password and retrieves the faculty role to store in "msg" 
                string msg = Switcher.VerifyRole(
                    "Select [Faculty-Role] From QRbertDB.QRbertTables.Registration Where email = '" + qrEmail +
                    "' and password ='" + qrPwd + "'");

                // string msg matches the Staff faculty role then user is redirected to staff portal
                if (string.Equals(msg, staff))
                {
                    // Save current user connection email for current session
                    Switcher.CurrentSessionEmail = qrEmail;
                    // if email and password match a Staff faculty role
                    Switcher.LogIn_RegisterSwitch(new StaffPortal());
                    this.Close();
                }
                // The connection string is closed due to time-sheets
                else if (string.Equals(msg, "closed"))
                {
                    MessageBox.Show("Time-sheets have been submitted. Please speak to your supervisor.");
                }
                // if Not staff then user must be a volunteer, then redirects to volunteer portal
                else if (string.Equals(msg, volunteer))
                {
                    // Save current user connection email for current session
                    Switcher.CurrentSessionEmail = qrEmail;
                    // if email and password match a Volunteer faculty role
                    Switcher.LogIn_RegisterSwitch(new VolunteerPortal());
                    this.Close(); 
                }
                // User does not exist
                else
                {
                    MessageBox.Show("Could not validate QR Code. " +
                                    "Please ensure you have the correct QR Code " +
                                    "try scanning again.");
                }
            }
        }
        
        //If there is text in the TextBox, the Email text goes away
        //Returns if there is no text in the TextBox
        private void TxtEmail_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TxtSignInEmail.Visibility = Visibility.Visible;
            if (TxtEmail.Text.Length > 0)
            {
                TxtSignInEmail.Visibility = Visibility.Hidden;
            }
        }

        //If there is text in the PasswordBox, the Password text goes away
        //Returns if there is no text in the PasswordBox
        private void TxtPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            TxtSignInPassword.Visibility = Visibility.Visible;
            if (TxtPassword.Password.Length > 0)
            {
                TxtSignInPassword.Visibility = Visibility.Hidden;
            }
        }
    }

}

