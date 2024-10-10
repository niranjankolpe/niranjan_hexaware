using TechShop;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TechShop
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly List<OrderDetail> orderDetails;

        public OrderDetailsRepository()
        {
            orderDetails = new List<OrderDetail>();
        }

        public decimal CalculateTotalAmount(Order order)
        {
            return order.TotalAmount;
        }

        public OrderDetail GetOrderDetails(int orderDetailID)
        {
            return orderDetails.FirstOrDefault(od => od.OrderDetailID == orderDetailID) ?? new OrderDetail();
        }

        public void UpdateOrderStatus(int orderID)
        {
            // Implementation for updating order status
            Console.WriteLine("Order status updated.");
        }

        public void CancelOrder(int orderID)
        {
            // Implementation for canceling order
            Console.WriteLine("Order canceled.");
        }
    }
}