using System.Collections.Generic;
using TechShop;

namespace TechShop
{
    public interface IOrderRepository
    {
        void PlaceOrder(Order order);
        Order GetOrder(int orderId);
        void UpdateOrder(Order order);
        void CancelOrder(int orderId);
        List<Order> GetAllOrders();
    }
}