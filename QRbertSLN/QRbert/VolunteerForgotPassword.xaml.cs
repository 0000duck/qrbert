using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class VolunteerForgotPassword : Window
{
    private string randomCode;
    public static string to;
    
    public VolunteerForgotPassword()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// Redirects volunteer user to their MyAccount window via a button click on the menu item
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerMyAcctBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerMyAccount());
        this.Close();
    }

    /// <summary>
    /// Logs out Volunteer and redirects user to the Log In page via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogOutSwitch();
        this.Close();
    }

    /// <summary>
    /// Redirects user to home page - volunteer portal via QRbert image click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeVolunteerPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectVolunteerPortal();
        this.Close();
    }
    
    /// <summary>
    /// Redirects user to view timesheet window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewTimesheetBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerViewTimesheets());
        this.Close();
    }

    /// <summary>
    /// Redirects user to scan pet qr code window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScanPetQRCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        this.Close();
    }

    /// <summary>
    /// Redirects user to pet report window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetReportBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        this.Close();
    }
    
    /// <summary>
    /// Redirects user to the FAQ window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FAQRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerFAQs());
        Close();
    }

    /// <summary>
    /// Sends a code to a user to input to reset their password
    /// Uses SMTP to send code fro mmy personal email, but we could set one up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SendCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        string from, pass, messageBody;

        Random rand = new Random();
        randomCode = (rand.Next(999999)).ToString();
        MailMessage message = new MailMessage();
        to = Switcher.CurrentSessionEmail;
        from = "matt.zaldana@gmail.com";
        pass = "QRbert Temporary Code";
        messageBody = "Hello, this is QRbert. " +
                      "If you have received this message, please input the following " +
                      "6 digit code in the textbox in the QRbert window: " + randomCode;
        message.To.Add(to);
        message.From = new MailAddress(from);
        message.Body = messageBody;
        message.Subject = "QRbert Temporary code";
        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        smtp.EnableSsl = true;
        smtp.Port = 587;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Credentials = new NetworkCredential(from, pass);
        try
        {
            smtp.Send(message);
            MessageBox.Show("Please check your email for your 6 digit code.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method that checks if inputted code is correct
    /// Redirects user to ChangePassword window if it is, otherwise, resets the textbox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void EnterCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        if (randomCode == EnterCodeInput.Text)
        {
            Switcher.VolunteerPortalSwitch(new VolunteerChangePassword());
            this.Close();
        }
        else
        {
            MessageBox.Show("Wrong code. Try again.");
            EnterCodeInput.Text = "";
        }
    }
}