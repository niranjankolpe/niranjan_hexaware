using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    internal class ReservationNotFoundException : Exception
    {
        public override string Message
        {
            get
            {
                return "Given Reservation ID does not exist!";
            }
        }
        public ReservationNotFoundException() : base()
        {
            
        }
        public ReservationNotFoundException(string message) : base(message)
        {
            
        }

        public ReservationNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }
    }
}
