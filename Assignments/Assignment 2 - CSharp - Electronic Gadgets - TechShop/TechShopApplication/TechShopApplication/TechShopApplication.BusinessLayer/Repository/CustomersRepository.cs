using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TechShopApplication
{
    internal class CustomersRepository : ICustomersRepository
    {
        private int CustomerID;
        private string FirstName;
        private string LastName;
        private string Email;
        private decimal Phone;
        private string Address;
        
        public void AddCustomer()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter CustomerID: ");
            int customerID = int.Parse(Console.ReadLine());

            Console.Write("Enter First Name:");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name:");
            string lastName = Console.ReadLine();

            Console.Write("Enter Email:");
            string email = Console.ReadLine();

            Console.Write("Enter Phone Number:");
            decimal phone = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Address:");
            string address = Console.ReadLine();

            string sql = $"INSERT INTO Customers VALUES ({customerID}, '{firstName}', '{lastName}', '{email}', {phone}, '{address}')";

            SqlCommand cmd = new SqlCommand(sql, connection);
            int result = cmd.ExecuteNonQuery();

            if (result != 0)
            {
                Console.WriteLine($"Rows affected: {result}");
            }

            connection.Close();
        }
        public void CalculateTotalOrders()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter CustomerID: ");
            int customerID = int.Parse(Console.ReadLine());
            string sql = $"SELECT COUNT(*) FROM Orders WHERE CustomerID={customerID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int total_orders = reader.GetInt32(0);
            Console.WriteLine($"Customer ID: {customerID}, Total Orders: {total_orders}");
            reader.Close();
            connection.Close();
        }

        public void GetCustomerDetails()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter CustomerID: ");
            int customerID = int.Parse(Console.ReadLine());
            string sql = $"SELECT * FROM Customers WHERE CustomerID={customerID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Console.WriteLine($"Customer ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)} {reader.GetString(2)}, Email: {reader.GetString(3)}," +
                              $"Phone: {reader.GetDecimal(4)}, Address: {reader.GetString(5)}");
            reader.Close();
            connection.Close();
        }

        public void UpdateCustomerInfo()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter CustomerID: ");
            int customerID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the field number to update:");
            Console.WriteLine("1. First Name, 2. Last Name, 3. Email, 4. Phone, 5. Address");
            int fieldNumber = int.Parse(Console.ReadLine());
            List<string> columns = new List<string>() { "FirstName", "LastName", "Email", "Phone", "Address" };

            Console.Write("Enter new value: ");
            string newValue = Console.ReadLine();

            string sql;

            if (fieldNumber == 4)
            {
                decimal num = decimal.Parse(newValue);
                sql = $"UPDATE Customers SET {columns[fieldNumber - 1]}={num} WHERE CustomerID={customerID}";
            }
            else
            {
                sql = $"UPDATE Customers SET {columns[fieldNumber - 1]}='{newValue}' WHERE CustomerID={customerID}";
            }

            SqlCommand cmd = new SqlCommand(sql, connection);
            int result = cmd.ExecuteNonQuery();

            if (result != 0)
            {
                Console.WriteLine($"Rows affected: {result}");
            }

            connection.Close();
        }
    }
}
