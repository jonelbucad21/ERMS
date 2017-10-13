using System;
using System.Collections.Generic;
using System.Text;

namespace ERMS.Models
{
    public class EmployeeDesignation
    {
        public int Id { get; set; }
        public int DesignationId { get; set; }
        public int EmployeeOfficeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EntryDate { get; set; }

        public Designation Designation { get; set; }
        public EmployeeOffice EmployeeOffice { get; set; }
    }
}
