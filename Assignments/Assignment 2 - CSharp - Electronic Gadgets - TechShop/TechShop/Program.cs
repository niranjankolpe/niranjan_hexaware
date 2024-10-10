using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate repository classes
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IInventoryRepository inventoryRepository = new InventoryRepository();
            ICustomerRepository customerRepository = new CustomerRepository();
            IOrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository();

            // Passing Repository instances to Service class constructors
            ProductService productService = new ProductService (productRepository);
            OrderService orderService = new OrderService(orderRepository);
            InventoryService inventoryService = new InventoryService(inventoryRepository);
            CustomerService customerService = new CustomerService(customerRepository);
            OrderDetailsService orderDetailsService = new OrderDetailsService(orderDetailsRepository);

            try
            {
                Console.WriteLine("Welcome to TechShop!\n");
                bool exitToMain = true;
                string section;

                while (exitToMain)
                {
                    Console.WriteLine("\nEnter Section Number: 1. Customers, 2. Products, 3. Orders, 4. Order Details, 5. Inventory, 6. Exit");
                    section = Console.ReadLine();
                    switch (section)
                    {
                        // Customer Section
                        case "1":
                            bool exitCustomer = true;
                            string optionCustomer;
                            CustomerOperations.SyncCustomers(customerService);
                            while (exitCustomer)
                            {
                                Console.WriteLine("\nChoose: 1. Add Customer, 2. Get Customer Details, 3. Update Customer Info, 4. Exit");
                                optionCustomer = Console.ReadLine();          
                                switch (optionCustomer)
                                {
                                    case "1":
                                        CustomerOperations.AddCustomer(customerService);
                                        break;
                                    case "2":
                                        CustomerOperations.GetCustomerDetails(customerService);
                                        break;
                                    case "3":
                                        CustomerOperations.UpdateCustomerInfo(customerService);
                                        break;
                                    case "4":
                                        exitCustomer = false;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Input! Try again");
                                        break;
                                }
                            }
                            break;


                        // Product Section
                        case "2":
                            bool exitProduct = true;
                            string optionProduct;
                            ProductOperations.SyncProducts(productService);

                            while (exitProduct)
                            {
                                Console.WriteLine("\nChoose: 1. Add Product 2. Get Product Details, 3. Update Product Info, 4. Check Product Stock, 5. Exit");
                                optionProduct = Console.ReadLine();
                                switch (optionProduct)
                                {           
                                    case "1":
                                        ProductOperations.AddProduct(productService);
                                        break;
                                    case "2":
                                        ProductOperations.GetProductDetails(productService);
                                        break;
                                    case "3":
                                        ProductOperations.UpdateProductInfo(productService);
                                        break;
                                    case "4":
                                        ProductOperations.CheckProductStock(productService);
                                        break;
                                    case "5":
                                        exitProduct = false;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Input!");
                                        break;
                                }
                            }
                            break;

                        // Order Section
                        case "3":
                            bool exitOrder = true;
                            string optionOrder;
                            OrderOperations.SyncOrders(orderService, customerService);
                            while (exitOrder)
                            {
                                Console.WriteLine("\nChoose: 1. Place Order, 2. Get Order Details, 3. Update Order, 4. Cancel Order, 5. List All Orders, 6. Exit");
                                optionOrder = Console.ReadLine();
                                switch (optionOrder)
                                {
                                    case "1":
                                        OrderOperations.PlaceOrder(orderService, customerService);
                                        break;
                                    case "2":
                                        OrderOperations.GetOrderDetails(orderService, customerService);
                                        break;
                                    case "3":
                                        OrderOperations.UpdateOrder(orderService);
                                        break;
                                    case "4":
                                        OrderOperations.CancelOrder(orderService);
                                        break;
                                    case "5":
                                        OrderOperations.ListAllOrders(orderService);
                                        break;
                                    case "6":
                                        exitOrder = false;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Input!");
                                        break;
                                }
                            }
                            break;

                        // Order Details Section
                        case "4":
                            bool exitOrderDetails = true;
                            string optionOrderDetails;

                            while (exitOrderDetails)
                            {
                                Console.WriteLine("\nChoose: 1. Get Order Detail Info, 2. Remove Order Detail, 3. Exit");
                                optionOrderDetails = Console.ReadLine();
                                switch (optionOrderDetails)
                                {      
                                    case "1":
                                        OrderDetailOperations.GetOrderDetail(orderDetailsService);
                                        break;
                                    case "2":
                                        OrderDetailOperations.RemoveOrderDetail(orderDetailsService);
                                        break;
                                    case "3":
                                        exitOrderDetails = false;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Input!");
                                        break;
                                }
                            }
                            break;

                        // Inventory Section
                        case "5":
                            bool exitInventory = true;
                            string optionInventory;

                            while (exitInventory)
                            {
                                Console.WriteLine("\nChoose: 1. Add To Inventory, 2. Remove From Inventory, 3. Update Inventory Quantity, 4. Check Product Availability, 5. Exit");
                                optionInventory = Console.ReadLine();
                                switch (optionInventory)
                                {
                                    case "1":
                                        InventoryOperations.AddToInventory(inventoryService);
                                        break;
                                    case "2":
                                        InventoryOperations.RemoveFromInventory(inventoryService);
                                        break;
                                    case "3":
                                        InventoryOperations.UpdateInventoryQuantity(inventoryService);
                                        break;
                                    case "4":
                                        InventoryOperations.CheckProductAvailability(inventoryService);
                                        break;
                                    case "5":
                                        exitInventory = false;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Input! Try again.");
                                        break;
                                }
                            }
                            break;

                        // Exit to Main Program
                        case "6":
                            exitToMain = false;
                            break;

                        // Case to handle invalid input to Main program
                        default:
                            Console.WriteLine("Invalid Input! Try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("\nError Occured in Main program as follows:\n");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nThank you for using TechShopApplication :) ");

                Console.WriteLine("\n==========================================");
                Console.WriteLine("Process Completed. Press any key to close...");
                Console.ReadKey();
            }
        }
    }
}
