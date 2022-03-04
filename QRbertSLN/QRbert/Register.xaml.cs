using System;
using System.Data;
using System.Windows.Controls;
using System.Windows;
using System.Data.SqlClient;


//using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;


namespace QRbert;

public partial class Register : Page
{
    // connects DB to Register Page
  String connectionString = @"Data Source = qrbert-rds1.cfe8s1xr87h2.us-west-1.rds.amazonaws.com; 
                                Initial Catalog = QRbertDB; User ID = rds1_admin; Password = rds1_admin;";


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


            using SqlConnection sqlCon = new SqlConnection(connectionString);

            sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand("RegUser", sqlCon);

            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            sqlCmd.Parameters.AddWithValue("@Faculty_Role", txtFacultyRole.Text);
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text);

            sqlCmd.ExecuteNonQuery();
            MessageBox.Show("Sign Up Complete ");

        }

    }

}




