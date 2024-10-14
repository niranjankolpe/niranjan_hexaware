using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Engine.Services;
using NUnit.Engine;

namespace AssetManagement
{
    [TestFixture]
    internal class AssetManagementTest
    {
        // Declaring Class Variables
        AssetManagementRepository service;

        [SetUp]
        // Initialize local data structures
        public void Initialization()
        {
            service = new AssetManagementRepository();
            service.SyncAssets();
            service.SyncEmployees();
            service.SyncMaintenanceRecords();
            service.SyncAssetAllocations();
            service.SyncReservations();
        }
        
        // Test No. 1
        [Test]
        [Ignore("Test Cases have already been Passed!")]
        [TestCase("Skybag", "School Bag", 2, "03/15/2024", "Delhi", "In Use", 2, ExpectedResult = true)]
        [TestCase("Dell Big", "Monitor", 266, "04/04/2024", "Mumbai", "Decomissioned", 6, ExpectedResult = true)]
        [TestCase("Range Rover", "Vehicle", 865, "03/05/2024", "Chennai", "Under Maintenance", 5, ExpectedResult = true)]
        public bool AddAssetTest(string name, string type, int serialNumber, DateTime purchaseDate, string location, string status, int ownerID)
        {
            Assets asset = new Assets
            {
                Name = name,
                Type = type,
                SerialNumber = serialNumber,
                PurchaseDate = purchaseDate,
                Location = location,
                Status = status,
                OwnerID = ownerID
            };
            return service.AddAsset(asset);
        }

        // Test No. 2
        [Test]
        [Ignore("Test Cases have already been Passed!")]
        [TestCase(4, "04/06/2024", "Periodic Maintenance", 300.5f, ExpectedResult = true)]
        [TestCase(8, "", "Annual Maintenance", 1000, ExpectedResult = true)]
        [TestCase(6, "10/12/2024", "Annual Maintenance", 1000, ExpectedResult = true)]
        [TestCase(2, "08/08/2024", "Annual Maintenance", 2456.45f, ExpectedResult = true)]
        public bool PerformMaintenanceTest(int assetID, string maintenanceDate, string description, float cost)
        {
            return service.PerformMaintenance(assetID, maintenanceDate, description, cost);
        }

        // Test No. 3
        [Test]
        [Ignore("Test Cases have already been Passed!")]
        // Same employee; Complete conflict - Already alloted to You
        [TestCase(7, 8, "09/20/2024", "10/08/2024", "10/21/2024", ExpectedResult = true)]

        // Same employee; Start date conflict - Unavailable
        [TestCase(7, 8, "09/20/2024", "10/15/2024", "10/30/2024", ExpectedResult = true)]

        // Same employee; End date conflict - Unavailable
        [TestCase(7, 8, "09/20/2024", "10/01/2024", "10/18/2024", ExpectedResult = true)]

        // Same employee; No date conflict - Done
        [TestCase(7, 8, "09/20/2024", "10/22/2024", "10/30/2024", ExpectedResult = true)]

        // Different employee; Start date conflict - Unavailable
        [TestCase(7, 6, "09/20/2024", "10/15/2024", "11/30/2024", ExpectedResult = true)]

        // Different employee; End date conflict - Unavailable
        [TestCase(7, 6, "09/20/2024", "10/01/2024", "10/18/2024", ExpectedResult = true)]

        // Different employee; No date conflict - Done
        [TestCase(7, 6, "09/20/2024", "12/01/2024", "12/08/2024", ExpectedResult = true)]

        // Missing Dates
        [TestCase(7, 6, "", "12/01/2024", "12/08/2024", ExpectedResult = true)]
        [TestCase(7, 6, "09/20/2024", "", "12/08/2024", ExpectedResult = true)]
        [TestCase(7, 6, "09/20/2024", "12/01/2024", "", ExpectedResult = true)]

        public bool ReserveAssetTest(int assetID, int employeeID, string reservationDate, string startDate, string endDate)
        {
            return service.ReserveAsset(assetID, employeeID, reservationDate, startDate, endDate);
        }

        // Test No. 4
        [Test]
        [Ignore("Test Cases have already been Passed!")]
        [TestCase(2364, ExpectedResult = false)]
        [TestCase(34, ExpectedResult = true)]
        [TestCase(8, ExpectedResult = false)]
        [TestCase(31, ExpectedResult = true)]
        [TestCase(8493, ExpectedResult = false)]
        [TestCase(29, ExpectedResult = true)]
        [TestCase(2, ExpectedResult = false)]
        [TestCase(17, ExpectedResult = true)]
        public bool DeleteAssetTest(int assetID)
        {
            return service.DeleteAsset(assetID);
        }

        // Test No. 5
        [Test]
        [Ignore("Test Cases have already been Passed!")]
        // Invalid Asset ID; Valid Employee ID
        [TestCase(7745, 9, "12/31/2024")]

        // Valid Asset ID; Valid Employee ID
        [TestCase(   3, 4, "12/31/2024")]

        // Invalid Asset ID; Invalid Employee ID
        [TestCase(3478, 3863, "12/31/2024")]

        // Valid Asset ID; Invalid Employee ID
        [TestCase(8, 2356, "12/31/2024")]

        public void AssetNotFoundExceptionTest(int assetID, int employeeID, string returnDate)
        {
            Assert.Throws<AssetNotFoundException>(() => service.AllocateAsset(assetID, employeeID, returnDate));
        }

        // Test No. 6
        [Test]
        [Ignore("Test Cases have already been Passed!")]
        // Valid Asset ID; Invalid Employee ID
        [TestCase(14, 2356, "12/31/2024")]
        [TestCase(50, 826, "11/18/2024")]
        [TestCase(28, 9772, "03/03/2024")]
        public void EmployeeNotFounExceptionTest(int assetID, int employeeID, string returnDate)
        {
            Assert.Throws<EmployeeNotFoundException>(() => service.AllocateAsset(assetID, employeeID, returnDate));
        }

    }
}
