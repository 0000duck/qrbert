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
        // Denise will open the connection to the database
        String connectionString = @"Data Source = qrbert-rds1.cfe8s1xr87h2.us-west-1.rds.amazonaws.com; 
                                Initial Catalog = QRbertDB; User ID = rds1_admin; Password = rds1_admin;";

        public LogIn_Register()
        {
            InitializeComponent();
            Switcher.LogInRegisterSwitcher = this;
        }

        public void Navigate(Window nextWindow)
        {
            nextWindow.Show();
        }


        private void RegisterNewUserBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
            Process process = new Process();
            process.StartInfo.FileName = "zbarcam.exe";
            process.Start();
            */
            // Page generateQRCodePage = new GenerateQrCode();
            // this.Content = generateQRCodePage;
            // NavigationWindow redirectNewUser = new NavigationWindow();
            // redirectNewUser.Source = new Uri("Register.xaml", UriKind.Relative);
            Window RegisterNewUser = new Register();
            RegisterNewUser.Show();
            this.Close();

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
                    // Window RedirectSignInStaffPortal = new StaffPortal();
                    // RedirectSignInStaffPortal.Show();
                    Switcher.LogIn_RegisterSwitch(new StaffPortal());
                    this.Close();
                }

                else
                {
                    // This appears greyed out b/c true is always true, if condition must be changed
                    // Window RedirectSignInVolunteerPortal = new VolunteerPortal();
                    // RedirectSignInVolunteerPortal.Show();
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

    public string verifyRole(string s)
    {
        using SqlConnection sqlCon = new SqlConnection(connectionString);
        sqlCon.Open();
        SqlCommand command = new SqlCommand(s, sqlCon);
        string query = command.ExecuteScalar().ToString();
        return query;
    }
    
        /// <summary>
        /// Redirects user to the ForgotPassword Window where they will be able to reset their password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForgotPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            
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
            // MessageBox.Show(result);
            // I commented out the above line as it is for testing, feel free to uncomment it
            // I need Denise to add code here to verify a user log in
            // For now, I will redirect them to the staff portal
            Switcher.LogIn_RegisterSwitch(new StaffPortal());
            this.Close();
        }
    }

}

