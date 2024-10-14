using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Entity
{
    public class AssetAllocations
    {
        private int _allocationID;
        private int _assetID;
        private int _employeeID;
        private DateTime _allocationDate;
        private DateTime _returnDate;

        public int AllocationID
        {
            get => _allocationID;
            set => _allocationID = value;
        }

        public int AssetID
        {
            get => _assetID;
            set => _assetID = value;
        }

        public int EmployeeID
        {
            get => _employeeID;
            set => _employeeID = value;
        }

        public DateTime AllocationDate
        {
            get => _allocationDate;
            set => _allocationDate = value;
        }

        public DateTime ReturnDate
        {
            get => _returnDate;
            set => _returnDate = value;
        }
    }
}
