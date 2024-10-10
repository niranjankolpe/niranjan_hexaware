using System;

namespace TechShop
{
    public class OrderDetail
    {
        private int _orderDetailID;
        private int _orderID;
        private int _productID;
        private int _quantity;

        public int OrderDetailID
        {
            get => _orderDetailID;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("OrderDetailID must be positive.");
                _orderDetailID = value;
            }
        }

        public int OrderID
        {
            get => _orderID;
            set => _orderID = value;
        }

        public int ProductID
        {
            get => _productID;
            set => _productID = value;
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Quantity must be positive.");
                _quantity = value;
            }
        }
    }
}