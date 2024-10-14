using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement;

namespace AssetManagement
{
    public class AssetManagementService : IAssetManagementService
    {
        private AssetManagementRepository _respository;

        public AssetManagementService(AssetManagementRepository respository)
        {
            _respository = respository;
        }
        public bool AddAsset(Assets asset)
        {
            return _respository.AddAsset(asset);
        }

        public bool UpdateAsset(Assets asset)
        {
            return _respository.UpdateAsset(asset);
        }

        public bool DeleteAsset(int assetID)
        {
            return _respository.DeleteAsset(assetID);
        }

        public bool AllocateAsset(int assetID, int employeeID, string allocationDate)
        {
            return _respository.AllocateAsset(assetID, employeeID, allocationDate);
        }

        public bool DeallocateAsset(int assetID, int employeeID, string returnDate)
        {
            return _respository.DeallocateAsset(assetID, employeeID, returnDate);
        }

        public bool PerformMaintenance(int assetID, string maintenanceDate, string description, float cost)
        {
            return _respository.PerformMaintenance(assetID, maintenanceDate, description, cost);
        }

        public bool ReserveAsset(int assetID, int employeeID, string reservationDate, string startDate, string endDate)
        {
            return _respository.ReserveAsset(assetID, employeeID, reservationDate, startDate, endDate);
        }

        public bool WithdrawReservation(int reservationID)
        {
            return _respository.WithdrawReservation(reservationID);
        }
    }
}
