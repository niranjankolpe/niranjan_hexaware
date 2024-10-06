using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class Inventory
    {
        private int InventoryID;
        private Products Product;
        private int QuantityInStock;
        private DateTime LastStockUpdate;

        public Inventory(int inventoryID, Products product, int quantityInStock, DateTime lastStockUpdate)
        {
            this.InventoryID = inventoryID;
            this.Product = product;
            this.QuantityInStock = quantityInStock;
            this.LastStockUpdate = lastStockUpdate;
        }
        public void GetProduct()
        {

        }

        public void GetQuantityInStock()
        {

        }

        public void AddToInventory(int quantity)
        {

        }

        public void RemoveFromInventory(int quantity)
        {

        }


        public void UpdateStockQuantity(int newQuantity)
        {

        }


        public void IsProductAvailable(int quantityToCheck)
        {

        }


        public void GetInventoryValue()
        {

        }

        public void ListLowStockProducts(int threshold)
        {

        }


        public void ListOutOfStockProducts()
        {

        }


        public void ListAllProducts()
        {

        }
}
}
