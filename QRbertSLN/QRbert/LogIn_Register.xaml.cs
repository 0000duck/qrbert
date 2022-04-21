using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.Net.Mime;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using BitMiracle.Docotic.Pdf;
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
            string pwInput = (string)txtPassword.Password;

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
        

        //If there is text in the TextBox, the Email text goes away
        //Returns if there is no text in the TextBox
        private void TxtEmail_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            txtSignInEmail.Visibility = Visibility.Visible;
            if (txtEmail.Text.Length > 0)
            {
                txtSignInEmail.Visibility = Visibility.Hidden;
            }
        }

        //If there is text in the PasswordBox, the Password text goes away
        //Returns if there is no text in the PasswordBox
        private void TxtPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            txtSignInPassword.Visibility = Visibility.Visible;
            if (txtPassword.Password.Length > 0)
            {
                txtSignInPassword.Visibility = Visibility.Hidden;
            }
        }

        private void makeTable(object sender, RoutedEventArgs routedEventArgs)
        {
            Document document = new Document();

// Add page
            Aspose.Pdf.Page page = document.Pages.Add();

// Add text to new page
            
            TextFragment textFragment = new TextFragment("Hello World!");
            textFragment.TextState.FontSize = 120;


            Table table = new Table();
            // Add row to table
            Aspose.Pdf.Row header = table.Rows.Add();
            // Add table cells
            header.Cells.Add("User ID");
            header.Cells.Add("First Name");
            header.Cells.Add("Last Name");
            header.Cells.Add("Log In");
            header.Cells.Add("Log Out");
            
            for (int row_count = 1; row_count < 3; row_count++)
            {
                // Add row to table
                Aspose.Pdf.Row row = table.Rows.Add();
                // Add table cells
                row.Cells.Add("Column (" + row_count + ", 1)");
                row.Cells.Add("Column (" + row_count + ", 2)");
                row.Cells.Add("Column (" + row_count + ", 3)");
            }
            page.Paragraphs.Add(table);
            page.PageInfo.IsLandscape = true;
            

// Save PDF 
            document.Save("document.pdf");
            PdfDocument pdf = new PdfDocument("document.pdf");
            PdfDrawOptions options = PdfDrawOptions.CreateZoom(150);
            options.BackgroundColor = new PdfRgbColor(0, 255, 255); // white background, transparent by default
            //options.Format = PdfDrawFormat.Jpeg;
            PdfPage page2 = pdf.Pages[0];
            PdfBox cropBoxBefore = page2.CropBox;

            //page2.CropBox = new PdfBox(0, cropBoxBefore.Height - 256, 256, cropBoxBefore.Height);
            pdf.Pages[0].Save("result.jpg",options);
            
            
            
            Switcher.VolunteerPortalSwitch(new VolunteerViewTimesheets());
            
        }
    }

}

