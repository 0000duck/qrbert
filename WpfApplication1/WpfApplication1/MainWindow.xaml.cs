using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        // private string ConnectionString ="Integrated Security=SSPI;" +  
                                         // "Initial Catalog=;" +  
                                         // "Data Source=localhost;";  
        // private SqlDataReader reader = null;   
        private SqlConnection conn = null;   
        private SqlCommand cmd = null;  
        // private System.Windows.Forms.Button AlterTableBtn;  
        private string sql = null;  
        // private System.Windows.Forms.Button CreateOthersBtn;  
        // private System.Windows.Forms.Button button1; 
        
        /*
        private void ExecuteSQLStmt(string sql)  
        {  
            if (conn.State == ConnectionState.Open)  
                conn.Close();  
            ConnectionString = "Integrated Security=SSPI;" +  
                               "Initial Catalog=mydb;" +  
                               "Data Source=localhost;";  
            conn.ConnectionString = ConnectionString;  
            conn.Open();  
            cmd = new SqlCommand(sql, conn);  
            try  
            {  
                cmd.ExecuteNonQuery();  
            }  
            catch (SqlException ae)  
            {  
                MessageBox.Show(ae.Message.ToString());  
            }  
        }
        */ 
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void CreateTableInDB_Click(object sender, RoutedEventArgs e)
        {
            /*
            // Create a connection  
            conn = new SqlConnection(ConnectionString);  
            // Open the connection  
            if (conn.State != ConnectionState.Open)  
                conn.Open();  
            string sql_create = "CREATE DATABASE mydb ON PRIMARY"  
                         + "(Name=test_data, filename = 'C:\\mysql\\mydb_data.mdf', size=3,"  
                         + "maxsize=5, filegrowth=10%)log on"  
                         + "(name=mydbb_log, filename='C:\\mysql\\mydb_log.ldf',size=3,"  
                         + "maxsize=20,filegrowth=1)";  
            ExecuteSQLStmt(sql_create);

            conn.ConnectionString = ConnectionString;
            conn.Open();
            */
            
            // here i will add code that creates a table in the db
            string sql = "CREATE TABLE TableTest1" +
                      "(Staff_QRCodeID INTEGER CONSTRAINT PKeySQRCodeID PRIMARY KEY, " +
                      "Staff_FirstName CHAR(50), Staff_Address CHAR(255)";
            cmd = new SqlCommand(sql, conn);
            
            
            MessageBox.Show("Arrived at line 27...");
            try
            {
                MessageBox.Show("Goes into the try statement...");
                cmd.ExecuteNonQuery();

                sql = "INSERT INTO TableTest1(Staff_QRCodeID, Staff_FirstName, Staff_Address)" +
                      "VALUES (1001, 'David Eaton', '1001 Main St, Long Beach')";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "INSERT INTO TableTest1(Staff_QRCodeID, Staff_FirstName, Staff_Address)" +
                      "VALUES (1002, 'Denise Paredes', '1002 Main St, Long Beach')";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "INSERT INTO TableTest1(Staff_QRCodeID, Staff_FirstName, Staff_Address)" +
                      "VALUES (1003, 'Jonathan Saucedo', '1003 Main St, Long Beach')";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "INSERT INTO TableTest1(Staff_QRCodeID, Staff_FirstName, Staff_Address)" +
                      "VALUES (1004, 'Marisol Tejada', '1004 Main St, Long Beach')";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "INSERT INTO TableTest1(Staff_QRCodeID, Staff_FirstName, Staff_Address)" +
                      "VALUES (1005, 'Matthew Zaldana', '1005 Main St, Long Beach')";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Created Database table successfully!");
            }
            catch (SqlException ae)
            {
                MessageBox.Show(ae.Message.ToString());
            }

            MessageBox.Show("Arrived at line 63...");
        }
        private void AddDataToDB_Click(object sender, RoutedEventArgs e)
        { 
            // here i will add code that adds data to the db
        }

        private void RetrieveDataFromDB_Click(object sender, RoutedEventArgs e)
        {
         // here i will add code that retrieves data from the db
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
         // here i will add code that exits the application
        }
        
        // code below might not work
        /*
         public InsertDataTo_qrbert_rds1()
        {
            /*
             * Define vars
             #1#
            SqlCommand command;     // creates command var from the SQLCommand class
            SqlDataAdapter adapter = new SqlDataAdapter();      //creates instance of SQLDataAdapter
            String sql = "";        // creates sql var as String to hold sql statement

            /*
             * Define the insert statement
             #1#
            sql = "Insert into TestDB1 (StaffQRCodeID, StaffFullName) values(1234567890, "Matthew Zaldana")";
            
            /*
             * Define the sql command
             #1#
            command = new SqlCommand(sql);
            
            /*
             * Associate the insert command
             #1#
            adapter.InsertCommand = new SqlCommand(sql);
            adapter.InsertCommand.ExecuteNonQuery();
            
            /*
             * Close all objects
             #1#
            command.Dispose();
        }*/
    
    }
}