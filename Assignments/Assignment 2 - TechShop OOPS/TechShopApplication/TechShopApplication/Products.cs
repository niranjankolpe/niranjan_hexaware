using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class Products
    {
        private int ProductID;
        private string ProductName;
        private string Description;
        private decimal Price;

        public Products(int productID, string productName, string description, decimal price)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Description = description;
            this.Price = price;
        }
        public void GetProductDetails()
        {
            Console.WriteLine($"Product ID: {this.ProductID}, Name: {this.ProductName}, Description: {this.Description}, Price: {this.Price}\n");
        }

        public void UpdateProductInfo()
        {
            Console.WriteLine("Enter the number of the field you wish to update:\n1. Product ID, 2. Name, 3. Description " +
                "4. Price");
            int field_number = int.Parse(Console.ReadLine());
            Console.Write("Enter new value: ");
            string new_field_value = Console.ReadLine();
            switch (field_number)
            {
                case 1:
                    try
                    {
                        this.ProductID = int.Parse(new_field_value);
                    }
                    catch
                    {
                        Console.WriteLine("Only numeric input allowed!");
                    }
                    break;
                case 2:
                    this.ProductName = new_field_value;
                    break;
                case 3:
                    this.Description = new_field_value;
                    break;
                case 4:
                    try
                    {
                        this.Price = int.Parse(new_field_value);
                    }
                    catch
                    {
                        Console.WriteLine("Only numeric input allowed!");
                    }
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
            Console.WriteLine("Data Updated Successfully!");
        }

        public void IsProductInStock()
        {

        }
    }
}
