using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class Products
    {
        private int ProductID;
        private string ProductName;
        private string Description;
        private int Price;


        internal int _ProductID {  get; set; }

        internal int _ProductName { get; set; }

        internal string _Description { get; set; }

        internal int _Price { get; set; }

        public Products()
        {
            this.ProductID = 0;
            this.ProductName = string.Empty;
            this.Description = string.Empty;
            this.Price = 0;
        }
        public Products(int productID, string productName, string description, int price)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Description = description;
            this.Price = price;
        }

        public void GetProductDetails()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Product ID: ");
            int productID = int.Parse(Console.ReadLine());
            string sql = $"SELECT * FROM Products WHERE ProductID={productID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Console.WriteLine($"Product ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)}, Description: {reader.GetString(2)}, Price: {reader.GetInt32(3)}\n");

            reader.Close();
            connection.Close();
        }

        public void UpdateProductInfo()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter ProductID: ");
            int productID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the field number to update:");
            Console.WriteLine("1. Product ID, 2. Product Name, 3. Description, 4. Price");
            int fieldNumber = int.Parse(Console.ReadLine());
            List<string> columns = new List<string>() { "ProductID", "ProductName", "Description", "Price"};

            Console.Write("Enter new value: ");
            string newValue = Console.ReadLine();

            string sql;

            if (fieldNumber == 1 || fieldNumber == 4)
            {
                decimal num = decimal.Parse(newValue);
                sql = $"UPDATE Products SET {columns[fieldNumber - 1]}={num} WHERE ProductID={productID}";
            }
            else
            {
                sql = $"UPDATE Products SET {columns[fieldNumber - 1]}='{newValue}' WHERE ProductID={productID}";
            }

            SqlCommand cmd = new SqlCommand(sql, connection);
            int result = cmd.ExecuteNonQuery();

            if (result != 0)
            {
                Console.WriteLine($"Rows affected: {result}");
            }

            connection.Close();
        }

        public void IsProductInStock()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter ProductID: ");
            int productID = int.Parse(Console.ReadLine());

            string sql = $"SELECT QuantityInStock FROM Inventory WHERE ProductID={productID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                Console.WriteLine($"Quantity in Stock: {reader.GetInt32(0)}");
            }
            connection.Close();
        }
    }
}
