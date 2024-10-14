using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using AssetManagement.Util;
using AssetManagement.BusinessLayer;
using AssetManagement.Entity;
using AssetManagement.Exception;

namespace AssetManagement.UI
{
    public class AssetManagementApp
    {
        static void Main()
        {
            try
            {
                DBConnection conn = new DBConnection();
                Console.Write("Welcome to Digital Asset Management Application!\n");
                string availableOptionsString = "\nChoose an option:1. Add Asset, 2. Update Asset, 3. Delete Asset, 4. Allocate Asset, 5. DeallocateAsset, 6. Perform Maintenance, 7. Reserve Asset, 8. Withdraw Reservation, 9. Exit";
                
                // Initialize the Asset Management Repository and Service
                AssetManagementRepository repository = new AssetManagementRepository();
                AssetManagementService service =  new AssetManagementService(repository);
                
                // Download data from Database to local data structures
                repository.SyncAssets();
                repository.SyncEmployees();
                repository.SyncAssetAllocations();
                repository.SyncMaintenanceRecords();
                repository.SyncReservations();

                // Declaring required variables
                Assets asset;
                string option;
                bool exit = true;
                int assetID, employeeID, reservationID;
                string returnDate = string.Empty, maintenanceDate=string.Empty, description=string.Empty;
                string reservationDate = string.Empty, startDate = string.Empty, endDate = string.Empty;
                float cost;

                // Program Start
                while (exit)
                {
                    // Initialize pre-declared variables as per requirement
                    asset = new Assets();

                    // Input Case/Function Number
                    Console.WriteLine(availableOptionsString);
                    option = Console.ReadLine();

                    // Exception Handling
                    try
                    {
                        // Switch Cases for chosen case/function
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
                                service.AddAsset(asset);
                                Console.WriteLine($"Asset added successfully!");
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
                                service.UpdateAsset(asset);
                                Console.WriteLine($"Asset updated successfully with new Asset ID: {asset.AssetID}");
                                break;

                            // Delete Asset
                            case "3":
                                Console.Write("Enter Asset ID: ");
                                assetID = int.Parse(Console.ReadLine());
                                service.DeleteAsset(assetID);
                                Console.WriteLine($"Asset deleted successfully with Asset ID: {assetID}");
                                break;

                            // Allocate Asset
                            case "4":
                                Console.Write("Enter Asset ID: ");
                                assetID = int.Parse(Console.ReadLine());
                                Console.Write("Enter Employee ID: ");
                                employeeID = int.Parse(Console.ReadLine());
                                Console.Write("Enter Return Date (Optional): ");
                                returnDate = Console.ReadLine();
                                if (returnDate == "")
                                {
                                    returnDate = "12/31/2024";
                                }
                                if (service.AllocateAsset(assetID, employeeID, returnDate) == true)
                                    Console.WriteLine($"Asset ID: {assetID} has successfully been allocated to Employee ID: {employeeID}");
                                else
                                    Console.WriteLine("Asset is currently alloted to different employee");
                                break;

                            // Deallocate Asset
                            case "5":
                                Console.Write("Enter Asset ID: ");
                                assetID = int.Parse(Console.ReadLine());
                                Console.Write("Enter Employee ID: ");
                                employeeID = int.Parse(Console.ReadLine());
                                Console.Write("Enter Return Date (Optional): ");
                                returnDate = Console.ReadLine();
                                if (returnDate == "")
                                {
                                    returnDate = "12/31/2024";
                                }
                                service.DeallocateAsset(assetID, employeeID, returnDate);
                                Console.WriteLine($"Asset ID: {assetID} has successfully been Deallocated from Employee ID: {employeeID}");
                                break;

                            // Perform Maintenance
                            case "6":
                                Console.Write("Enter Asset ID: ");
                                assetID = int.Parse(Console.ReadLine());
                                Console.Write("Enter Maintenance Date (Press Enter for current date): ");
                                maintenanceDate = Console.ReadLine();
                                if (maintenanceDate == "")
                                {
                                    maintenanceDate = DateTime.Now.ToString();
                                }
                                Console.Write("Enter Description (In double quotes): ");
                                description = Console.ReadLine();
                                Console.Write("Enter Cost: ");
                                cost = float.Parse(Console.ReadLine());
                                service.PerformMaintenance(assetID, maintenanceDate, description, cost);
                                Console.WriteLine($"Maintenance data added successfully!");
                                break;

                            // Reserve Asset
                            case "7":
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
                                if (reservationDate == "" || startDate == "" || endDate == "")
                                {
                                    Console.WriteLine("The Reservation date, Start date or End date cannot be empty. Please try again!");
                                    break;
                                }
                                if(service.ReserveAsset(assetID, employeeID, reservationDate, startDate, endDate) == false)
                                    Console.WriteLine($"Reservation added successfully!");
                                else
                                    Console.WriteLine("Unavailable!");
                                break;

                            // Withdraw Reservation
                            case "8":
                                Console.Write("Enter Reseravation ID: ");
                                reservationID = int.Parse(Console.ReadLine());
                                service.WithdrawReservation(reservationID);
                                Console.WriteLine($"Reservation withdrawn successfully with Reservation ID: {reservationID}");
                                break;

                            // Exit
                            case "9":
                                exit = false;
                                break;

                            // Case for Invalid Input
                            default:
                                Console.WriteLine("Invalid Input! Try again.");
                                break;
                        }
                    }
                    catch(AssetNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        LogException.LogCurrentException(ex.Source, ex.Message, ex.ToString(), ex.StackTrace, DateTime.Now);
                    }
                    catch(EmployeeNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        LogException.LogCurrentException(ex.Source, ex.Message, ex.ToString(), ex.StackTrace, DateTime.Now);
                    }
                    catch(AssetNotMaintainException ex)
                    {
                        Console.WriteLine(ex.Message);
                        LogException.LogCurrentException(ex.Source, ex.Message, ex.ToString(), ex.StackTrace, DateTime.Now);
                    }
                    catch(AssetNotAllocatedException ex)
                    {
                        Console.WriteLine(ex.Message);
                        LogException.LogCurrentException(ex.Source, ex.Message, ex.ToString(), ex.StackTrace, DateTime.Now);
                    }
                    catch(ReservationNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        LogException.LogCurrentException(ex.Source, ex.Message, ex.ToString(), ex.StackTrace, DateTime.Now);
                    }
                }
                Console.WriteLine("\nThanks for using Digital Asset Management Application :)");
                // Program End

                // Footer
                Console.WriteLine("\n============================================");
                Console.WriteLine("Process Completed! Press any key to close...");
                Console.ReadKey();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                LogException.LogCurrentException(ex.Source, ex.Message, ex.ToString(), ex.StackTrace, DateTime.Now);
            }
        }
    }
}
