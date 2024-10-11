using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    internal class MaintenanceRecords
    {
        int maintenanceID;
        int assetID;
        DateTime maintenanceDate;
        string description;
        float cost;

        public int MaintenanceID
        {
            get => maintenanceID;
            set => maintenanceID = value;
        }

        public int AssetID
        {
            get => assetID;
            set => assetID = value;
        }

        public DateTime MaintenanceDate
        {
            get => maintenanceDate;
            set => maintenanceDate = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public float Cost
        {
            get => cost;
            set => cost = value;
        }
    }
}
