using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;

namespace QRbert;

public partial class StaffChangePassword : Page
{
    
    String connectionString = @"Data Source = qrbert-rds1.cfe8s1xr87h2.us-west-1.rds.amazonaws.com; 
                                Initial Catalog = QRbertDB; User ID = rds1_admin; Password = rds1_admin;";
    
    public StaffChangePassword()
    {
        InitializeComponent();
    }

    public void changePassword(object sender, EventArgs e)
    {
        if (currentPasswordIsValid(CurrentPasswordInput.Text))
        {
            var salt = "";
            byte[] bytes = new byte[128 / 8];
            var keyGenerator = RandomNumberGenerator.Create();
            keyGenerator.GetBytes(bytes);
            salt = BitConverter.ToString(bytes).Replace("-", "").ToLower();
            String passwordInfo = ConfirmPasswordInput.Text + salt;
            var pwSha256 = SHA256.Create();
            var pwHashedBytes = pwSha256.ComputeHash(Encoding.UTF8.GetBytes(passwordInfo));
            var passwordHash = BitConverter.ToString(pwHashedBytes).Replace("-", "").ToLower();
            
            SqlConnection sqlCon = new SqlConnection(connectionString);
            String query = "UPDATE Registration SET Salt="+salt+", Password="+passwordHash+" WHERE Email='';";
            SqlCommand command = new SqlCommand(query, sqlCon);
            sqlCon.Open();
            
        }
    }

    private Boolean currentPasswordIsValid(String currentPassword)
    {
        SqlConnection sqlCon = new SqlConnection(connectionString);
        String query = "SELECT Salt, Password FROM Registration;";
        SqlCommand command = new SqlCommand(query, sqlCon);
        sqlCon.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                String salt = String.Format("{0}",reader[0]);
                String DBPassword = String.Format("{0}", reader[1]);
                    
                String passwordInfo = currentPassword + salt;
                var pwSha256 = SHA256.Create();
                var pwHashedBytes = pwSha256.ComputeHash(Encoding.UTF8.GetBytes(passwordInfo));
                var passwordHash = BitConverter.ToString(pwHashedBytes).Replace("-", "").ToLower();

                if (passwordHash == DBPassword)
                {
                    return true;
                }
            }
        }
        return false;
    }
}