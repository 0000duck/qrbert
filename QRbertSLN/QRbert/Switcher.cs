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
    // For Staff MyAccount page
    public static StaffMyAccountPage staffMyAccountPageSwitcher;
    // For Volunteer MyAccount page
    public static VolunteerMyAccountPage volunteerMyAccountPageSwitcher;

    /// <summary>
    /// Static function that only works for the StaffPortal Window
    /// Gets page object and uses the built-in navigate windows method to get the page and load it
    /// Calls the Navigate function written in the StaffPortal cs file and passes the page to it
    /// </summary>
    /// <param name="newPage"></param>
    public static void StaffPageSwitch(Page newPage)
    {
        staffpageSwitcher.Navigate(newPage);
    }

    /// <summary>
    /// Static function that only works for the VolunteerPortal Window
    /// Gets newPage object and uses the built-in navigate windows method to get the page and load it
    /// Calls the Navigate function written in the VolunteerPortal cs file and passes the page to it
    /// </summary>
    /// <param name="newPage"></param>
    public static void VolunteerPageSwitch(Page newPage)
    {
        volunteerpageSwitcher.Navigate(newPage);
    }

    public static void StaffMyAccountPageSwitch(Page newPage)
    {
        staffMyAccountPageSwitcher.Navigate(newPage);

    }
    
    public static void VolunteerMyAccountPageSwitch(Page newPage) 
    {
        volunteerMyAccountPageSwitcher.Navigate(newPage);
        
    }
}