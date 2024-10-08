using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class DatabaseConnectivity
    {
        public static SqlConnection GetDBConnection()
        {
            string connectionString = "Data Source=DESKTOP-55ISL9F;Initial Catalog=TechShopDB;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
