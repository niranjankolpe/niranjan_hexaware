using System;
using System.Data.SqlClient;
using System.Net;

namespace TechShop
{
    public static class ProductOperations
    {
        public static void SyncProducts(ProductService productService)
        {
            try
            {
                SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                connection.Open();
                string sql = $"SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                    Product product = new Product();
                    product.ProductID = (int)reader["ProductID"];
                    product.ProductName = (string)reader["ProductName"];
                    product.Description = (string)reader["Description"];
                    product.Price = (string)reader["Price"];
                    productService.AddProduct(product);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void AddProduct(ProductService productService)
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Price: ");
            string price = Console.ReadLine();

            if (name is null || description is null || price is null)
            {
                throw new ArgumentNullException("Input cannot be null!");
            }
            try
            {
                SqlConnection connection = DatabaseConnectivity.GetDBConnection();
                connection.Open();
                string sql = $"INSERT INTO Products VALUES ('{name}', '{description}', {int.Parse(price)}); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, connection);
                int productID = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

                Product product = new Product();
                product.ProductID = productID;
                product.ProductName = name;
                product.Description = description;
                product.Price = price;
                productService.AddProduct(product);

                Console.WriteLine($"Product added successfully with Product ID: {productID}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void GetProductDetails(ProductService productService)
        {
            try
            {
                Console.Write("Enter Product ID: ");
                int productID = int.Parse(Console.ReadLine());

                Product product = productService.GetProductDetails(productID);
                if (product != null)
                {
                    Console.WriteLine($"Product ID: {product.ProductID}, Name: {product.ProductName}, Description: {product.Description}, Price: {product.Price}");
                }
                else
                {
                    Console.WriteLine("Product ID not found!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void UpdateProductInfo(ProductService productService)
        {
            try
            {
                Console.Write("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());

                Product product = productService.GetProductDetails(productId);
                if (product != null)
                {
                    Console.Write("Enter New Product Name: ");
                    product.ProductName = Console.ReadLine();
                    Console.Write("Enter New Description: ");
                    product.Description = Console.ReadLine();
                    Console.Write("Enter New Price: ");
                    product.Price = Console.ReadLine();

                    productService.UpdateProductInfo(product);
                    Console.WriteLine("Product updated successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void CheckProductStock(ProductService productService)
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine() ?? string.Empty);
            bool inStock = productService.IsProductInStock(productId);
            Console.WriteLine(inStock ? "Product is in stock." : "Product is out of stock.");
        }
    }
}