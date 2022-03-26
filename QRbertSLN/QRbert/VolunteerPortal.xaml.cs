using System;
using System.Windows.Controls;
using System.Windows.Media;

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