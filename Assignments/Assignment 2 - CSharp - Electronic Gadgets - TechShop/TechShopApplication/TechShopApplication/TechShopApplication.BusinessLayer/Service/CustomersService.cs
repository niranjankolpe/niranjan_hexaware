using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class CustomersService : ICustomersService
    {
        CustomersRepository _customersRepository;
        public CustomersService(CustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public void AddCustomer()
        {
            _customersRepository.AddCustomer();
        }

        public void CalculateTotalOrders()
        {
            _customersRepository.CalculateTotalOrders();
        }

        public void GetCustomerDetails()
        {
            _customersRepository.GetCustomerDetails();
        }

        public void UpdateCustomerInfo()
        {
            _customersRepository.UpdateCustomerInfo();
        }
    }
}
