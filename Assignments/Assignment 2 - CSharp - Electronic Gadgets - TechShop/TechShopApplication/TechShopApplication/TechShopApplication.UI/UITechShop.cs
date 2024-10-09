using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class UITechShop
    {
        // Customers UI
        internal void OpenCustomersUI()
        {
            CustomersRepository c = new CustomersRepository();
            bool exit = true;
            string option = "0";

            while (exit)
            {
                Console.WriteLine("\nChoose: 1. Add Customer, 2. Calculate Total Orders, 3. Get Customer Details, 4. Update Customer Info, 5. Exit");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        c.AddCustomer();
                        break;
                    case "2":
                        c.CalculateTotalOrders();
                        break;
                    case "3":
                        c.GetCustomerDetails();
                        break;
                    case "4":
                        c.UpdateCustomerInfo();
                        break;
                    case "5":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input! Try again");
                        break;
                }
            }
        }

        // Products UI
        internal void OpenProductsUI()
        {
            ProductsRepository p = new ProductsRepository();
            bool exit = true;
            string option = "0";

            while (exit)
            {
                Console.WriteLine("\nChoose: 1. Get Product Details, 2. Update Product Info, 3. Is Product In Stock, 4. Exit");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        p.GetProductDetails();
                        break;
                    case "2":
                        p.UpdateProductInfo();
                        break;
                    case "3":
                        p.IsProductInStock();
                        break;
                    case "4":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }

        // Orders UI
        internal void OpenOrdersUI()
        {
            OrdersRepository o = new OrdersRepository();
            bool exit = true;
            string option = "0";

            while (exit)
            {
                Console.WriteLine("\nChoose: 1. Calculate Total Amount, 2. Get Order Details, 3. Update Order Status, 4. Cancel Order, 5. Exit");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        o.CalculateTotalAmount();
                        break;
                    case "2":
                        o.GetOrderDetails();
                        break;
                    case "3":
                        o.UpdateOrderStatus();
                        break;
                    case "4":
                        o.CancelOrder();
                        break;
                    case "5":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }

        // Order Details UI
        internal void OpenOrderDetailsUI()
        {
            OrderDetailsRepository od = new OrderDetailsRepository();
            bool exit = true;
            string option = "0";

            while (exit)
            {
                Console.WriteLine("\nChoose: 1. Calculate Sub Total, 2. Get Order Detail Info, 3. Update Quantity, 4. Add Discount, 5. Exit");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        od.CalculateSubTotal();
                        break;
                    case "2":
                        od.GetOrderDetailInfo();
                        break;
                    case "3":
                        od.UpdateQuantity();
                        break;
                    case "4":
                        od.AddDiscount();
                        break;
                    case "5":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }

        // Inventory UI
        internal void OpenInventoryUI()
        {
            InventoryRepository inv = new InventoryRepository();
            bool exit = true;
            string option = "0";

            while (exit)
            {
                Console.WriteLine("\nChoose: 1. Get Product Details, 2. Get Quantity In Stock, 3. Add To Inventory, 4. Remove From Inventory, 5. Update Stock Quantity\n6. Is Product Available, 7. Get Inventory Value, 8. List Low Stock Products, 9. List Out Of Stock Products, 10. List All Products\n11. Exit");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        inv.GetProduct();
                        break;
                    case "2":
                        inv.GetQuantityInStock();
                        break;
                    case "3":
                        inv.AddToInventory();
                        break;
                    case "4":
                        inv.RemoveFromInventory();
                        break;
                    case "5":
                        inv.UpdateStockQuantity();
                        break;
                    case "6":
                        inv.IsProductAvailable();
                        break;
                    case "7":
                        inv.GetInventoryValue();
                        break;
                    case "8":
                        inv.ListLowStockProducts();
                        break;
                    case "9":
                        inv.ListOutOfStockProducts();
                        break;
                    case "10":
                        inv.ListAllProducts();
                        break;
                    case "11":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input! Try again.");
                        break;
                }
            }
        }

        // RunTechShopApp
        internal void RunTechShopApp()
        {
            Console.WriteLine("Welcome to TechShop!\n");
            bool exit = true;
            string section = "0";

            while (exit)
            {
                Console.WriteLine("\nEnter Section Number: 1. Customers, 2. Products, 3. Orders, 4. Order Details, 5. Inventory, 6. Exit");
                section = Console.ReadLine();
                switch (section)
                {
                    case "1":
                        OpenCustomersUI();
                        break;
                    case "2":
                        OpenProductsUI();
                        break;
                    case "3":
                        OpenOrdersUI();
                        break;
                    case "4":
                        OpenOrderDetailsUI();
                        break;
                    case "5":
                        OpenInventoryUI();
                        break;
                    case "6":
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
