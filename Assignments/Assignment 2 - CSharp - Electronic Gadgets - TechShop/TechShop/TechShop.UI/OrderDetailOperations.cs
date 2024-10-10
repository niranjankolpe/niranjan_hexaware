using System;
using System.Data.SqlClient;

namespace TechShop
{
    public static class OrderDetailOperations
    {
        public static void GetOrderDetail(OrderDetailsService orderDetailsService)
        {
            try
            {
                SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                connection.Open();

                Console.Write("Enter Order ID: ");
                int orderID = int.Parse(Console.ReadLine());
                string sql = $"SELECT * FROM OrderDetails WHERE OrderID={orderID}";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) {
                    int orderDetailID = reader.GetInt32(0);
                    int productID = (int)reader.GetInt32(2);
                    int quantity = (int)reader.GetInt32(3);
                    Console.WriteLine($"Order Detail ID: {orderDetailID}, Order ID: {orderID},  Product ID: {productID}, Quantity: {quantity}");
                }
                else
                {
                    Console.WriteLine("No data available.");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void RemoveOrderDetail(OrderDetailsService orderDetailsService)
        {
            Console.Write("Enter Order ID: ");
            int orderDetailId = int.Parse(Console.ReadLine() ?? string.Empty);
            orderDetailsService.CancelOrder(orderDetailId);
            Console.WriteLine("Order detail removed successfully.");
        }
    }
}