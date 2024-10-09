using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TechShopApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UITechShop uITechShop = new UITechShop();
                uITechShop.RunTechShopApp();
            }
            catch (Exception ex)
            {
                Console.Write("\nError Occured as follows: ");
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
