using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Exception
{
    public class AssetNotAllocatedException : System.Exception
    {
        public override string Message
        {
            get
            {
                return "Asset has NOT been allocated to given employee!";
            }
        }
        public AssetNotAllocatedException() : base()
        {

        }
        public AssetNotAllocatedException(string message) : base(message)
        {

        }

        public AssetNotAllocatedException(string message, System.Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
