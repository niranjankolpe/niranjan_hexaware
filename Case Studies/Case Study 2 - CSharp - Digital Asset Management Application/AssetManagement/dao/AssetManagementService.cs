using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement;

namespace AssetManagement
{
    public interface AssetManagementService
    {
        bool addAsset(Assets asset);

        bool updateAsset(Assets asset);

        bool deleteAsset(int assetID);

        bool allocateAsset(int assetID, int employeeID, string allocationDate);

        bool deallocateAsset(int assetID, int employeeID, string returnDate);

        bool performMaintenance(int assetID, string maintenanceDate, string description, float cost);

        bool reserveAsset(int assetID, int employeeID, string reservationDate, string startDate, string endDate);

        bool withdrawReservation(int reservationID);
    }
}
