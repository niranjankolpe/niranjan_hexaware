using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    internal class AssetNotMaintainException : Exception
    {
        public AssetNotMaintainException() : base("Asset has not been maintained since long. Hence, it cannot be allocated to an employee!")
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
