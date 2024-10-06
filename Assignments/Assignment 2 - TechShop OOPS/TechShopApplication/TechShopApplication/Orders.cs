using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class Orders
    {
        private int OrderID;
        private Customers CustomerInfo;
        private DateTime OrderDate;
        private decimal TotalAmount;

        public Orders(int orderID, Customers customer, DateTime orderDate, decimal totalAmount)
        {
            this.OrderID = orderID;
            this.CustomerInfo = customer;
            this.OrderDate = orderDate;
            this.TotalAmount = totalAmount;
        }
        public void CalculateTotalAmount()
        {

        }

        public void GetOrderDetails()
        {

        }

        public void UpdateOrderStatus()
        {

        }

        public void CancelOrder()
        {

        }
    }
}
