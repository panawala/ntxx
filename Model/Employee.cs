using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepartmentID { get; set; }


        public virtual Department Department { get; set; }
    }
}
