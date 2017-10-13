using System;
using System.Collections.Generic;
using System.Text;

namespace ERMS.Models
{
    public class EmployeePosition
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EntryDate { get; set; }

        public Employee Employee { get; set; }
        public Position Position { get; set; }

        public EmployeeDepartment EmployeeDepartment { get; set; }
        public EmployeeOffice EmployeeOffice { get; set; }


    }
}
