using System.Windows;

namespace QRbert;

public partial class FAQs : Window
{
    public FAQs()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Redirects staff user to staff portal after clicking image
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffPortalRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectStaffPortal();
        this.Close();
    }
}