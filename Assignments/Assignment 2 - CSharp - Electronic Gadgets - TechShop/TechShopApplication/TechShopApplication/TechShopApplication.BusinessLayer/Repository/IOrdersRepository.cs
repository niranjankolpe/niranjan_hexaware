using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal interface IOrdersRepository
    {
        void CalculateTotalAmount();

        void GetOrderDetails();

        void UpdateOrderStatus();

        void CancelOrder();
    }
}
