using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class UITechShop
    {
        // Customers Class Service
        internal void OpenCustomerService()
        {
            Customers c = new Customers();
            bool exit = true;
            int option = 0;
            
            while (exit)
            {
                Console.WriteLine("\nChoose: 1. Add Customer, 2. Calculate Total Orders, 3. Get Customer Details, 4. Update Customer Info, 5. Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        c.AddCustomer();
                        break;
                    case 2:
                        c.CalculateTotalOrders();
                        break;
                    case 3:
                        c.GetCustomerDetails();
                        break;
                    case 4:
                        c.UpdateCustomerInfo();
                        break;
                    case 5:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }

        // Products Class Service
        internal void OpenProductsService()
        {
            Products p = new Products();
            bool exit = true;
            int option = 0;

            while (exit)
            {
                Console.WriteLine("\nChoose: 1. Get Product Details, 2. Update Product Info, 3. Is Product In Stock, 4. Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        p.GetProductDetails();
                        break;
                    case 2:
                        p.UpdateProductInfo();
                        break;
                    case 3:
                        p.IsProductInStock();
                        break;
                    case 4:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }  
        }

        // Orders Class Service
        internal void OpenOrdersService()
        {
            Orders o = new Orders();
            bool exit = true;
            int option = 0;

            while (exit)
            {
                Console.WriteLine("\nChoose: 1. Calculate Total Amount, 2. Get Order Details, 3. Update Order Status, 4. Cancel Order, 5. Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        o.CalculateTotalAmount();
                        break;
                    case 2:
                        o.GetOrderDetails();
                        break;
                    case 3:
                        o.UpdateOrderStatus();
                        break;
                    case 4:
                        o.CancelOrder();
                        break;
                    case 5:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }

        // Order Details Class Service
        internal void OpenOrderDetailsService()
        {
            OrderDetails od = new OrderDetails();
            bool exit = true;
            int option = 0;

            while (exit)
            {
                Console.WriteLine("\nChoose: 1. Calculate Sub Total, 2. Get Order Detail Info, 3. Update Quantity, 4. Add Discount, 5. Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        od.CalculateSubTotal();
                        break;
                    case 2:
                        od.GetOrderDetailInfo();
                        break;
                    case 3:
                        od.UpdateQuantity();
                        break;
                    case 4:
                        od.AddDiscount();
                        break;
                    case 5:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }

        // Inventory Class Service
        internal void OpenInventoryService()
        {
            Inventory inv = new Inventory();
            bool exit = true;
            int option = 0;

            while (exit)
            {
                Console.WriteLine("\nChoose: 1. Get Product Details, 2. Get Quantity In Stock, 3. Add To Inventory, 4. Remove From Inventory, 5. Update Stock Quantity\n6. Is Product Available, 7. Get Inventory Value, 8. List Low Stock Products, 9. List Out Of Stock Products, 10. List All Products\n11. Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        inv.GetProduct();
                        break;
                    case 2:
                        inv.GetQuantityInStock();
                        break;
                    case 3:
                        inv.AddToInventory();
                        break;
                    case 4:
                        inv.RemoveFromInventory();
                        break;
                    case 5:
                        inv.UpdateStockQuantity();
                        break;
                    case 6:
                        inv.IsProductAvailable();
                        break;
                    case 7:
                        inv.GetInventoryValue();
                        break;
                    case 8:
                        inv.ListLowStockProducts();
                        break;
                    case 9:
                        inv.ListOutOfStockProducts();
                        break;
                    case 10:
                        inv.ListAllProducts();
                        break;
                    case 11:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }

        // RunTechShopApp
        internal void RunTechShopApp()
        {
            Console.WriteLine("Welcome to TechShop!\n");
            bool exit = true;
            int section = 0;

            while (exit)
            {
                Console.WriteLine("\nEnter Section Number: 1. Customers, 2. Products, 3. Orders, 4. Order Details, 5. Inventory, 6. Exit");
                section = int.Parse(Console.ReadLine());
                switch (section)
                {
                    case 1:
                        OpenCustomerService();
                        break;
                    case 2:
                        OpenProductsService();
                        break;
                    case 3:
                        OpenOrdersService();
                        break;
                    case 4:
                        OpenOrderDetailsService();
                        break;
                    case 5:
                        OpenInventoryService();
                        break;
                    case 6:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input! Try again.");
                        break;
                }
            }
        }
    }
}
