using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal interface IProductsRepository
    {
        void GetProductDetails();

        void UpdateProductInfo();

        void IsProductInStock();
    }
}
