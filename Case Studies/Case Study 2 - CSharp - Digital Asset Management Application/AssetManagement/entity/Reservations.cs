using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    internal class Reservations
    {
        int reservationID;
        int assetID;
        int employeeID;
        DateTime reservationDate;
        DateTime startDate;
        DateTime endDate;
        string status;

        public int ReservationID
        {
            get => reservationID;
            set => reservationID = value;
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

        public DateTime ReservationDate
        {
            get => reservationDate;
            set => reservationDate = value;
        }

        public DateTime StartDate
        {
            get => startDate;
            set => startDate = value;
        }

        public DateTime EndDate
        {
            get => endDate;
            set => endDate = value;
        }

        public string Status
        {
            get => status;
            set => status = value;
        }
    }
}
