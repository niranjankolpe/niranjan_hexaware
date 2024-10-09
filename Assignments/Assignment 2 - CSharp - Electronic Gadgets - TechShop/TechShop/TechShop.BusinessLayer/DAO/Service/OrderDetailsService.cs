using TechShop;

namespace TechShop
{
    public class OrderDetailsService : IOrderDetailsRepository
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }
        public decimal CalculateTotalAmount(Order order)
        {
            return _orderDetailsRepository.CalculateTotalAmount(order);
        }

        public OrderDetail GetOrderDetails(int orderDetailID)
        {
            return _orderDetailsRepository.GetOrderDetails(orderDetailID);
        }

        public void UpdateOrderStatus(int orderID)
        {
            _orderDetailsRepository.UpdateOrderStatus(orderID);
        }

        public void CancelOrder(int orderID)
        {
            _orderDetailsRepository.CancelOrder(orderID);
        }
    }
}