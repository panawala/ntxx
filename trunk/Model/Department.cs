using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DeparmentName { get; set; }

        public string Remark { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
