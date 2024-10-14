using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    public class AssetNotFoundException : Exception
    {
        public override string Message
        {
            get
            {
                return "Asset does not exist!";
            }
        }
        public AssetNotFoundException() : base()
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
