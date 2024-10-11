using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssetManagement
{
    public class AssetManagementServiceImpl : AssetManagementService
    {
        static List<Assets> assetsList;
        static List<Employees> employeesList;
        static List<AssetAllocations> assetAllocationsList;
        static List<MaintenanceRecords> maintenanceRecordsList;
        static List<Reservations> reservationsList;
        static SqlConnection connection;

        public AssetManagementServiceImpl()
        {
            connection = DBConnection.getConnection();
        }

        public void syncAssets()
        {
            try
            {
                //SqlConnection conn = DBConnection.getConnection();
                connection.Open();
                string sql = $"SELECT * FROM assets";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                assetsList = new List<Assets> ();
                while (reader.Read())
                {
                    Assets asset = new Assets();
                    asset.AssetID = (int)reader["asset_id"];
                    asset.Name = (string)reader["name"];
                    asset.Type = (string)reader["type"];
                    asset.SerialNumber = (int)reader["serial_number"];
                    asset.PurchaseDate = (DateTime)reader["purchase_date"];
                    asset.Location = (string)reader["location"];
                    asset.Status = (string)reader["status"];
                    asset.OwnerID = (int)reader["owner_id"];

                    assetsList.Add(asset);
                    //Console.WriteLine($"Asset ID: {asset.AssetID}, Owner ID: {asset.OwnerID}");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void syncEmployees()
        {
            try
            {
                connection.Open();
                string sql = $"SELECT * FROM employees";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                employeesList = new List<Employees>();
                while (reader.Read())
                {
                    Employees employee = new Employees();
                    employee.EmployeeID = (int)reader["employee_id"];
                    employee.Name = (string)reader["name"];
                    employee.Department = (string)reader["department"];
                    employee.Email = (string)reader["email"];
                    employee.Password = (string)reader["password"];

                    employeesList.Add(employee);
                    //Console.WriteLine($"Employee ID: {employee.EmployeeID}, Email: {employee.Name}");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void syncAssetAllocations()
        {
            try
            {
                connection.Open();
                string sql = $"SELECT * FROM asset_allocations";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                assetAllocationsList = new List<AssetAllocations>();
                while (reader.Read())
                {
                    AssetAllocations assetAllocation = new AssetAllocations();
                    assetAllocation.AllocationID = (int)reader["allocation_id"];
                    assetAllocation.AssetID = (int)reader["asset_id"];
                    assetAllocation.EmployeeID = (int)reader["employee_id"];
                    assetAllocation.AllocationDate = (DateTime)reader["allocation_date"];
                    var returnDate = reader["return_date"];
                    if (returnDate is System.DBNull)
                    {
                        assetAllocation.ReturnDate = DateTime.Parse("12/31/2024");
                    }
                    else
                    {
                        string strReturnDate = returnDate.ToString();
                        assetAllocation.ReturnDate = DateTime.Parse (strReturnDate);
                    }

                    assetAllocationsList.Add(assetAllocation);
                    //Console.WriteLine($"Allocation ID: {assetAllocation.AllocationID}, Allocation Date: {assetAllocation.ReturnDate}");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.ToString());
                Console.WriteLine(ex.Message);
            }
        }

        public void syncMaintenanceRecords()
        {
            try
            {
                connection.Open();
                string sql = $"SELECT * FROM maintenance_records";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                maintenanceRecordsList = new List<MaintenanceRecords>();
                while (reader.Read())
                {
                    MaintenanceRecords maintenanceRecord = new MaintenanceRecords();
                    maintenanceRecord.MaintenanceID = (int)reader["maintenance_id"];
                    maintenanceRecord.AssetID = (int)reader["asset_id"];
                    maintenanceRecord.MaintenanceDate = (DateTime)reader["maintenance_date"];
                    maintenanceRecord.Description = (string)reader["description"];
                    double cost = (double)reader["cost"];
                    maintenanceRecord.Cost = (float)cost;

                    maintenanceRecordsList.Add(maintenanceRecord);
                    //Console.WriteLine($"Maintenance ID: {maintenanceRecord.MaintenanceID}, Maintenance Cost: {cost}");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
            }
        }

        public void syncReservations()
        {
            try
            {
                //SqlConnection conn = DBConnection.getConnection();
                connection.Open();
                string sql = $"SELECT * FROM reservations";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                reservationsList = new List<Reservations>();
                while (reader.Read())
                {
                    Reservations reservation = new Reservations();
                    reservation.ReservationID = (int)reader["reservation_id"];
                    reservation.AssetID = (int)reader["asset_id"];
                    reservation.EmployeeID = (int)reader["employee_id"];
                    reservation.ReservationDate = (DateTime)reader["reservation_date"];
                    reservation.StartDate = (DateTime)reader["start_date"];
                    reservation.EndDate = (DateTime)reader["end_date"];
                    reservation.Status = (string)reader["status"];

                    reservationsList.Add(reservation);
                    //Console.WriteLine($"Reservation ID: {reservation.ReservationID}, Status: {reservation.Status}");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public bool addAsset(Assets asset)
        {
            connection.Open();
            string sql = $"INSERT INTO assets VALUES ('{asset.Name}', '{asset.Type}', {asset.SerialNumber}, '{asset.PurchaseDate}', '{asset.Location}', '{asset.Status}', {asset.OwnerID});  SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(sql, connection);
            int assetID = Convert.ToInt32(cmd.ExecuteScalar());
            asset.AssetID = assetID;
            connection.Close();
            assetsList.Add(asset);
            Console.WriteLine($"Asset added successfully with Asset ID: {asset.AssetID}");
            return true;
        }

        public bool updateAsset(Assets asset)
        {
            connection.Open();
            string sql = $"UPDATE assets SET name='{asset.Name}', type='{asset.Type}', serial_number={asset.SerialNumber}, purchase_date='{asset.PurchaseDate}', location='{asset.Location}', status='{asset.Status}', owner_id={asset.OwnerID} WHERE asset_id={asset.AssetID}";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.ExecuteScalar();
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
            Console.WriteLine($"Asset updated successfully with new Asset ID: {asset.AssetID}");
            return true;
        }

        public bool deleteAsset(int assetID)
        {
            try
            {
                connection.Open();
                string sql = $"DELETE FROM maintenance_records WHERE asset_id={assetID};DELETE FROM reservations WHERE asset_id={assetID};DELETE FROM asset_allocations WHERE asset_id={assetID};DELETE FROM assets WHERE asset_id={assetID};";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                int index = assetsList.FindIndex(x => x.AssetID == assetID);
                assetsList.RemoveAt(index);
                Console.WriteLine($"Asset deleted successfully with Asset ID: {assetID}");
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return true;
            }
        }

        public bool allocateAsset(int assetID, int employeeID, string returnDate)
        {
            int index = assetAllocationsList.FindIndex(x => x.AssetID == assetID);
            if (index!= -1 && assetAllocationsList[index].EmployeeID == employeeID)
            {
                Console.WriteLine($"Asset ID: {assetID} has already been allocated to Employee ID: {employeeID}");
            }
            else
            {
                DateTime returnDateTime;
                if (returnDate != null)
                {
                    returnDateTime = DateTime.Parse(returnDate);
                }
                else
                {
                    returnDateTime = DateTime.Parse("12/31/2024");
                }
                connection.Open();
                string sql = $"INSERT INTO asset_allocations VALUES ({assetID}, {employeeID}, '{DateTime.Now}', '{returnDateTime}'); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, connection);
                int assetAllocationID = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

                AssetAllocations allocations = new AssetAllocations();

                allocations.AllocationID = assetAllocationID;
                allocations.AssetID = assetID;
                allocations.EmployeeID = employeeID;
                allocations.AllocationDate = DateTime.Now;
                allocations.ReturnDate = returnDateTime;
                
                Console.WriteLine($"Asset ID: {assetID} has successfully been allocated to Employee ID: {employeeID}");
            }
            return true;
        }

        public bool deallocateAsset(int assetID, int employeeID, string returnDate)
        {
            int index = assetAllocationsList.FindIndex(x => x.AssetID == assetID);
            if (index != -1)
            {
                if (assetAllocationsList[index].EmployeeID == employeeID)
                {
                    DateTime returnDateTime;
                    if (returnDate != null)
                    {
                        returnDateTime = DateTime.Parse(returnDate);
                    }
                    else
                    {
                        returnDateTime = DateTime.Parse("12/31/2024");
                    }
                    if (assetAllocationsList[index].ReturnDate == returnDateTime)
                    {
                        assetAllocationsList.RemoveAt(index);
                    }
                    connection.Open();
                    string sql = $"DELETE FROM asset_allocations WHERE asset_id={assetID} AND employee_id={employeeID};";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    Console.WriteLine($"Asset ID: {assetID} has successfully been Deallocated from Employee ID: {employeeID}");
                }
                else
                {
                    Console.WriteLine($"1. Cannot deallocate since: Asset ID: {assetID} has NOT been allocated to Employee ID: {employeeID}.");
                }
            }
            else
            {
                Console.WriteLine($"2. Cannot deallocate since: Asset ID: {assetID} has NOT been allocated to Employee ID: {employeeID}.");
            }
            return true;
        }

        public bool performMaintenance(int assetID, string maintenanceDate, string description, float cost)
        {
            connection.Open();
            DateTime maintenanceDateTime = DateTime.Parse(maintenanceDate);
            string sql = $"INSERT INTO maintenance_records VALUES ({assetID}, '{maintenanceDateTime}', '{description}', {cost});  SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(sql, connection);
            int maintenanceID = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();

            MaintenanceRecords maintenance = new MaintenanceRecords();
            maintenance.MaintenanceID = maintenanceID;
            maintenance.AssetID = assetID;
            maintenance.MaintenanceDate = maintenanceDateTime;
            maintenance.Description = description;
            maintenance.Cost = cost;
            maintenanceRecordsList.Add(maintenance);
            Console.WriteLine($"Maintenance data added successfully with Maintenance ID: {maintenance.MaintenanceID}");
            return true;
        }

        public bool reserveAsset(int assetID, int employeeID, string reservationDate, string startDate, string endDate)
        {
            DateTime reservationDateTime, startDateTime, endDateTime;
            connection.Open();
            reservationDateTime = DateTime.Parse(reservationDate);
            startDateTime = DateTime.Parse(startDate);
            endDateTime = DateTime.Parse(endDate);
            string status = "Pending";
            string sql = $"INSERT INTO reservations VALUES ({assetID}, {employeeID}, '{reservationDateTime}', '{startDateTime}', '{endDateTime}', '{status}');  SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(sql, connection);
            int reservationID = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();

            Reservations reservation = new Reservations();
            reservation.ReservationID = reservationID;
            reservation.AssetID = assetID;
            reservation.EmployeeID = employeeID;
            reservation.ReservationDate = reservationDateTime;
            reservation.StartDate = startDateTime;
            reservation.EndDate = endDateTime;
            reservation.Status = status;
            reservationsList.Add(reservation);
            Console.WriteLine($"Reservation added successfully with Reservation ID: {reservationID}");
            return true;
        }

        public bool withdrawReservation(int reservationID)
        {
            connection.Open();
            string sql = $"DELETE FROM reservations WHERE reservation_id={reservationID}";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            int index = reservationsList.FindIndex(x => x.ReservationID == reservationID);
            reservationsList.RemoveAt(index);
            Console.WriteLine($"Reservation withdrawn successfully with Reservation ID: {reservationID}");
            return true;
        }
    }
}
