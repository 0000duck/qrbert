using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace QRbert;

public partial class VolunteerPortal : Window
{
    public VolunteerPortal()
    {
        InitializeComponent();
        Switcher.volunteerpageSwitcher = this;
    }
    
    /// <summary>
    /// Redirects volunteer user to their MyAccountPage via a button click on the menu item
    /// Since the portal and the MyAccount page are both Pages, we should be able to save the previous pages visited
    /// and go back to them if needed
    ///
    /// Scratch the above, this comment was for the commented out code in the function that creates a page and
    /// makes the content change to that page
    /// Currently, we can switch to the page given the code that functions below and written in the Switcher class
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerAcctPageRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPageSwitch(new VolunteerMyAccountPage());
        /*
        Page redirectVolunteerMyAcctPage = new VolunteerMyAccountPage();
        this.Content = redirectVolunteerMyAcctPage;
        */
    }

    public void Navigate(Page nextPage)
    {
        this.Content = nextPage;
    }
    
    
}