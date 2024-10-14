using System.Data.SqlClient;
using System.Configuration;

namespace AssetManagement.Util
{
    public class DBConnection
    {
        // Function to get Connection String from AppConfig
        public static string GetConnectionProperty()
        {
            return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        }

        // Function to get DB Connection
        public static SqlConnection GetConnection()
        {
            string connectionString = GetConnectionProperty();
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
