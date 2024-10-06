using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class Program
    {
        static private void OpenCustomerService()
        {
            Customers customer = new Customers();
            while (true)
            {
                Console.WriteLine("Choose:\n 1. Calculate Total Customer Orders, 2. Get Customer Details, 3. Update Customer Info, 4. Exit.");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        customer.CalculateTotalOrders();
                        break;
                    case "2":
                        customer.GetCustomerDetails();
                        break;
                    case "3":
                        customer.UpdateCustomerInfo();
                        break;
                    case "4":
                        Console.WriteLine("Exiting Customer Section...");
                        return;
                    default:
                        Console.WriteLine("Invalid input, try again!");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TechShop!\n"
            + "Choose an option:\n" + "1. Customers, 2. Products, 3. Orders, 4. Inventory 5. Exit");

            string serviceFlag;
            bool exitContinueFlag = true;
            while (exitContinueFlag)
            {
                serviceFlag = Console.ReadLine();
                switch (serviceFlag)
                {
                    case "1":
                        OpenCustomerService();
                        break;
                    case "2":
                        Console.WriteLine("Products Management Service Currently Unavailable :( ");
                        break;
                    case "3":
                        Console.WriteLine("Orders Management Service Currently Unavailable :( ");
                        break;
                    case "4":
                        Console.WriteLine("Inventory Management Service Currently Unavailable :( ");
                        break;
                    case "5":
                        exitContinueFlag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
            Console.WriteLine("\nThank you, visit again!");

            Console.WriteLine("\n==========================================");
            Console.WriteLine("Process Completed. Press any key to close...");
            Console.ReadKey();
        }
    }
}
