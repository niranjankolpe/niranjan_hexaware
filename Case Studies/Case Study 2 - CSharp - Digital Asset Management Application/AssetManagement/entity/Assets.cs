using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    public class Assets
    {
        int assetID;
        string name;
        string type;
        int serialNumber;
        DateTime purchaseDate;
        string location;
        string status;
        int ownerID;

        public int AssetID
        {
            get => assetID;
            set => assetID = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        public int SerialNumber
        {
            get => serialNumber;
            set => serialNumber = value;
        }

        public DateTime PurchaseDate
        {
            get => purchaseDate;
            set => purchaseDate = value;
        }

        public string Location
        {
            get => location;
            set => location = value;
        }

        public string Status
        {
            get => status;
            set => status = value;
        }

        public int OwnerID
        {
            get => ownerID;
            set => ownerID = value;
        }
    }
}
