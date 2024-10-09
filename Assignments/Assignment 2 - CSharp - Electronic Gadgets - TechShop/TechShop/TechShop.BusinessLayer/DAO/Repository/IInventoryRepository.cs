using System.Collections.Generic;
using TechShop;
namespace TechShop
{
    public interface IInventoryRepository
    {
        void AddToInventory(Product product);
        void RemoveFromInventory(Product product);
        void UpdateStockQuantity(Product product, int newQuantity);
        bool IsProductAvailable(Product product, int quantityToCheck);
        double GetInventoryValue();
        List<Product> ListLowStockProducts(int threshold);
        List<Product> ListOutOfStockProducts();
        Product GetProduct(int productID);
        int GetQuantityInStock(int productID);
    }
}