using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class OrderDetails
    {
        private int OrderDetailID;
        private Orders Order;
        private Products Product;
        private int Quantity;

        public OrderDetails(int orderDetailID, Orders order, Products product, int quantity)
        {
            this.OrderDetailID = orderDetailID;
            this.Order = order;
            this.Product = product;
            this.Quantity = quantity;
        }
        public void CalculateSubTotal()
        {

        }

        public void GetOrderDetailInfo()
        {

        }

        public void UpdateQuantity()
        {

        }

        public void AddDiscount()
        {

        }
    }
}
