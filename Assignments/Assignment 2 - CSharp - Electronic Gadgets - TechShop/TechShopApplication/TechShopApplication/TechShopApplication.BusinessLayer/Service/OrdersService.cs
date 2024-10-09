using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class OrdersService : IOrdersService
    {
        OrdersRepository _ordersRepository;

        public OrdersService(OrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public void CalculateTotalAmount()
        {
            _ordersRepository.CalculateTotalAmount();
        }

        public void GetOrderDetails()
        {
            _ordersRepository.GetOrderDetails();
        }

        public void UpdateOrderStatus()
        {
            _ordersRepository.UpdateOrderStatus();
        }

        public void CancelOrder()
        {
            _ordersRepository.CancelOrder();
        }
    }
}
