using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement
{
    internal class Employees
    {
        private int employeeID;
        private string name;
        private string department;
        private string email;
        private string password;

        public int EmployeeID
        {
            get => employeeID;
            set => employeeID = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Department
        {
            get => department;
            set => department = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }
    }
}
