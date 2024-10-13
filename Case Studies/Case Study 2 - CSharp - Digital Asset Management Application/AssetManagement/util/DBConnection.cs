using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace AssetManagement
{
    internal class DBConnection
    {
        public static string getConnectionProperty(string filename)
        {
            string text = string.Empty;
            try {
                text = File.ReadAllText(filename);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to get connection string!\n{ex.ToString()}");
            }
            return text;
        }
        public static SqlConnection getConnection()
        {
            string connectionString = getConnectionProperty(@"C:\\Users\\niran\\Desktop\\My Files\\Hexaware\\Codes\\GitHub Repository\\Case Studies\\Case Study 2 - CSharp - Digital Asset Management Application\\AssetManagement\\util\\AssetManagementDBConnectionString.txt");
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
