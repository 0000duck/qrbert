using System.Windows.Controls;

namespace QRbert;

public partial class VolunteerPortal : Page
{
    public VolunteerPortal()
    {
        InitializeComponent();
        Page temp = new Page();
        this.Content = temp;
    }
}