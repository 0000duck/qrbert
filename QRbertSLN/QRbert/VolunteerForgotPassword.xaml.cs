using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class VolunteerForgotPassword
{
    private string _randomCode = "";

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
        Close();
    }

    /// <summary>
    /// Logs out Volunteer and redirects user to the Log In page via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogOutSwitch();
        Close();
    }

    /// <summary>
    /// Redirects user to home page - volunteer portal via QRbert image click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeVolunteerPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectVolunteerPortal();
        Close();
    }
    
    /// <summary>
    /// Redirects user to view timesheet window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewTimesheetBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerViewTimesheets());
        Close();
    }

    /// <summary>
    /// Redirects user to scan pet qr code window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScanPetQRCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        Close();
    }

    /// <summary>
    /// Redirects user to pet report window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetReportBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        Close();
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
        Random rand = new Random();
        _randomCode = rand.Next(999999).ToString();
        var fromAddress = new MailAddress("qrbert.thedreamteam@gmail.com", "QRbert by The Dream Team");
        var toAddress = new MailAddress(Switcher.CurrentSessionEmail, Switcher.CurrentSessionEmail);
        const string fromPassword = "qrbert.thedreamteam1!";
        const string subject = "QRbert - 6 Digit code";
        string msgBody = "Hello, this is QRbert. " +
                         "If you have received this message, please input the following " +
                         "6 digit code in the textbox in the QRbert window: " + _randomCode;
        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            Timeout = 20000
        };
        using (var message = new MailMessage(fromAddress, toAddress))
        {
            message.Subject = subject;
            message.Body = msgBody;
            smtp.Send(message);
            MessageBox.Show("Code sent. Please check your email.");
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
        if (_randomCode == EnterCodeInput.Text)
        {
            Switcher.VolunteerPortalSwitch(new VolunteerChangePassword());
            Close();
        }
        else
        {
            MessageBox.Show("Wrong code. Try again.");
            EnterCodeInput.Text = "";
        }
    }

    private void EnterCodeInput_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtEnterCode.Visibility = Visibility.Visible;
        if (EnterCodeInput.Text.Length > 0)
        {
            txtEnterCode.Visibility = Visibility.Hidden;
        }
    }
}