using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal interface IOrderDetailsService
    {
        void CalculateSubTotal();

        void GetOrderDetailInfo();

        void UpdateQuantity();

        void AddDiscount();
    }
}
