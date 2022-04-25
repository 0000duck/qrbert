using System.Windows;

namespace QRbert;

public partial class VolunteerFAQs : Window
{
    public VolunteerFAQs()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Redirects volunteer user via image click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerUserRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectVolunteerPortal();
        this.Close();
    }
}