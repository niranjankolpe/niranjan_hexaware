using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace AssetManagement
{
    public class DBConnection
    {
        // Function to get Connection String from AppConfig
        public static string GetConnectionProperty(string filename)
        {
            string text = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            return text;
        }

        // Function to get DB Connection
        public static SqlConnection GetConnection()
        {
            string connectionString = GetConnectionProperty(@"C:\\Users\\niran\\Desktop\\My Files\\Hexaware\\Codes\\GitHub Repository\\Case Studies\\Case Study 2 - CSharp - Digital Asset Management Application\\AssetManagement\\util\\AssetManagementDBConnectionString.txt");
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
