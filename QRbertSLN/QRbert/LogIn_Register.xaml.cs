﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

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
            Switcher.LogInRegisterSwitcher = this;
        }

        public void Navigate(Window nextWindow)
        {
            this.Content = nextWindow;
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
            // Denise will open the connection to the database
            // David will get the password salt/hash thing to validate their credentials and make sure they match
            // If statement will control whether this is correct or not
            // Else will throw a message box displaying incorrect credentials
            if (true)
            {
                // Takes them to the correct portal depending on the type of user
                // Given the username, Denise will query the database to retrieve the account type
                // If statement will control whether they are taken to the staff/volunteer portal
                // For now, true means staff, false means volunteer, but this must be changed according to the above
                if (true)
                {
                    Window RedirectSignInStaffPortal = new StaffPortal();
                    RedirectSignInStaffPortal.Show();
                    this.Close();
                }
                else
                {
                    // This appears greyed out b/c true is always true, if condition must be changed
                    Window RedirectSignInVolunteerPortal = new VolunteerPortal();
                    RedirectSignInVolunteerPortal.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("One of the inputted credentials is incorrect. Please try again.");
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
    }
}
