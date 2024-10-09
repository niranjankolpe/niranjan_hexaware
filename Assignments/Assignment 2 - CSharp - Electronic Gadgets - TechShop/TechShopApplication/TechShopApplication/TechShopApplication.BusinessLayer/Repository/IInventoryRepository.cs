using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal interface IInventoryRepository
    {
        void GetProduct(); 

        void GetQuantityInStock();

        void AddToInventory();

        void RemoveFromInventory();

        void UpdateStockQuantity();

        void IsProductAvailable();

        void GetInventoryValue();

        void ListLowStockProducts();

        void ListOutOfStockProducts();

        void ListAllProducts();
    }
}
