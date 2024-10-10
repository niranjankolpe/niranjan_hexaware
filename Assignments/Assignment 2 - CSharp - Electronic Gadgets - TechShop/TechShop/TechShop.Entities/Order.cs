using System;
using System.Collections.Generic;

namespace TechShop
{
    public class Order
    {
        private int _orderID;
        private int _customerID;
        private DateTime _orderDate;
        private int _totalAmount;

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();


        public int OrderID
        {
            get => _orderID;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("OrderID must be positive.");
                _orderID = value;
            }
        }

        public int CustomerID
        {
            get => _customerID;
            set => _customerID = value;
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            set => _orderDate = value;
        }

        public int TotalAmount
        {
            get => _totalAmount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("TotalAmount cannot be negative.");
                _totalAmount = value;
            }
        }

    }
}