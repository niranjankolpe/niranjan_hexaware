using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    public class Reservations
    {
        private int _reservationID;
        private int _assetID;
        private int _employeeID;
        private DateTime _reservationDate;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _status;

        public int ReservationID
        {
            get => _reservationID;
            set => _reservationID = value;
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

        public DateTime ReservationDate
        {
            get => _reservationDate;
            set => _reservationDate = value;
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => _endDate = value;
        }

        public string Status
        {
            get => _status;
            set => _status = value;
        }
    }
}
