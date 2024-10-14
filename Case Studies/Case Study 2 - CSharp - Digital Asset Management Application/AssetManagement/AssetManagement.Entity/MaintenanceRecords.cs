using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    public class MaintenanceRecords
    {
        private int _maintenanceID;
        private int _assetID;
        private DateTime _maintenanceDate;
        private string _description;
        private float _cost;

        public int MaintenanceID
        {
            get => _maintenanceID;
            set => _maintenanceID = value;
        }

        public int AssetID
        {
            get => _assetID;
            set => _assetID = value;
        }

        public DateTime MaintenanceDate
        {
            get => _maintenanceDate;
            set => _maintenanceDate = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public float Cost
        {
            get => _cost;
            set => _cost = value;
        }
    }
}
