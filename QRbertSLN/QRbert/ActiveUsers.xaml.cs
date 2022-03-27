using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace QRbert;

public partial class ActiveUsers : Page
{
    String connectionString = @"Data Source = qrbert-rds1.cfe8s1xr87h2.us-west-1.rds.amazonaws.com; 
                                Initial Catalog = QRbertDB; User ID = rds1_admin; Password = rds1_admin;";
    
    public ActiveUsers()
    {
        InitializeComponent();
    }

    // Retrieve list of users with a time punch entry within the last 6 months
    public void GetActiveUsers(object sender, EventArgs e)
    {
        SqlConnection sqlCon = new SqlConnection(connectionString);
        sqlCon.Open();
        
        String query = "SELECT * FROM (SELECT DISTINCT Vol_ID FROM TimeSheet WHERE Date > CAST(DATEADD(m, -6, GETDATE()) as date)) AS ActiveUsers";
        SqlCommand command = new SqlCommand(query, sqlCon);
        
        using (SqlDataReader reader = command.ExecuteReader())
        {
            String result = "";
            while (reader.Read())
            {
                result += String.Format("{0}", reader[0]) + "\n";
            }
        }
    }
}