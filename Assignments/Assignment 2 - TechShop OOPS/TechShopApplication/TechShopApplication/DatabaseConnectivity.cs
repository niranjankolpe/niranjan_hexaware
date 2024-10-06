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
        private static string connectionString = "Data Source=DESKTOP-55ISL9F;Initial Catalog=TechShopDB;Integrated Security=True;";
        private static DatabaseConnectivity dbInstance = null;
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlDataReader;
        private DataTable dt;

        public DatabaseConnectivity()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand("", sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
        }
        public DatabaseConnectivity getDBInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new DatabaseConnectivity();
            }
            return dbInstance;
        }

        public DataTable getTableData(string sqlStatement)
        {
            dt = new DataTable();
            sqlConnection.Open();
            sqlCommand.CommandText = sqlStatement;
            dt.Clear();
            dt.Load(sqlCommand.ExecuteReader());
            sqlConnection.Close();
            return dt;
        }

        public int executeQuery(string sqlStatement) { 
            sqlConnection.Open();
            sqlCommand.CommandText = sqlStatement;
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }
    }
}
