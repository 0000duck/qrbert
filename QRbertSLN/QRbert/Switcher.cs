using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

/// <summary>
/// Class that allows for page switching
/// </summary>
public class Switcher
{ 
    /*
     * connects DB to Register Page
     * Data source is the name of the DB server
     * Initial Catalog the QRbert database we want to connect to
     * User name and Password -> temp log in solution until we find a more secure way to log into the DB
     * so that the log in credentials aren't in the code for all to see
     */ 
    public static string connectionString = 
        @"Data Source = qrbert-rds1.cfe8s1xr87h2.us-west-1.rds.amazonaws.com;
        Initial Catalog = QRbertDB; User ID = rds1_admin; Password = rds1_admin;";
    
    /// <summary>
    /// Static function that only works for the StaffPortal Window
    /// Gets page object and uses the built-in navigate windows method to get the page and load it
    /// Calls the Navigate function written in the StaffPortal cs file and passes the page to it
    /// </summary>
    /// <param name="newWindow">
    /// Type Window, represents the desired window to navigate to
    /// </param>
    public static void StaffPageSwitch(Window newWindow)
    {
        newWindow.Show();
    }
    
    /// <summary>
    /// Static function that only works for the VolunteerPortal Window
    /// Gets newPage object and uses the built-in navigate windows method to get the page and load it
    /// Calls the Navigate function written in the VolunteerPortal cs file and passes the page to it
    /// </summary>
    /// <param name="newWindow">
    /// Type Page, represents the desired page to navigate to
    /// </param>
    public static void VolunteerPortalSwitch(Window newWindow)
    {
        newWindow.Show();
    }
    
    
    /// <summary>
    /// Static function that only works for the LogIn/Register Window
    /// Gets newWindow object and uses the built-in navigate windows method to get the window and load it
    /// Calls the Navigate function written in the LogIn-Register cs file and passes the window to it
    /// </summary>
    /// <param name="newWindow">
    /// Type Window, represents the desired window to navigate to
    /// </param>
    public static void LogIn_RegisterSwitch(Window newWindow)
    {
        newWindow.Show();
    }

    /// <summary>
    /// Static function that displays a new Log In window, used when user, either staff or volunteer, logs out
    /// </summary>
    public static void LogOutSwitch()
    {
        new LogIn_Register().Show();
    }
    
    /// <summary>
    /// Static function that displays a new Staff Portal window, used when staff wants to go back to the home page
    /// </summary>
    public static void RedirectStaffPortal()
    {
        new StaffPortal().Show();
    }

    /// <summary>
    /// Static function that displays a new Volunteer Portal window, used when volunteer desires to go to home page
    /// </summary>
    public static void RedirectVolunteerPortal()
    {
        new VolunteerPortal().Show();
    }

    public static void RedirectPetPage(Window newWindow)
    {
        newWindow.Show();
    }
}