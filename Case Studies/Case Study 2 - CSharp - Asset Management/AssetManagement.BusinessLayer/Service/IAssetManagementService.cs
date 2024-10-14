using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement;
using AssetManagement.Entity;

namespace AssetManagement.BusinessLayer
{
    public interface IAssetManagementService
    {
        bool AddAsset(Assets asset);

        bool UpdateAsset(Assets asset);

        bool DeleteAsset(int assetID);

        bool AllocateAsset(int assetID, int employeeID, string allocationDate);

        bool DeallocateAsset(int assetID, int employeeID, string returnDate);

        bool PerformMaintenance(int assetID, string maintenanceDate, string description, float cost);

        bool ReserveAsset(int assetID, int employeeID, string reservationDate, string startDate, string endDate);

        bool WithdrawReservation(int reservationID);
    }
}
