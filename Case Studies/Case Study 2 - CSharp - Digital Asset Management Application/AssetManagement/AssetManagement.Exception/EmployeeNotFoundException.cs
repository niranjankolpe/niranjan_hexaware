using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    internal class EmployeeNotFoundException : Exception
    {
        public override string Message
        {
            get
            {
                return "Employee not found!";
            }
        }
        public EmployeeNotFoundException() : base()
        {
            
        }
        public EmployeeNotFoundException(string message) : base(message)
        {
            
        }

        public EmployeeNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }
    }
}
