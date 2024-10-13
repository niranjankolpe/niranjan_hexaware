using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    internal class AssetNotMaintainException : Exception
    {
        public override string Message
        {
            get
            {
                return "Asset has not been maintained enough to assign to an employee!";
            }
        }
        public AssetNotMaintainException() : base()
        {
            
        }
        public AssetNotMaintainException(string message) : base(message)
        {
            
        }

        public AssetNotMaintainException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }
    }
}
