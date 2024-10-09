using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class InventoryService : IInventoryService
    {
        InventoryRepository _inventoryRepository;
        public InventoryService(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public void GetProduct()
        {
            _inventoryRepository.GetProduct();
        }

        public void GetQuantityInStock()
        {
            _inventoryRepository.GetQuantityInStock();
        }

        public void AddToInventory()
        {
            _inventoryRepository.AddToInventory();
        }

        public void RemoveFromInventory()
        {
            _inventoryRepository.RemoveFromInventory();
        }

        public void UpdateStockQuantity()
        {
            _inventoryRepository.UpdateStockQuantity();
        }

        public void IsProductAvailable()
        {
            _inventoryRepository.IsProductAvailable();
        }

        public void GetInventoryValue()
        {
            _inventoryRepository.GetInventoryValue();
        }

        public void ListLowStockProducts()
        {
            _inventoryRepository.ListLowStockProducts();
        }

        public void ListOutOfStockProducts()
        {
            _inventoryRepository.ListOutOfStockProducts();
        }

        public void ListAllProducts()
        {
            _inventoryRepository.ListAllProducts();
        }
    }
}
