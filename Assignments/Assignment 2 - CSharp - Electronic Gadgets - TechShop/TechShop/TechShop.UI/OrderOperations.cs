using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop
{
    public static class OrderOperations
    {
        public static void SyncOrders(OrderService orderService, CustomerService customerService)
        {
            try
            {
                SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                connection.Open();
                string sql = $"SELECT * FROM Orders";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order();
                    order.OrderID = (int)reader["OrderID"];
                    order.CustomerID = (int)reader["CustomerID"];
                    order.OrderDate = (DateTime)reader["OrderDate"];
                    order.TotalAmount = (int)reader["TotalAmount"];
                    orderService.PlaceOrder(order);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void PlaceOrder(OrderService orderService, CustomerService customerService)
        {
            try
            {
                Console.Write("Enter Customer ID: ");
                int customerID = int.Parse(Console.ReadLine());

                DateTime orderDate = DateTime.Now;

                Console.Write("Enter Total Amount: ");
                int totalAmount = int.Parse(Console.ReadLine() ?? string.Empty);

                Order order = new Order();
                Customer customer = customerService.GetCustomerById(customerID);
                if (customer != null)
                {
                    order.CustomerID = customerID;
                    order.OrderDate = orderDate;
                    order.TotalAmount = totalAmount;
                }

                orderService.PlaceOrder(order);
                Console.WriteLine("Order placed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void GetOrderDetails(OrderService orderService, CustomerService customerService)
        {
            try
            {
                Console.Write("Enter Order ID: ");
                int orderId = int.Parse(Console.ReadLine() ?? string.Empty);
                Order order = orderService.GetOrder(orderId);
                if (order != null)
                {
                    Console.WriteLine($"Customer ID: {order.CustomerID}");
                    Console.WriteLine($"Order Date: {order.OrderDate}");
                    Console.WriteLine($"Total Amount: {order.TotalAmount}");
                }
                else
                {
                    Console.WriteLine("Order not found.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void UpdateOrder(OrderService orderService)
        {
            try
            {
                Console.Write("Enter Order ID: ");
                int orderId = int.Parse(Console.ReadLine() ?? string.Empty);
                Order order = orderService.GetOrder(orderId);
                if (order != null)
                {
                    Console.Write("Enter New Customer Name: ");
                    order.CustomerID = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Order Date (yyyy-mm-dd): ");
                    order.OrderDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);
                    Console.Write("Enter New Total Amount: ");
                    order.TotalAmount = int.Parse(Console.ReadLine() ?? string.Empty);

                    orderService.UpdateOrder(order);
                    Console.WriteLine("Order updated successfully.");
                }
                else
                {
                    Console.WriteLine("Order not found.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        public static void CancelOrder(OrderService orderService)
        {
            try
            {
                Console.Write("Enter Order ID: ");
                int orderId = int.Parse(Console.ReadLine() ?? string.Empty);
                orderService.CancelOrder(orderId);
                Console.WriteLine("Order canceled successfully.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString() );
            }
        }

        public static void ListAllOrders(OrderService orderService)
        {
            try
            {
                List<Order> orders = orderService.GetAllOrders();
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.OrderID}, Customer: {order.CustomerID}, Order Date: {order.OrderDate}, Total Amount: {order.TotalAmount}");
                }
            }
            catch (Exception ex) { Console.WriteLine( ex.ToString() ); }
        }
    }
}