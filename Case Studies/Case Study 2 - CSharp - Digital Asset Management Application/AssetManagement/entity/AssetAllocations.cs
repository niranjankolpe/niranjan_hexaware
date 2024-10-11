using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    internal class AssetAllocations
    {
        int allocationID;
        int assetID;
        int employeeID;
        DateTime allocationDate;
        DateTime returnDate;

        public int AllocationID
        {
            get => allocationID;
            set => allocationID = value;
        }

        public int AssetID
        {
            get => assetID;
            set => assetID = value;
        }

        public int EmployeeID
        {
            get => employeeID;
            set => employeeID = value;
        }

        public DateTime AllocationDate
        {
            get => allocationDate;
            set => allocationDate = value;
        }

        public DateTime ReturnDate
        {
            get => returnDate;
            set => returnDate = value;
        }
    }
}
