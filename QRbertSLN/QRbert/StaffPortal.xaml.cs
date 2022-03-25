using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class StaffPortal : Window
{
    public StaffPortal()
    {
        InitializeComponent();
        Switcher.staffpageSwitcher = this;
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
    /// Redirects staff to their MyAccount page via button click
    /// Since the portal and the MyAccount are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffMyAccountPageBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccountPage());
    }

}