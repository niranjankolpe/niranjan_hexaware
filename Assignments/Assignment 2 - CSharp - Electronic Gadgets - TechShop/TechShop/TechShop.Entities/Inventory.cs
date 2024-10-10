using System;

namespace TechShop
{
    public class Inventory
    {
        private int _inventoryID;
        private int _productID;
        private int _quantityInStock;
        private DateTime _lastStockUpdate;

        public int InventoryID
        {
            get => _inventoryID;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("InventoryID must be positive.");
                _inventoryID = value;
            }
        }

        public int ProductID
        {
            get => _productID;
            set => _productID = value;
        }

        public int QuantityInStock
        {
            get => _quantityInStock;
            set
            {
                if (value < 0)
                    throw new ArgumentException("QuantityInStock cannot be negative.");
                _quantityInStock = value;
            }
        }

        public DateTime LastStockUpdate
        {
            get => _lastStockUpdate;
            set => _lastStockUpdate = value;
        }
    }
}