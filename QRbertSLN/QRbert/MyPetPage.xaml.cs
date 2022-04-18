using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Reflection.Emit;
using Label = System.Windows.Controls.Label;


namespace QRbert;

public partial class SelectAPet : Window
{
    string connectionString = @"Data Source = qrbert-rds1.cfe8s1xr87h2.us-west-1.rds.amazonaws.com; 
                                Initial Catalog = QRbertDB; User ID = rds1_admin; Password = rds1_admin;";
    public SelectAPet()
    {
        
        InitializeComponent();
    }
    private void HomeStaffPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private void StaffMyAccountBtn_Click(object sender, RoutedEventArgs e)
    {
        
    }
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private void ViewPetBtn_Click(object sender, RoutedEventArgs e)
    {
        
        string petNameInput = txtFindPetBlock.Text;
        using SqlConnection sqlCon = new SqlConnection(connectionString);
        sqlCon.Open();
        string petDml = ("Select PetName From QRbertTables.Pet Where petName = '" + petNameInput  +
                         "'");
        SqlCommand command = new SqlCommand(petDml, sqlCon);

        int results = command.ExecuteNonQuery();
        //  string msg = verifyPet("Select PetName From QRbertTables.Pet Where petName = '" + petNameInput  +
                           //   "'");
        MessageBox.Show(results.ToString());
        PetName.Content = " Pet Name: " + petDml;

    }
}