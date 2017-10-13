using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERMS.Models
{
    public class EmployeeDepartment
    {
        public int Id { get; set; }
        public int EmployeePositionId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime EntryDate { get; set; }

        public EmployeePosition EmployeePosition { get; set; }
        public Department Department { get; set; }

    }
}
