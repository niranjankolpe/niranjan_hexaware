using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class OrderDetailsService : IOrderDetailsService
    {
        OrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService(OrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }
        public void CalculateSubTotal()
        {
            _orderDetailsRepository.CalculateSubTotal();
        }

        public void GetOrderDetailInfo()
        {
            _orderDetailsRepository.GetOrderDetailInfo();
        }

        public void UpdateQuantity()
        {
            _orderDetailsRepository.UpdateQuantity();
        }

        public void AddDiscount()
        {
            _orderDetailsRepository.AddDiscount();
        }
    }
}
