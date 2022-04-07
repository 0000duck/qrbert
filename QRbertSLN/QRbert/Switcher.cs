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
    public static VolunteerPortal VolunteerPortalSwitcher;
    // Static class variable staffMyAccountPageSwitcher of type StaffMyAccount page
    // Allows this class variable to only be used for the MyAccount Page for Staff
    public static StaffMyAccount staffMyAccountPageSwitcher;
    // Static class variable volunteerMyAccountPageSwitcher of type VolunteerMyAccount page
    // Allows this class variable to only be used for the MyAccount page for volunteer
    public static VolunteerMyAccount VolunteerMyAccountSwitcher;
    // Static class variable LogInPageSwitcher of type LogIn/Register Window
    // Allows this class variable to only be used for the LogIn/Register Window for users
    public static LogIn_Register LogInRegisterSwitcher;
    // Static class variable StaffChangeEmailSwitcher of type StaffChangeEmail window
    // Allows this class variable to only be used for the StaffChangeEmail window for users
    public static StaffChangeEmail StaffChangeEmailSwitcher;
    // Static class variable StaffChangePwdSwitcher of type StaffChangePassword window
    // Allows this class variable to only be used for the StaffChangePassword window for users
    public static StaffChangePassword StaffChangePasswordSwitcher;
    // Static class variable StaffChangePersonalInfoSwitcher of type StaffChangePersonalInfo window
    // Allows this class variable to only be used for the StaffChangePersonalInfo window for users
    public static StaffChangePersonalInfo StaffChangePersonalInfoSwitcher;
    // Static class variable StaffForgotPwdSwitcher of type StaffForgotPwd window
    // Allows this class variable to only be used for the StaffForgotPwd window for users
    public static StaffForgotPassword StaffForgotPasswordSwitcher;
    // Static class variable StaffPetReportSwitcher of type StaffPetReportSwitcher window
    // Allows this class variable to only be used for the StaffPetReportSwitcher window for users
    public static StaffPetReport StaffPetReportSwitcher;
    // Static class variable StaffCreatePetReportSwitcher of type StaffCreatePetReport window
    // Allows this class variable to only be used for the StaffPetReportSwitcher window for users
    public static StaffCreatePetReport StaffCreatePetReportSwitcher;
    // Static class variable StaffViewPetReportSwitcher of type StaffViewPetReport window
    // Allows this class variable to only be used for the StaffViewPetReportSwitcher window for users
    public static StaffViewPetReport StaffViewPetReportSwitcher;
    // Static class variable VolunteerChangeEmailSwitcher of type VolunteerChangeEmail window
    // Allows this class variable to only be used for the VolunteerChangeEmailSwitcher window for users
    public static VolunteerChangeEmail VolunteerChangeEmailSwitcher;
    // Static class variable VolunteerChangePwdSwitcher of type VolunteerChangePassword window
    // Allows this class variable to only be used for the VolunteerChangePwdSwitcher window for users
    public static VolunteerChangePassword VolunteerChangePwdSwitcher;
    // Static class variable VolunteerForgotPwdSwitcher of type VolunteerForgotPassword window
    // Allows this class variable to only be used for the VolunteerForgotPwdSwitcher window for users
    public static VolunteerForgotPassword VolunteerForgotPasswordSwitcher;

    /// <summary>
    /// Static function that only works for the StaffPortal Window
    /// Gets page object and uses the built-in navigate windows method to get the page and load it
    /// Calls the Navigate function written in the StaffPortal cs file and passes the page to it
    /// </summary>
    /// <param name="newWindow">
    /// Type Page, represents the desired page to navigate to
    /// </param>
    public static void StaffPageSwitch(Window newWindow)
    {
        staffpageSwitcher.Navigate(newWindow);
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
        VolunteerPortalSwitcher.Navigate(newWindow);
    }

    /// <summary>
    /// Static function that only works for the Staff MyAccount Page
    /// Gets newPage object and uses the built-in navigate windows method to get the page and load it
    /// Calls the Navigate function written in the VolunteerPortal cs file and passes the page to it
    /// </summary>
    /// <param name="newWindow">
    /// Type page, represents the desired page to navigate to
    /// </param>
    public static void StaffMyAccountSwitch(Window newWindow)
    {
        staffMyAccountPageSwitcher.Navigate(newWindow);

    }
    
    /// <summary>
    /// Static function that only works for the Volunteer MyAccount Window
    /// Gets newPage object and uses the built-in navigate windows method to get the page and load it
    /// Calls the Navigate function written in the VolunteerMyAccount cs file and passes the page to it
    /// </summary>
    /// <param name="newWindow">
    /// Type page, represents the desired page to navigate to
    /// </param>
    public static void VolunteerMyAcctSwitch(Window newWindow) 
    {
        VolunteerMyAccountSwitcher.Navigate(newWindow);
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
    
    /// <summary>
    /// Static function that only works for the StaffChangeEmail window
    /// Gets newWindow object and uses the built-in navigate windows method to get the window and load it
    /// Calls the Navigate function written in the StaffChangeEmail cs file and passes the window to it
    /// </summary>
    /// <param name="newWindow">
    /// Type Window, represents the desired window to navigate to
    /// </param>
    public static void StaffChangeEmailSwitch(Window newWindow)
    {
        StaffChangeEmailSwitcher.Navigate(newWindow);
    }

    /// <summary>
    /// Static function that only works for the StaffChangePwdSwitch window
    /// Gets newWindow object and users the built-in navigate windows method to get the window and load it
    /// Calls the Navigate function written in the StaffChangePassword cs file and passes the window to it 
    /// </summary>
    /// <param name="newWindow">
    /// Type Window, represents the desired window to navigate to
    /// </param>
    public static void StaffChangePwdSwitch(Window newWindow)
    {
        StaffChangePasswordSwitcher.Navigate(newWindow);
    }

    /// <summary>
    /// Static function that only works for the StaffPersonalInfoSwitch method
    /// Gets newWindow object and uses the built-in navigate windows method to get the window and loads it
    /// Calls the Navigate function written in the StaffChangePersonalInfo cs file and passes the window to it
    /// </summary>
    /// <param name="newWindow">
    /// Type window, represents the desired Window to navigate to
    /// </param>
    public static void StaffChangePersonalInfoSwitch(Window newWindow)
    {
        StaffChangePersonalInfoSwitcher.Navigate(newWindow);
    }

    /// <summary>
    /// Static function that only works for the StaffForgotPwdSwitch method
    /// Gets newWindow object and uses the built-in navigate windows method to ge the window and loads it
    /// Calls the Navigate function written in the StaffForgotPwd cs file and passes the window to it
    /// </summary>
    /// <param name="newWindow">
    /// Type Window, represents the desired window to navigate to
    /// </param>
    public static void StaffForgotPwdSwitch(Window newWindow)
    {
        StaffForgotPasswordSwitcher.Navigate(newWindow);
    }

    /// <summary>
    /// Static function that only works for the StaffPetReport method
    /// Gets newWindow object and uses the built-in navigate windows method to get the window and loads it
    /// Calls the Navigate function written in the StaffPetReport cs file and passes the window to it
    /// </summary>
    /// <param name="newWindow">
    /// Type Window, represents the desired window to navigate to
    /// </param>
    public static void StaffPetReportSwitch(Window newWindow)
    {
        StaffPetReportSwitcher.Navigate(newWindow);
    }

    /// <summary>
    /// Static function that only works for the StaffCreatePetReport method
    /// Gets newWindow object and uses the built-in navigate windows method to get the window and loads it
    /// Calls the Navigate function written in the StaffCreatePetReport cs file and passes the window to it
    /// </summary>
    /// <param name="newWindow">
    /// Type Window, represents the desired window to navigate to
    /// </param>
    public static void StaffCreatePetReportSwitch(Window newWindow)
    {
        StaffCreatePetReportSwitcher.Navigate(newWindow);
    }

    /// <summary>
    /// Static function that only works for the StaffViewPetReport method
    /// Gets newWindow object and uses the built-in navigate windows method to get the window and loads it
    /// Calls the Navigate function written in the StaffViewPetReport cs file and passes the window to it
    /// </summary>
    /// <param name="newWindow">
    /// Type Window, represents the desired window to navigate to
    /// </param>
    public static void StaffViewPetReportSwitch(Window newWindow)
    {
        StaffViewPetReportSwitcher.Navigate(newWindow);
    }

    /// <summary>
    /// Static function that only works for the VolunteerChangeEmail method
    /// Gets newWindow object and uses the built-in navigate windows method to get the window and loads it
    /// Calls the Navigate window written in the VolunteerChangeEmail cs file and passes the window to it
    /// </summary>
    /// <param name="newWindow">
    /// Type window, represents the desired window to navigate to
    /// </param>
    public static void VolunteerChangeEmailSwitch(Window newWindow)
    {
        VolunteerChangeEmailSwitcher.Navigate(newWindow);
    }

    /// <summary>
    /// Static function that only works for the VolunteerChangeEmail method
    /// Gets newWindow object and uses the built-in navigate windows method to get the window and loads it
    /// Calls the Navigate window written in the VolunteerChangeEmail cs file and passes the window to it
    /// </summary>
    /// <param name="newWindow">
    /// Type Window, represents the desired window to navigate to
    /// </param>
    public static void VolunteerChangePwdSwitch(Window newWindow)
    {
        VolunteerChangePwdSwitcher.Navigate(newWindow);
    }

    /// <summary>
    /// Static function that only works for the VolunteerForgotPwd method
    /// Gets newWindow object and uses the built-in navigate windows method to get the window and loads it
    /// Calls the Navigate window written in the VolunteerForgotPassword cs file and passes the window to it
    /// </summary>
    /// <param name="newWindow">
    /// Type Window, represents the desired window to navigate to
    /// </param>
    public static void VolunteerForgotPwdSwitch(Window newWindow)
    {
        VolunteerForgotPasswordSwitcher.Navigate(newWindow);
    }
}