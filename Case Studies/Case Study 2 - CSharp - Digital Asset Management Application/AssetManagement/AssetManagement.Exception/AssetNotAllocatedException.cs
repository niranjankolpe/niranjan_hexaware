using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    public class AssetNotAllocatedException : Exception
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

        public AssetNotAllocatedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
