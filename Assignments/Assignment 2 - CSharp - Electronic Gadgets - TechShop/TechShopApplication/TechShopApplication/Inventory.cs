using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class Inventory
    {
        private int InventoryID;
        private int ProductID;
        private int QuantityInStock;
        private DateTime LastStockUpdate;

        internal int _InventoryID {  get; set; }

        internal int _ProductID { get; set; }

        internal int _QuantityInStock { get; set; }

        internal DateTime _LastStockUpdate {  get; set; }

        public Inventory()
        {
            this.InventoryID = 0;
            this.ProductID = 0;
            this.QuantityInStock = 0;
            this.LastStockUpdate = DateTime.Now;
        }

        public Inventory(int inventoryID, int productID, int quantityInStock, DateTime lastStockUpdate)
        {
            this.InventoryID = inventoryID;
            this.ProductID = productID;
            this.QuantityInStock = quantityInStock;
            this.LastStockUpdate = lastStockUpdate;
        }
        public void GetProduct()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Product ID: ");
            int productID = int.Parse(Console.ReadLine());
            string sql = $"SELECT * FROM Inventory WHERE ProductID={productID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Console.WriteLine($"Inventory ID: {reader.GetInt32(0)}, Product ID: {reader.GetInt32(1)}, Quantity In Stock: {reader.GetInt32(2)}, Last Stock Update: {reader.GetDateTime(3)}");

            reader.Close();
            connection.Close();
        }

        public void GetQuantityInStock()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Product ID: ");
            int productID = int.Parse(Console.ReadLine());
            string sql = $"SELECT QuantityInStock FROM Inventory WHERE ProductID={productID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Console.WriteLine($"Quantity In Stock: {reader.GetInt32(0)}");

            reader.Close();
            connection.Close();
        }

        public void AddToInventory()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Product ID: ");
            string productID = Console.ReadLine();

            Console.Write("Enter Quantity to add: ");
            int quantity = int.Parse(Console.ReadLine());

            string sql = $"UPDATE Inventory SET QuantityInStock=QuantityInStock+{quantity} WHERE ProductID={productID}";
            SqlCommand cmd = new SqlCommand(sql, connection);
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine($"Rows affected: {result}");
            connection.Close();
        }

        public void RemoveFromInventory()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Product ID: ");
            string productID = Console.ReadLine();

            Console.Write("Enter Quantity to remove: ");
            int quantity = int.Parse(Console.ReadLine());

            string sql = $"UPDATE Inventory SET QuantityInStock=QuantityInStock-{quantity} WHERE ProductID={productID}";
            SqlCommand cmd = new SqlCommand(sql, connection);
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine($"Rows affected: {result}");
            connection.Close();
        }

        public void UpdateStockQuantity()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Inventory ID: ");
            int inventoryID = int.Parse(Console.ReadLine());

            Console.Write("Enter new Stock Quantity:");
            int quantity = int.Parse(Console.ReadLine());

            string sql = $"UPDATE Inventory SET QuantityInStock={quantity} WHERE InventoryID={inventoryID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            int result = cmd.ExecuteNonQuery();

            Console.WriteLine($"Rows affected: {result}");

            connection.Close();
        }


        public void IsProductAvailable()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Product ID: ");
            int productID = int.Parse(Console.ReadLine());

            Console.Write("Enter Quantity to check: ");
            int quantityToCheck = int.Parse(Console.ReadLine());
            string sql = $"SELECT QuantityInStock FROM Inventory WHERE ProductID={productID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            if (reader.GetInt32(0) >= quantityToCheck)
            {
                Console.WriteLine("Quantity is available!");
            }
            else
            {
                Console.WriteLine("Quantity is unavailable!");
            }

            reader.Close();
            connection.Close();
        }


        public void GetInventoryValue()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Product ID: ");
            int productID = int.Parse(Console.ReadLine());
            string sql = $"SELECT QuantityInStock FROM Inventory WHERE ProductID={productID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader1 = cmd.ExecuteReader();
            reader1.Read();
            int quantityInStock = reader1.GetInt32(0);
            reader1.Close();

            sql = $"SELECT Price FROM Products WHERE ProductID={productID}";
            cmd.CommandText = sql;
            SqlDataReader reader2 = cmd.ExecuteReader();
            reader2.Read();
            int price = reader2.GetInt32(0);


            Console.WriteLine($"Product ID: {productID}, Value: {quantityInStock*price}");

            reader2.Close();
            connection.Close();
        }

        public void ListLowStockProducts()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Product Low Threshold: ");
            int threshold = int.Parse(Console.ReadLine());

            string sql = $"SELECT ProductID, QuantityInStock FROM Inventory WHERE QuantityInStock<={threshold}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                Console.WriteLine($"Product ID: {reader.GetInt32(0)}, Quantity In Stock: {reader.GetInt32(1)}");
            }

            reader.Close();
            connection.Close();
        }


        public void ListOutOfStockProducts()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            string sql = $"SELECT ProductID, QuantityInStock FROM Inventory WHERE QuantityInStock=0";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Product ID: {reader.GetInt32(0)}, Quantity In Stock: {reader.GetInt32(1)}");
            }

            reader.Close();
            connection.Close();
        }


        public void ListAllProducts()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            string sql = $"SELECT * FROM Inventory";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Inventory ID: {reader.GetInt32(0)}, Product ID: {reader.GetInt32(1)}, Quantity In Stock: {reader.GetInt32(2)}, Last Stock Update: {reader.GetDateTime(3)}");
            }

            reader.Close();
            connection.Close();
        }
}
}
