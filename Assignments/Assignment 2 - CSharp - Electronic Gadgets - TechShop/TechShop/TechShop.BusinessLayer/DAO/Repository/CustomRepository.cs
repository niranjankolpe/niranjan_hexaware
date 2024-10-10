using System;
using System.Collections.Generic;
using System.Linq;
using TechShop;


namespace TechShop
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers;

        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Address = customer.Address;
            }
        }

        public Customer GetCustomerById(int id)
        {
            return _customers.FirstOrDefault(c => c.CustomerID == id);
        }

        public decimal CalculateTotalOrders(int customerId)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customer != null)
            {
                return customer.Orders.Sum(order => order.TotalAmount);
            }
            return 0;
        }
    }
}