using TechShop;

namespace TechShop
{
    public class ProductService : IProductRepository
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public Product GetProductDetails(int productID)
        {
            return _productRepository.GetProductDetails(productID);
        }

        public void UpdateProductInfo(Product product)
        {
            _productRepository.UpdateProductInfo(product);
        }

        public bool IsProductInStock(int productID)
        {
            return _productRepository.IsProductInStock(productID);
        }
    }
}