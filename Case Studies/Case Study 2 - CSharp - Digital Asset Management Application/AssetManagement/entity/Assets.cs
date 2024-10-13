using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    public class Assets
    {
        private int _assetID;
        private string _name;
        private string _type;
        private int _serialNumber;
        private DateTime _purchaseDate;
        private string _location;
        private string _status;
        private int _ownerID;

        public int AssetID
        {
            get => _assetID;
            set => _assetID = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public int SerialNumber
        {
            get => _serialNumber;
            set => _serialNumber = value;
        }

        public DateTime PurchaseDate
        {
            get => _purchaseDate;
            set => _purchaseDate = value;
        }

        public string Location
        {
            get => _location;
            set => _location = value;
        }

        public string Status
        {
            get => _status;
            set => _status = value;
        }

        public int OwnerID
        {
            get => _ownerID;
            set => _ownerID = value;
        }
    }
}
