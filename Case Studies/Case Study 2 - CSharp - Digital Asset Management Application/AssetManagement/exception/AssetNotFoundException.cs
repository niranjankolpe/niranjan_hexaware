using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    public class AssetNotFoundException : Exception
    {
        public AssetNotFoundException() : base("Asset does not exist!")
        {
            
        }
        public AssetNotFoundException(string message) : base(message)
        {
        }

        public AssetNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
