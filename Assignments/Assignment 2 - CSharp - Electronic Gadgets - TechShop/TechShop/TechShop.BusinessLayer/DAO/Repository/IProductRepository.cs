using TechShop;
using System.Collections.Generic;

namespace TechShop
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProductDetails(int productID);
        void UpdateProductInfo(Product product);
        bool IsProductInStock(int productID);
    }
}