using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class Customers
    {
        private readonly string connectionString = "Data Source=DESKTOP-55ISL9F;Initial Catalog=TechShopDB;Integrated Security=True;";

        private int CustomerID;
        private string FirstName;
        private string LastName;
        private string Email;
        private decimal Phone;
        private string Address;

        internal int _CustomerID {  get; set; }
        internal string _FirstName { get; set; }
        internal string _LastName { get; set; }
        internal string _Email { get; set; }
        internal decimal _Phone { get; set; }
        internal string _Address { get; set; }
        public Customers()
        {
            this.CustomerID = 0;
            this.FirstName = String.Empty;
            this.LastName = String.Empty;
            this.Email = String.Empty;
            this.Phone = 0;
            this.Address = String.Empty;
        }
        public Customers(int customerID, string firstName, string lastName, string email, decimal phone, string address)
        {
            this.CustomerID = customerID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }

        
        public void CalculateTotalOrders()
        {
            SqlConnection connection = new SqlConnection(connectionString);
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
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.Write("Enter CustomerID: ");
            int customerID = int.Parse(Console.ReadLine());
            string sql = $"SELECT * FROM Customers WHERE CustomerID={customerID}";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            this.CustomerID = reader.GetInt32(0);
            this.FirstName = reader.GetString(1);
            this.LastName = reader.GetString(2);
            this.Email = reader.GetString(3);
            this.Phone = reader.GetDecimal(4);
            this.Address = reader.GetString(5);
            Console.WriteLine($"Customer ID: {this.CustomerID}, Name: {this.FirstName} {this.LastName}, Email: {this.Email}, Phone: {this.Phone}, Address: {this.Address}");
            reader.Close();
            connection.Close();
        }

        public void UpdateCustomerInfo()
        {
            Console.Write("Enter CustomerID: ");
            int customerID = int.Parse(Console.ReadLine());

            List<string> columnsList = new List<string> { "CustomerID", "FirstName", "LastName", "Email", "Phone", "Address" };
            Console.WriteLine("Enter the number of the field you wish to update:\n1. Customer ID, 2. First Name, 3. Last Name" +
                "4. Email, 5. Phone, 6. Address");
            int field_number = int.Parse(Console.ReadLine());
            Console.Write("Enter new value: ");
            string new_field_value = Console.ReadLine();
            switch(field_number)
            {
                case 1:
                    this.CustomerID = int.Parse(new_field_value);
                    break;
                case 2:
                    this.FirstName = new_field_value;
                    break;
                case 3:
                    this.LastName = new_field_value;
                    break;
                case 4:
                    this.Email = new_field_value;
                    break;
                case 5:
                    this.Phone = decimal.Parse(new_field_value);
                    break;
                case 6:
                    this.Address = new_field_value;
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string columnName = columnsList[field_number - 1];
            string sql = string.Empty;
            if (columnName == "CustomerID" | columnName=="Phone")
            {
                sql = $"UPDATE Customers SET {columnName}={new_field_value} WHERE CustomerID={customerID}";
            }
            else
            {
                sql = $"UPDATE Customers SET {columnName}='{new_field_value}' WHERE CustomerID={customerID}";
            }
            
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            reader.Close();
            connection.Close();
            Console.WriteLine("Data Updated Successfully!");
        }
    }
}
