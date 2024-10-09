using System.Collections.Generic;
using TechShop;

namespace TechShop
{
    public class InventoryService : IInventoryRepository
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public void AddToInventory(Product product)
        {
            _inventoryRepository.AddToInventory(product);
        }

        public void RemoveFromInventory(Product product)
        {
            _inventoryRepository.RemoveFromInventory(product);
        }

        public void UpdateStockQuantity(Product product, int newQuantity)
        {
            _inventoryRepository.UpdateStockQuantity(product, newQuantity);
        }

        public bool IsProductAvailable(Product product, int quantityToCheck)
        {
            return _inventoryRepository.IsProductAvailable(product, quantityToCheck);
        }

        public double GetInventoryValue()
        {
            return _inventoryRepository.GetInventoryValue();
        }

        public List<Product> ListLowStockProducts(int threshold)
        {
            return _inventoryRepository.ListLowStockProducts(threshold);
        }

        public List<Product> ListOutOfStockProducts()
        {
            return _inventoryRepository.ListOutOfStockProducts();
        }

        public Product GetProduct(int productID)
        {
            return _inventoryRepository.GetProduct(productID);
        }

        public int GetQuantityInStock(int productID)
        {
            return _inventoryRepository.GetQuantityInStock(productID);
        }
    }
}