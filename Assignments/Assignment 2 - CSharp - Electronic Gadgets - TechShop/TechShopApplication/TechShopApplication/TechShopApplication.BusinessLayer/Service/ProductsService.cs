using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class ProductsService : IProductsService
    {
        ProductsRepository _productsRepository;

        public ProductsService(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public void GetProductDetails()
        {
            _productsRepository.GetProductDetails();
        }

        public void UpdateProductInfo()
        {
            _productsRepository.UpdateProductInfo();
        }

        public void IsProductInStock()
        {
            _productsRepository.IsProductInStock();
        }
    }
}
