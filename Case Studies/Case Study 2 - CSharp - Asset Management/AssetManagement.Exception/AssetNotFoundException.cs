using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Exception
{
    public class AssetNotFoundException : System.Exception
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

        public AssetNotFoundException(string message, System.Exception innerException)
            : base(message, innerException)
        {
            
        }
    }
}
