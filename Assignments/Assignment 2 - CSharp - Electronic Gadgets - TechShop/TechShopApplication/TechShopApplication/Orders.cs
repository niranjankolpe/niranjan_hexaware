using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class Orders
    {
        private int OrderID;
        private int CustomerID;
        private DateTime OrderDate;
        private int TotalAmount;

        internal int _OrderID {  get; set; }

        internal int _CustomerID {  get; set; }

        internal DateTime _OrderDate { get; set; }

        internal int _TotalAmount { get; set; }

        public Orders()
        {
            this.OrderID = 0;
            this.CustomerID = 0;
            this.OrderDate = DateTime.Now;
            this.TotalAmount = 0;
        }
        public Orders(int orderID, int customerID, DateTime orderDate, int totalAmount)
        {
            this.OrderID = orderID;
            this.CustomerID = customerID;
            this.OrderDate = orderDate;
            this.TotalAmount = totalAmount;
        }
        public void CalculateTotalAmount()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter OrderID: ");
            int orderID = int.Parse(Console.ReadLine());
            string sql = $"SELECT TotalAmount FROM Orders WHERE OrderID={orderID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Console.WriteLine($"Order ID: {orderID}, Total Amount: {reader.GetInt32(0)}");
            reader.Close();
            connection.Close();
        }

        public void GetOrderDetails()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Order ID: ");
            int orderID = int.Parse(Console.ReadLine());
            string sql = $"SELECT * FROM Orders WHERE OrderID={orderID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Console.WriteLine($"Order ID: {reader.GetInt32(0)}, Customer ID: {reader.GetInt32(1)}, Order Date: {reader.GetDateTime(2)}, Total Amount: {reader.GetInt32(3)}, Order Status: {reader.GetString(4)}");
            
            reader.Close();
            connection.Close();
        }

        public void UpdateOrderStatus()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Order ID: ");
            int orderID = int.Parse(Console.ReadLine());

            Console.Write("Enter new Order Status: ");
            string orderStatus = Console.ReadLine();

            string sql = $"UPDATE Orders SET OrderStatus='{orderStatus}' WHERE OrderID={orderID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            int result = cmd.ExecuteNonQuery();

            Console.WriteLine($"Rows affected: {result}");

            connection.Close();
        }

        public void CancelOrder()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Order ID: ");
            int orderID = int.Parse(Console.ReadLine());

            string sql = $"UPDATE Orders SET OrderStatus='Cancelled' WHERE OrderID={orderID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            int result = cmd.ExecuteNonQuery();

            Console.WriteLine($"Rows affected: {result}");

            connection.Close();
        }
    }
}
