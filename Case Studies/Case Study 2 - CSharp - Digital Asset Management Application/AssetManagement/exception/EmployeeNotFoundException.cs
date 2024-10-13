using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    internal class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException() : base("Employee not found!")
        {
            
        }
        public EmployeeNotFoundException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public EmployeeNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
