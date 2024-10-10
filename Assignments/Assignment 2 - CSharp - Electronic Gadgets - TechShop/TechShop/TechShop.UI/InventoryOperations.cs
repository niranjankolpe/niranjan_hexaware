using System;
using System.Data.SqlClient;

namespace TechShop
{
    public static class InventoryOperations
    {
        public static void SyncInventory(InventoryService inventoryService)
        {
            try
            {
                SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                connection.Open();
                string sql = $"SELECT * FROM Inventory";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Inventory inventory = new Inventory();
                    inventory.InventoryID = (int)reader["InventoryID"];
                    inventory.ProductID = (int)reader["ProductID"];
                    inventory.QuantityInStock = (int)reader["QuantityInStock"];
                    inventory.LastStockUpdate = (DateTime)reader["LastStockUpdate"];

                    Console.WriteLine($"Inventory ID: {inventory.InventoryID}, Product ID: {inventory.ProductID}, Stock Quantity: {inventory.QuantityInStock}, Last Stock Updated: {inventory.LastStockUpdate}");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void AddToInventory(InventoryService inventoryService)
        {
            try
            {
                SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                connection.Open();

                Console.Write("Enter Product ID: ");
                int productID = int.Parse(Console.ReadLine());

                Console.Write("Enter Quantity to add: ");
                int quantity = int.Parse(Console.ReadLine());

                string sql = $"UPDATE Inventory SET QuantityInStock=QuantityInStock+{quantity} WHERE ProductID={productID}";
                SqlCommand cmd = new SqlCommand(sql, connection);
                int result = cmd.ExecuteNonQuery();
                if(result == 1)
                {
                    Console.WriteLine("Inventory updated successfully!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void RemoveFromInventory(InventoryService inventoryService)
        {
            try
            {
                SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                connection.Open();

                Console.Write("Enter Product ID: ");
                int productID = int.Parse(Console.ReadLine());

                string sql = $"DELETE FROM Inventory WHERE ProductID={productID}";
                SqlCommand cmd = new SqlCommand(sql, connection);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Console.WriteLine("Inventory Product deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void UpdateInventoryQuantity(InventoryService inventoryService)
        {
            try
            {
                SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                connection.Open();

                Console.Write("Enter Product ID: ");
                int productID = int.Parse(Console.ReadLine());

                Console.Write("Enter new Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                string sql = $"UPDATE Inventory SET QuantityInStock={quantity} WHERE ProductID={productID}";
                SqlCommand cmd = new SqlCommand(sql, connection);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Console.WriteLine("Inventory updated successfully!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void CheckProductAvailability(InventoryService inventoryService)
        {
            try
            {
                SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                connection.Open();

                Console.Write("Enter Product ID: ");
                int productID = int.Parse(Console.ReadLine());

                string sql = $"SELECT QuantityInStock FROM Inventory WHERE ProductID={productID}";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine($"Current Product Quantity: {reader.GetInt32(0)}");
                }
                else
                {
                    Console.WriteLine("Data unavailable.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}