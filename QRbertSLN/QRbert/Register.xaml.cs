using System;
using System.Data;
using System.Windows.Controls;
using System.Windows;
using System.Data.SqlClient;

namespace QRbert;

public partial class Register : Page
{
    // connects DB to Register Page
    string connectionString = @"Data Source = qrbert-rds1; Initial Catolog = QRbertDB; User ID = rds1_admin;
                                    Password = rds1_admin";

   // SqlConnection cnn = new SqlConnection (@"Data Source = qrbert-rds1; Initial Catolog = QRbertDB; User ID = rds1_admin;Password = rds1_admin");

    public Register()
    {
        InitializeComponent();
    }
    
    // Link the "sign Up" button to DB to save user registration info
    private void RegUser_Button(object sender, EventArgs e)
    {
       if (txtEmail.Text == "" || txtPassword.Text == "")
            MessageBox.Show("Please fill out all mandatory fields");
        else if (txtPassword.Text != txtConfirmPassword.Text)
            MessageBox.Show("Passwords Do Not Match");
        else
        {


            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("RegUser", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Sign Up Complete ");
                Clear();
            }
        }
    }

    void Clear()
    {
        txtFirstName.Text = txtLastName.Text = txtEmail.Text = txtPassword.Text = txtConfirmPassword.Text = "";
    }
    
}




