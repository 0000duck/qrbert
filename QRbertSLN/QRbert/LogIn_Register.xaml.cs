using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Data.SqlClient;
using OpenCVDemo;
using OpenCvSharp;
using Window = System.Windows.Window;
using static QRbert.QRCodeScanner;

namespace QRbert
{
    /// <summary>
    /// Interaction logic for LogIn_Register.xaml
    /// </summary>
    public partial class LogIn_Register : Window
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
            string emailInput = txtEmail.Text;
            string pwInput = txtPassword.Text;

            // Given the username, Denise will query the database to retrieve the account type
            string msg = verifyRole("SELECT count(*) From QRbertTables.Registration where email = '" + emailInput +
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
                msg = verifyRole("Select [Faculty-Role] From QRbertTables.Registration Where email = '" + emailInput +
                                 "' and password ='" + pwInput + "'");

                if (string.Equals(msg, staff))
                {
                   // if email and password match a Staff faculty role
                    Switcher.LogIn_RegisterSwitch(new StaffPortal());
                    this.Close();
                }
                else
                {
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
            // Make a Window for this
        }

        private string verifyRole(string s)
        {
            using SqlConnection sqlCon = new SqlConnection(Switcher.connectionString);
            sqlCon.Open();
            SqlCommand command = new SqlCommand(s, sqlCon);
            string query = command.ExecuteScalar().ToString();
            return query;
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

            // saves the result QR code string into an array QRresult
            string[] QRresult = result.Split(' ');
            
            // first element of the QR string is the email
            string QRemail = QRresult[0];
            // second element of the QR string is the password
            string QRpwd = QRresult[1];

            string staff = "Staff";
        
             // finds a matching email and password and retrieves the faculty role to store in "msg" 
             string msg = verifyRole("Select [Faculty-Role] From QRbertTables.Registration Where email = '" + QRemail +
                                     "' and password ='" + QRpwd + "'");

             // string msg matches the Staff faculty role then user is redirected to staff portal
             if (string.Equals(msg, staff))
             {
                 // if email and password match a Staff faculty role
                 Switcher.LogIn_RegisterSwitch(new StaffPortal());
                 this.Close();
             }
            // if Not staff then user must be a volunteer, then redirects to volunteer portal
             else
             {
                 // if email and password match a Volunteer faculty role
                 Switcher.LogIn_RegisterSwitch(new VolunteerPortal());
                 this.Close();
             }
        }
    }

}

