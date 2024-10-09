using TechShop;
namespace TechShop
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer GetCustomerById(int id);
        decimal CalculateTotalOrders(int customerId);
    }
}