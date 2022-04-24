using System.Data.SqlClient;
using System.Windows;

namespace QRbert;

/// <summary>
/// Class that allows for window switching
/// </summary>
public class Switcher
{
    /// <summary>
    /// Connects DB to Register Page
    /// Data source - name of the DB server connection
    /// Initial Catalog - QRbert database we want to connect to
    /// User name and Password - temp log in solution until we find a more secure way to log into the DB so that the
    /// log in credentials aren't in the code for all to see 
    /// </summary>
    public static string ConnectionString = 
        @"Data Source = qrbert-rds1.cfe8s1xr87h2.us-west-1.rds.amazonaws.com;
        Initial Catalog = QRbertDB; User ID = rds1_admin; Password = rds1_admin;";

    /// <summary>
    /// Saves email string of user currently logged in
    /// </summary>
    public static string CurrentSessionEmail = "";

    /// <summary>
    /// Saves PetID int of most recently scanned PetID
    /// </summary>
    public static int PetId = 0000;

    /// <summary>
    /// Saves the state of RemoveAnimal option as boolean
    /// </summary>
    public static bool RemoveAnimal = false;
    
    /// <summary>
    /// Verifies the role of the user type
    /// </summary>
    /// <param name="s">
    /// Represents the string to pass into the SQL connection 
    /// </param>
    /// <returns></returns>
    public static string VerifyRole(string s)
    {
        using SqlConnection sqlCon = new SqlConnection(ConnectionString);
        sqlCon.Open();
        if (sqlCon.ToString().Equals("closed"))
        {
            return "closed";
        }
        SqlCommand command = new SqlCommand(s, sqlCon);
        string query = command.ExecuteScalar().ToString();
        return query;
    }
    
    /// <summary>
    /// Static function that works for the StaffPortal Windows
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
    /// Static function that works for the VolunteerPortal Windows
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
        CurrentSessionEmail = "";
        PetId = 0000;
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
}