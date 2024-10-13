using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    internal class AssetManagementApp
    {
        static void Main()
        {
            try
            {
                Console.Write("Welcome to Digital Asset Management Application!\n");

                string availableOptionsString = "\nChoose an option:1. Add Asset, 2. Update Asset, 3. Delete Asset, 4. Allocate Asset, 5. DeallocateAsset, 6. Perform Maintenance, 7. Reserve Asset, 8. Withdraw Reservation, 9. Exit";
                AssetManagementServiceImpl service =  new AssetManagementServiceImpl();
                service.SyncAssets();
                service.SyncEmployees();
                service.SyncAssetAllocations();
                service.SyncMaintenanceRecords();
                service.SyncReservations();
                string option;
                bool exit = true;
                Assets asset;
                int assetID, employeeID, reservationID;
                string returnDate = string.Empty, maintenanceDate=string.Empty, description=string.Empty;
                string reservationDate = string.Empty, startDate = string.Empty, endDate = string.Empty;
                float cost;
                while (exit)
                {
                    asset = new Assets();
                    Console.WriteLine(availableOptionsString);
                    option = Console.ReadLine();

                    switch (option)
                    {
                        // Add Asset
                        case "1":
                            Console.Write("Enter Asset Name: ");
                            asset.Name = Console.ReadLine();
                            Console.Write("Enter Type: ");
                            asset.Type = Console.ReadLine();
                            Console.Write("Enter Serial Number: ");
                            asset.SerialNumber = int.Parse(Console.ReadLine());
                            Console.Write("Enter Purchase Date: ");
                            asset.PurchaseDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter Current Location: ");
                            asset.Location = Console.ReadLine();
                            Console.Write("Enter Current Status: ");
                            asset.Status = Console.ReadLine();
                            Console.Write("Enter Owner ID: ");
                            asset.OwnerID = int.Parse(Console.ReadLine());
                            service.addAsset(asset);
                            break;

                        // Update Asset
                        case "2":
                            Console.Write("Enter Asset ID: ");
                            asset.AssetID = int.Parse(Console.ReadLine());
                            Console.Write("Enter Asset Name: ");
                            asset.Name = Console.ReadLine();
                            Console.Write("Enter Type: ");
                            asset.Type = Console.ReadLine();
                            Console.Write("Enter Serial Number: ");
                            asset.SerialNumber = int.Parse(Console.ReadLine());
                            Console.Write("Enter Purchase Date: ");
                            asset.PurchaseDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter Current Location: ");
                            asset.Location = Console.ReadLine();
                            Console.Write("Enter Current Status: ");
                            asset.Status = Console.ReadLine();
                            Console.Write("Enter Owner ID: ");
                            asset.OwnerID = int.Parse(Console.ReadLine());
                            service.updateAsset(asset);
                            break;

                        // Delete Asset
                        case "3":
                            Console.Write("Enter Asset ID: ");
                            assetID = int.Parse(Console.ReadLine());
                            service.deleteAsset(assetID);
                            break;

                        // Allocate Asset
                        case "4":
                            Console.Write("Enter Asset ID: ");
                            assetID = int.Parse(Console.ReadLine());
                            Console.Write("Enter Employee ID: ");
                            employeeID = int.Parse(Console.ReadLine());
                            Console.Write("Enter Return Date (Optional): ");
                            returnDate = Console.ReadLine();
                            if (returnDate == null)
                            {
                                returnDate = "12/31/2024";
                            }
                            try
                            {
                                service.allocateAsset(assetID, employeeID, returnDate);
                            }
                            catch (AssetNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch(EmployeeNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        // Deallocate Asset
                        case "5":
                            Console.Write("Enter Asset ID: ");
                            assetID = int.Parse(Console.ReadLine());
                            Console.Write("Enter Employee ID: ");
                            employeeID = int.Parse(Console.ReadLine());
                            Console.Write("Enter Return Date (Optional): ");
                            returnDate = Console.ReadLine();
                            if (returnDate == null)
                            {
                                returnDate = "12/31/2024";
                            }
                            service.deallocateAsset(assetID, employeeID, returnDate);
                            break;

                        // Perform Maintenance
                        case "6":
                            Console.Write("Enter Asset ID: ");
                            assetID = int.Parse(Console.ReadLine());
                            Console.Write("Enter Maintenance Date (Optional): ");
                            maintenanceDate = Console.ReadLine();
                            if (maintenanceDate is null)
                            {
                                maintenanceDate = DateTime.Now.ToString();
                            }
                            Console.Write("Enter Description (In double quotes): ");
                            description = Console.ReadLine();
                            Console.Write("Enter Cost: ");
                            cost = float.Parse(Console.ReadLine());
                            service.performMaintenance(assetID, maintenanceDate, description, cost);
                            break;

                        // Reserve Asset
                        case "7":
                            try
                            {
                                Console.Write("Enter Asset ID: ");
                                assetID = int.Parse(Console.ReadLine());
                                Console.Write("Enter Employee ID: ");
                                employeeID = int.Parse(Console.ReadLine());
                                Console.Write("Enter Reservation Date: ");
                                reservationDate = Console.ReadLine();
                                Console.Write("Enter Start Date: ");
                                startDate = Console.ReadLine();
                                Console.Write("Enter End Date: ");
                                endDate = Console.ReadLine();
                                service.reserveAsset(assetID, employeeID, reservationDate, startDate, endDate);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.ToString());
                            }
                            break;

                        // Withdraw Reservation
                        case "8":
                            Console.Write("Enter Reseravation ID: ");
                            reservationID = int.Parse(Console.ReadLine());
                            service.withdrawReservation(reservationID);
                            break;
                        case "9":
                            exit = false;
                            break;
                        default:
                            Console.WriteLine("Invalid Input! Try again.");
                            break;
                    }
                }
                Console.WriteLine("\nThanks for using Digital Asset Management Application :)");

                Console.WriteLine("\n============================================");
                Console.WriteLine("Process Completed! Press any key to close...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
