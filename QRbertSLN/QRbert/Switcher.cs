using System.Windows;
using System.Windows.Controls;

namespace QRbert;

/// <summary>
/// Class that allows for page switching
/// </summary>
public class Switcher
{
    // Static class variable staffpageSwitcher of type StaffPortal
    // Allows this class variable to only be used for the Staff Portal
    public static StaffPortal staffpageSwitcher;
    // Static class variable staffpageSwitcher of type VolunteerPortal
    // Allows this class variable to only be used for the volunteer portal
    public static VolunteerPortal volunteerpageSwitcher;
    // Static class variable staffMyAccountPageSwitcher of type StaffMyAccount page
    // Allows this class variable to only be used for the MyAccount Page for Staff
    public static StaffMyAccountPage staffMyAccountPageSwitcher;
    // Static class variable volunteerMyAccountPageSwitcher of type VolunteerMyAccount page
    // Allows this class variable to only be used for the MyAccount page for volunteer
    public static VolunteerMyAccountPage volunteerMyAccountPageSwitcher;
    // Static class variable LogInPageSwitcher of type LogIn/Register Window
    // Allows this class variable to only be used for the LogIn/Register Window for users
    public static LogIn_Register LogInRegisterSwitcher;

    /// <summary>
    /// Static function that only works for the StaffPortal Window
    /// Gets page object and uses the built-in navigate windows method to get the page and load it
    /// Calls the Navigate function written in the StaffPortal cs file and passes the page to it
    /// </summary>
    /// <param name="newPage">
    /// Type Page, represents the desired page to navigate to
    /// </param>
    public static void StaffPageSwitch(Page newPage)
    {
        staffpageSwitcher.Navigate(newPage);
    }

    /// <summary>
    /// Static function that only works for the VolunteerPortal Window
    /// Gets newPage object and uses the built-in navigate windows method to get the page and load it
    /// Calls the Navigate function written in the VolunteerPortal cs file and passes the page to it
    /// </summary>
    /// <param name="newPage">
    /// Type Page, represents the desired page to navigate to
    /// </param>
    public static void VolunteerPageSwitch(Page newPage)
    {
        volunteerpageSwitcher.Navigate(newPage);
    }

    /// <summary>
    /// Static function that only works for the Staff MyAccount Page
    /// Gets newPage object and uses the built-in navigate windows method to get the page and load it
    /// Calls the Navigate function written in the VolunteerPortal cs file and passes the page to it
    /// </summary>
    /// <param name="newPage">
    /// Type page, represents the desired page to navigate to
    /// </param>
    public static void StaffMyAccountPageSwitch(Page newPage)
    {
        staffMyAccountPageSwitcher.Navigate(newPage);

    }
    
    /// <summary>
    /// Static function that only works for the Volunteer MyAccount Page
    /// Gets newPage object and uses the built-in navigate windows method to get the page and load it
    /// Calls the Navigate function written in the VolunteerMyAccount cs file and passes the page to it
    /// </summary>
    /// <param name="newPage">
    /// Type page, represents the desired page to navigate to
    /// </param>
    public static void VolunteerMyAccountPageSwitch(Page newPage) 
    {
        volunteerMyAccountPageSwitcher.Navigate(newPage);
        
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
        LogInRegisterSwitcher.Navigate(newWindow);
    }
}
// Hi Denise, welcome to the amazing switcher class. It can be pretty confusing, but really, it's just a bunch of
// polymorphism, but we all have different personalities, anyways, right? Anyways... 