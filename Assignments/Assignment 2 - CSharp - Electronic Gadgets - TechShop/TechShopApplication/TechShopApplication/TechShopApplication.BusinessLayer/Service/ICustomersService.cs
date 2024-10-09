using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal interface ICustomersService
    {
        void AddCustomer();

        void CalculateTotalOrders();

        void GetCustomerDetails();

        void UpdateCustomerInfo();
    }
}
