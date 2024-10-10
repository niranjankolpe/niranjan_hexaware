using System;
using System.Data.SqlClient;
using System.Net;
using System.Security.Policy;

namespace TechShop
{
    public static class CustomerOperations
    {
        public static void SyncCustomers(CustomerService customerService)
        {
            try
            {
                SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                connection.Open();
                string sql = $"SELECT * FROM Customers";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Customer customer = new Customer();
                    customer.CustomerID = (int) reader["CustomerID"]; ;
                    customer.FirstName = (string) reader["FirstName"];
                    customer.LastName = (string)reader["LastName"];
                    customer.Email = (string)reader["Email"];
                    customer.Phone = (decimal)reader["Phone"];
                    customer.Address = (string)reader["Address"];

                    customerService.AddCustomer(customer);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void AddCustomer(CustomerService customerService)
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Email: ");
            string email = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Phone Number: ");
            decimal phoneNumber = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Address: ");
            string address = Console.ReadLine() ?? string.Empty;

            if(firstName is null || lastName is null || email is null || address is null)
            {
                throw new ArgumentNullException("Input cannot be null!");
            }
            else if (phoneNumber == 0)
            {
                throw new ArgumentNullException("Input cannot be zero!");
            }

            try
            {
                SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                connection.Open();
                string sql = $"INSERT INTO Customers VALUES ('{firstName}', '{lastName}', '{email}', {phoneNumber}, '{address}'); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, connection);
                int customerID = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

                Customer customer = new Customer();
                customer.CustomerID = customerID;
                customer.FirstName = firstName;
                customer.LastName = lastName;
                customer.Email = email;
                customer.Phone = phoneNumber;
                customer.Address = address;

                customerService.AddCustomer(customer);
                Console.WriteLine($"Customer added successfully with Customer ID: {customerID}");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void GetCustomerDetails(CustomerService customerService)
        {
            try
            {
                Console.Write("Enter Customer ID: ");
                int customerID = int.Parse(Console.ReadLine());

                Customer customer = customerService.GetCustomerById(customerID);
                if (customer != null)
                {
                    Console.WriteLine($"Customer ID: {customer.CustomerID}, Name: {customer.FirstName} {customer.LastName}, Email: {customer.Email}, Phone: {customer.Phone}, Address: {customer.Address}");
                }
                else
                {
                    Console.WriteLine("Customer ID not found!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void UpdateCustomerInfo(CustomerService customerService)
        {
            try
            {
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                
                Customer customer = customerService.GetCustomerById(customerId);
                if (customer != null)
                {
                    Console.Write("Enter New First Name: ");
                    customer.FirstName = Console.ReadLine();
                    Console.Write("Enter New Last Name: ");
                    customer.LastName = Console.ReadLine();
                    Console.Write("Enter New Email: ");
                    customer.Email = Console.ReadLine();
                    Console.Write("Enter New Phone Number: ");
                    customer.Phone = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter New Address: ");
                    customer.Address = Console.ReadLine();

                    customerService.UpdateCustomer(customer);
                    Console.WriteLine("Customer updated successfully.");

                    SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                    connection.Open();
                    string sql = $"UPDATE Customers SET FirstName='{customer.FirstName}', LastName='{customer.LastName}', Email='{customer.Email}', Phone={customer.Phone}, Address='{customer.Address}' WHERE CustomerID={customerId}";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1) {
                        Console.WriteLine("Details updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong!");
                    }
                    connection.Close();
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
            }
        }
    }
}