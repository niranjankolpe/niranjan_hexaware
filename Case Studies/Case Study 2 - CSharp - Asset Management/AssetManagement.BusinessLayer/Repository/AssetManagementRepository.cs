using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.Remoting.Messaging;
using AssetManagement.Entity;
using AssetManagement.Util;
using AssetManagement.Exception;

namespace AssetManagement.BusinessLayer
{
    public class AssetManagementRepository : IAssetManagementRepository
    {
        // Declaring Static Class Variables
        static List<Assets> assetsList;
        static List<Employees> employeesList;
        static List<AssetAllocations> assetAllocationsList;
        static List<MaintenanceRecords> maintenanceRecordsList;
        static List<Reservations> reservationsList;
        static SqlConnection connection;
        static SqlCommand sqlCommand;
        static string sqlQuery;

        // Initializing Static Class Variables
        public AssetManagementRepository()
        {
            connection = DBConnection.GetConnection();
            sqlQuery = string.Empty;
            assetsList = new List<Assets>();
            employeesList = new List<Employees>();
            assetAllocationsList = new List<AssetAllocations>();
            maintenanceRecordsList = new List<MaintenanceRecords>();
            reservationsList = new List<Reservations>();
        }

        // Save Assets data to local data structure
        public void SyncAssets()
        {
            connection.Open();
            sqlQuery = $"SELECT * FROM assets";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Assets asset = new Assets
                {
                    AssetID = (int)sqlDataReader["asset_id"],
                    Name = (string)sqlDataReader["name"],
                    Type = (string)sqlDataReader["type"],
                    SerialNumber = (int)sqlDataReader["serial_number"],
                    PurchaseDate = (DateTime)sqlDataReader["purchase_date"],
                    Location = (string)sqlDataReader["location"],
                    Status = (string)sqlDataReader["status"],
                    OwnerID = (int)sqlDataReader["owner_id"]
                };
                assetsList.Add(asset);
            }
            sqlDataReader.Close();
            connection.Close();
        }

        // Save Employees data to local data structure
        public void SyncEmployees()
        {
            connection.Open();
            sqlQuery = $"SELECT * FROM employees";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Employees employee = new Employees
                {
                    EmployeeID = (int)sqlDataReader["employee_id"],
                    Name = (string)sqlDataReader["name"],
                    Department = (string)sqlDataReader["department"],
                    Email = (string)sqlDataReader["email"],
                    Password = (string)sqlDataReader["password"]
                };
                employeesList.Add(employee);
            }
            sqlDataReader.Close();
            connection.Close();
        }

        // Save Asset Allocations data to local data structure
        public void SyncAssetAllocations()
        {
            connection.Open();
            sqlQuery = $"SELECT * FROM asset_allocations";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                AssetAllocations assetAllocation = new AssetAllocations
                {
                    AllocationID = (int)sqlDataReader["allocation_id"],
                    AssetID = (int)sqlDataReader["asset_id"],
                    EmployeeID = (int)sqlDataReader["employee_id"],
                    AllocationDate = (DateTime)sqlDataReader["allocation_date"]
                };
                var returnDate = sqlDataReader["return_date"];
                if (returnDate is System.DBNull)
                {
                    assetAllocation.ReturnDate = DateTime.Parse("12/31/2024");
                }
                else
                {
                    string strReturnDate = returnDate.ToString();
                    assetAllocation.ReturnDate = DateTime.Parse(strReturnDate);
                }
                assetAllocationsList.Add(assetAllocation);
            }
            sqlDataReader.Close();
            connection.Close();
        }

        // Save Maintenance Records data to local data structure
        public void SyncMaintenanceRecords()
        {
            connection.Open();
            sqlQuery = $"SELECT * FROM maintenance_records";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                MaintenanceRecords maintenanceRecord = new MaintenanceRecords
                {
                    MaintenanceID = (int)sqlDataReader["maintenance_id"],
                    AssetID = (int)sqlDataReader["asset_id"],
                    MaintenanceDate = (DateTime)sqlDataReader["maintenance_date"],
                    Description = (string)sqlDataReader["description"]
                };
                double cost = (double)sqlDataReader["cost"];
                maintenanceRecord.Cost = (float)cost;
                maintenanceRecordsList.Add(maintenanceRecord);
            }
            sqlDataReader.Close();
            connection.Close();
        }

        // Save Reservations data to local data structure
        public void SyncReservations()
        {
            connection.Open();
            sqlQuery = $"SELECT * FROM reservations";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Reservations reservation = new Reservations
                {
                    ReservationID = (int)sqlDataReader["reservation_id"],
                    AssetID = (int)sqlDataReader["asset_id"],
                    EmployeeID = (int)sqlDataReader["employee_id"],
                    ReservationDate = (DateTime)sqlDataReader["reservation_date"],
                    StartDate = (DateTime)sqlDataReader["start_date"],
                    EndDate = (DateTime)sqlDataReader["end_date"],
                    Status = (string)sqlDataReader["status"]
                };
                reservationsList.Add(reservation);
            }
            sqlDataReader.Close();
            connection.Close();
        }

        // Add new asset
        public bool AddAsset(Assets asset)
        {
            connection.Open();
            sqlQuery = $"INSERT INTO assets VALUES ('{asset.Name}', '{asset.Type}', {asset.SerialNumber}, '{asset.PurchaseDate}', '{asset.Location}', '{asset.Status}', {asset.OwnerID});  SELECT SCOPE_IDENTITY();";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            int assetID = Convert.ToInt32(sqlCommand.ExecuteScalar());
            asset.AssetID = assetID;
            connection.Close();
            assetsList.Add(asset);
            return true;
        }

        // Update existing asset
        public bool UpdateAsset(Assets asset)
        {
            if (!assetsList.Exists(x => x.AssetID == asset.AssetID))
                throw new AssetNotFoundException();
            connection.Open();
            sqlQuery = $"UPDATE assets SET name='{asset.Name}', type='{asset.Type}', serial_number={asset.SerialNumber}, purchase_date='{asset.PurchaseDate}', location='{asset.Location}', status='{asset.Status}', owner_id={asset.OwnerID} WHERE asset_id={asset.AssetID}";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            sqlCommand.ExecuteScalar();
            connection.Close();
            int index = assetsList.FindIndex(x => x.AssetID == asset.AssetID);
            assetsList[index].AssetID = asset.AssetID;
            assetsList[index].Name = asset.Name;
            assetsList[index].Type = asset.Type;
            assetsList[index].SerialNumber = asset.SerialNumber;
            assetsList[index].PurchaseDate = asset.PurchaseDate;
            assetsList[index].Location = asset.Location;
            assetsList[index].Status = asset.Status;
            assetsList[index].OwnerID = asset.OwnerID;
            return true;
        }

        // Delete existing asset
        public bool DeleteAsset(int assetID)
        {
            if (!assetsList.Exists(x => x.AssetID == assetID))
                throw new AssetNotFoundException("Asset does not exist!");
            int index = assetsList.FindIndex(x => x.AssetID == assetID);
            connection.Open();
            sqlQuery = $"DELETE FROM maintenance_records WHERE asset_id={assetID};DELETE FROM reservations WHERE asset_id={assetID};DELETE FROM asset_allocations WHERE asset_id={assetID};DELETE FROM assets WHERE asset_id={assetID};";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            assetsList.RemoveAt(index);
            return true;
        }

        // Allocate asset to an employee
        public bool AllocateAsset(int assetID, int employeeID, string returnDate)
        {
            if (!assetsList.Exists(x => x.AssetID == assetID))
                throw new AssetNotFoundException("Asset does not exist!");
            if (!employeesList.Exists(x => x.EmployeeID == employeeID))
                throw new EmployeeNotFoundException();
            if (!maintenanceRecordsList.Exists(x => x.AssetID == assetID))
                throw new AssetNotMaintainException();
            if (!maintenanceRecordsList.Exists(x => x.AssetID == assetID && x.MaintenanceDate > DateTime.Today.AddYears(-2)))
                throw new AssetNotMaintainException();
            // If Asset is already alloted to the same employee
            if (assetAllocationsList.Exists(x => x.AssetID == assetID && x.EmployeeID == employeeID))
            {
                return true;
            }
            // If Asset is currently alloted to different employee
            else if (assetAllocationsList.Exists(x => x.AssetID == assetID && x.EmployeeID != employeeID))
            {
                return false;
            }
            // If asset is free to be alloted
            DateTime returnDateTime = (returnDate != null) ? DateTime.Parse(returnDate) : DateTime.Parse("12/31/2024");
            connection.Open();
            sqlQuery = $"INSERT INTO asset_allocations VALUES ({assetID}, {employeeID}, '{DateTime.Now}', '{returnDateTime}'); SELECT SCOPE_IDENTITY();";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            int assetAllocationID = Convert.ToInt32(sqlCommand.ExecuteScalar());
            connection.Close();
            AssetAllocations allocations = new AssetAllocations
            {
                AllocationID = assetAllocationID,
                AssetID = assetID,
                EmployeeID = employeeID,
                AllocationDate = DateTime.Now,
                ReturnDate = returnDateTime
            };
            assetAllocationsList.Add(allocations);
            return true;
        }

        // Deallocate asset from an employee
        public bool DeallocateAsset(int assetID, int employeeID, string returnDate)
        {
            if (!assetsList.Exists(x => x.AssetID == assetID))
                throw new AssetNotFoundException();
            if (!employeesList.Exists(x => x.EmployeeID == employeeID))
                throw new EmployeeNotFoundException();
            if (!assetAllocationsList.Exists(x => x.AssetID == assetID))
                throw new AssetNotAllocatedException();
            if (assetAllocationsList.Exists(x => x.AssetID == assetID && x.EmployeeID != employeeID))
                throw new AssetNotAllocatedException();
            int index = assetAllocationsList.FindIndex(x => x.AssetID == assetID && x.EmployeeID == employeeID);
            assetAllocationsList.RemoveAt(index);
            connection.Open();
            sqlQuery = $"DELETE FROM asset_allocations WHERE asset_id={assetID} AND employee_id={employeeID};";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        // Add new maintenance data
        public bool PerformMaintenance(int assetID, string maintenanceDate, string description, float cost)
        {
            if (!assetsList.Exists(x => x.AssetID == assetID))
                throw new AssetNotFoundException();
            connection.Open();
            DateTime maintenanceDateTime;
            if (maintenanceDate == "")
            {
                maintenanceDateTime = DateTime.Now;
            }
            else
            {
                maintenanceDateTime = DateTime.Parse(maintenanceDate);
            }
            sqlQuery = $"INSERT INTO maintenance_records VALUES ({assetID}, '{maintenanceDateTime}', '{description}', {cost});  SELECT SCOPE_IDENTITY();";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            int maintenanceID = Convert.ToInt32(sqlCommand.ExecuteScalar());
            connection.Close();
            MaintenanceRecords maintenance = new MaintenanceRecords
            {
                MaintenanceID = maintenanceID,
                AssetID = assetID,
                MaintenanceDate = maintenanceDateTime,
                Description = description,
                Cost = cost
            };
            maintenanceRecordsList.Add(maintenance);
            return true;
        }

        // Reserve an asset for an employee
        public bool ReserveAsset(int assetID, int employeeID, string reservationDate, string startDate, string endDate)
        {
            if (!assetsList.Exists(x => x.AssetID == assetID))
                throw new AssetNotFoundException();
            if (!employeesList.Exists(x => x.EmployeeID == employeeID))
                throw new EmployeeNotFoundException();
            DateTime reservationDateTime, startDateTime, endDateTime;
            reservationDateTime = DateTime.Parse(reservationDate);
            startDateTime = DateTime.Parse(startDate);
            endDateTime = DateTime.Parse(endDate);
            if (reservationsList.Exists(x => x.AssetID == assetID && x.EmployeeID == employeeID && x.ReservationDate == reservationDateTime && x.StartDate == startDateTime && x.EndDate == endDateTime))
            {
                return true;
            }
            else
            {
                if (reservationsList.Exists(x => x.AssetID == assetID && x.Status == "Approved" && x.StartDate <= startDateTime && startDateTime <= x.EndDate))
                {
                    return false;
                }
                if (reservationsList.Exists(x => x.AssetID == assetID && x.Status == "Approved" && x.StartDate <= endDateTime && endDateTime <= x.EndDate))
                {
                    return false;
                }
                if (reservationsList.Exists(x => x.AssetID == assetID && x.Status == "Approved" && startDateTime < x.StartDate && x.EndDate < endDateTime))
                {
                    return false;
                }
            }
            connection.Open();
            string status = "Approved";
            sqlQuery = $"INSERT INTO reservations VALUES ({assetID}, {employeeID}, '{reservationDateTime}', '{startDateTime}', '{endDateTime}', '{status}');  SELECT SCOPE_IDENTITY();";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            int reservationID = Convert.ToInt32(sqlCommand.ExecuteScalar());
            connection.Close();
            Reservations reservation = new Reservations
            {
                ReservationID = reservationID,
                AssetID = assetID,
                EmployeeID = employeeID,
                ReservationDate = reservationDateTime,
                StartDate = startDateTime,
                EndDate = endDateTime,
                Status = status
            };
            reservationsList.Add(reservation);
            return true;
        }

        // Withdraw existing asset reservation
        public bool WithdrawReservation(int reservationID)
        {
            if (!reservationsList.Exists(x => x.ReservationID == reservationID))
                throw new ReservationNotFoundException();
            connection.Open();
            sqlQuery = $"DELETE FROM reservations WHERE reservation_id={reservationID}";
            sqlCommand = new SqlCommand(sqlQuery, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            int index = reservationsList.FindIndex(x => x.ReservationID == reservationID);
            reservationsList.RemoveAt(index);
            return true;
        }
    }
}
