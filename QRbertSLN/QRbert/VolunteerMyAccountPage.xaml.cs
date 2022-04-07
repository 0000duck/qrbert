using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class VolunteerMyAccountPage : Page
{
    public VolunteerMyAccountPage()
    {
        InitializeComponent();
        Switcher.volunteerMyAccountPageSwitcher = this;
    }
    
    /// <summary>
    /// Public function that allows to navigate to the next desired page
    /// </summary>
    /// <param name="nextPage">
    /// Type Page, represents the next page to redirect to
    /// </param>
    public void Navigate(Page nextPage)
    {
        this.Content = nextPage;
    }
    
    /// <summary>
    /// Redirects volunteer to VolunteerChangeEmail page so that they may change their email
    /// Since the MyAccount and the ChangeEmail contents are pages, we should be able to change the content easily
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerChangeEmailBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerMyAccountPageSwitch(new VolunteerChangeEmail());
    }

    /// <summary>
    /// Redirects volunteer to change their password via the button click
    /// Since this content and the ChangePassword forms are both pages, we should be able to navigate to them easily
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerChangePasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        // Missing Change Password page, waiting on Marisol
    }

    /// <summary>
    /// I don't know what the difference is and left a messagebox to reflect that...
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerForgotPasswordBtn_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Um, what's the difference between the one above and this one?");
    }

    /// <summary>
    /// Redirects volunteer to change their personal info on the ChangePersonalInfo page via a button click
    /// Since the current content and the ChangePersonalInfo forms are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerChangePersonalInfoBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerMyAccountPageSwitch(new VolunteerChangePersonalInformation());
    }
}