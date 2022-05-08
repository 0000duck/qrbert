using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class UserForgotPassword : Window
{
    private string randomCode;
    private static string to;
    public UserForgotPassword()
    {
        InitializeComponent();
        MessageBox.Show("Reminder: you can log in with your unique QR Code.");
        SignInBtn.Visibility = Visibility.Hidden;
    }

    /// <summary>
    /// Takes user back to the Log In page if desired
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void QRbertLogInImage_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogIn_RegisterSwitch(new LogIn_Register());
        this.Close();
    }

    /// <summary>
    /// Sends code to user to verify email authenticity
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
    /// Method that checks if inputted code is the correct code
    /// Redirects user to ChangePassword window if it is, otherwise, resets the textbox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void EnterCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        if (randomCode == EnterCodeInput.Text)
        {
            SignInBtn.Visibility = Visibility.Visible;
        }
        else
        {
            MessageBox.Show("Wrong code. Try again.");
            EnterCodeInput.Text = "";
        }
    }

    private void EmailInput_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtEmail.Visibility = Visibility.Visible;
        if (EmailInput.Text.Length > 0)
        {
            EmailInput.Visibility = Visibility.Hidden;
        }
    }

    private void EnterCodeInput_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        txtEnterCode.Visibility = Visibility.Visible;
        if (EnterCodeInput.Text.Length > 0)
        {
            EnterCodeInput.Visibility = Visibility.Hidden;
        }
    }
}