using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Entity
{
    public class Employees
    {
        private int _employeeID;
        private string _name;
        private string _department;
        private string _email;
        private string _password;

        public int EmployeeID
        {
            get => _employeeID;
            set => _employeeID = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Department
        {
            get => _department;
            set => _department = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }
    }
}
