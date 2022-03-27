using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using Microsoft.SqlServer.Server;

namespace QRbert;

public partial class StaffSearch : Page
{
    
    /*
    * connects DB to Register Page
    * Data source is the name of the DB server
    * Initial Catalog the QRbert database we want to connect to
    * User name and Password -> temp log in solution until we find a more secure way to log into the DB
    * so that the log in credentials aren't in the code for all to see
    */ 
    String connectionString = @"Data Source = qrbert-rds1.cfe8s1xr87h2.us-west-1.rds.amazonaws.com; 
                                Initial Catalog = QRbertDB; User ID = rds1_admin; Password = rds1_admin;";
    
    public StaffSearch()
    {
        InitializeComponent();
    }
    
    public static bool isSearchValid(string text)
    {
        return checkString(text);
    }
    
    public static bool checkString(string words)
    {
        if (words == null || words == "")
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }
    
    private void Search(object sender, EventArgs e)
    {
        if (!isSearchValid(SearchInput.Text))
        {
            MessageBox.Show("Please enter search text");
        }
        else
        {
            using SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT * FROM Volunteer WHERE FirstName="+SearchInput.Text+";";
            SqlCommand command = new SqlCommand(query, sqlCon);
            sqlCon.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MessageBox.Show(String.Format("{0}",reader[0]));
                }
            }
            
        }
    }
}