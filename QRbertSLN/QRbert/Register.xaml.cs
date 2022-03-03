using System;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class Register : Page
{
    public Register()
    {
        InitializeComponent();
    }
    
    public static bool isPresent(string textBox, string textBoxName)
    {
        if (textBox == null || textBox == "")
        {
            MessageBox.Show(textBoxName + " is required.");
            //textBox.Focus();
            return false;
        }

        return true;
    }
    public static bool isDecimal(string textBox)
    {
        decimal number = 0m;
        if (Decimal.TryParse(textBox, out number))
        {
            return true;
        }
        else
        {
            MessageBox.Show(textBox + " must be a decimal value.");
            //textBox.Focus();
            return false;
        }
    }

    public static bool IsInt32(string textBox)
    {
        int number = 0;
        if (Int32.TryParse(textBox, out number))
        {
            return true;
        }
        else
        {
            MessageBox.Show(textBox + " must be an integer.");
            //textBox.Focus();
            return false;
        }
    }

    public static bool IsWithinRange(string textBox, decimal min, decimal max)
    {
        //decimal number = Convert.ToDecimal(textBox.Text);

        int number = textBox.Length;

        if (number < min || number > max)
        {
            MessageBox.Show(textBox + " must be between " + min
                            + " and " + max + ".");
            //textBox.Focus();
            return false;
        }
        return true;
    }

    public static bool IsValidEmail(string textBox)
    {
        if (textBox.IndexOf("@") == -1 ||
            textBox.IndexOf(".") == -1)
        {
            MessageBox.Show(textBox + " must be a valid email address.");
            //textBox.Focus();
            return false;
        }
        else
        {
            return true;
        }
        
    }

    private void clearFirstName(object sender, RoutedEventArgs e)
    {
        
    }
    public void RemoveText(object sender, EventArgs e)
    {
        if (RegFirst.Text == "Enter text here...") 
        {
            RegFirst.Text = "";
        }
    }

    public void AddText(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(RegFirst.Text))
            RegFirst.Text = "Enter text here...";
    }


}