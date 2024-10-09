using TechShop;
using System.Collections.Generic;

namespace TechShop
{
    public interface IOrderDetailsRepository
    {
        decimal CalculateTotalAmount(Order order);
        OrderDetail GetOrderDetails(int orderDetailID);
        void UpdateOrderStatus(int orderID);
        void CancelOrder(int orderID);
    }
}