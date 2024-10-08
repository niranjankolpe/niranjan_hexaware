using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class OrderDetails
    {
        private int OrderDetailID;
        private int OrderID;
        private int ProductID;
        private int Quantity;

        internal int _OrderDetailID {  get; set; }

        internal int _OrderID { get; set; }

        internal int _ProductID { get; set; }

        internal int _Quantity { get; set; }

        public OrderDetails()
        {
            this.OrderDetailID = 0;
            this.OrderID = 0;
            this.ProductID = 0;
            this.Quantity = 0;
        }

        public OrderDetails(int orderDetailID, int orderID, int productID, int quantity)
        {
            this.OrderDetailID = orderDetailID;
            this.OrderID = orderID;
            this.ProductID = productID;
            this.Quantity = quantity;
        }
        public void CalculateSubTotal()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Order ID: ");
            int orderID = int.Parse(Console.ReadLine());
            string sql = $"SELECT TotalAmount FROM Orders WHERE OrderID={orderID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Console.WriteLine($"Order ID: {orderID}, Total Amount: {reader.GetInt32(0)}");
            reader.Close();
            connection.Close();
        }

        public void GetOrderDetailInfo()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Order ID: ");
            int orderID = int.Parse(Console.ReadLine());
            string sql = $"SELECT * FROM OrderDetails WHERE OrderID={orderID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Console.WriteLine($"Order Details ID: {reader.GetInt32(0)}, Order ID: {reader.GetInt32(1)}, Product ID: {reader.GetInt32(2)}, Quantity: {reader.GetInt32(3)}");

            reader.Close();
            connection.Close();
        }

        public void UpdateQuantity()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Order ID: ");
            int orderID = int.Parse(Console.ReadLine());

            Console.Write("Enter new Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            string sql = $"UPDATE OrderDetails SET Quantity={quantity} WHERE OrderID={orderID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            int result = cmd.ExecuteNonQuery();

            Console.WriteLine($"Rows affected: {result}");

            connection.Close();
        }

        public void AddDiscount()
        {
            SqlConnection connection = DatabaseConnectivity.GetDBConnection();
            connection.Open();

            Console.Write("Enter Order ID: ");
            int orderID = int.Parse(Console.ReadLine());

            Console.Write("Enter discount: ");
            int discount = int.Parse(Console.ReadLine());

            string sql = $"UPDATE Orders SET TotalAmount=TotalAmount - (TotalAmount/{discount}) WHERE OrderID={orderID}";

            SqlCommand cmd = new SqlCommand(sql, connection);
            int result = cmd.ExecuteNonQuery();

            Console.WriteLine($"Rows affected: {result}");

            connection.Close();
        }
    }
}
