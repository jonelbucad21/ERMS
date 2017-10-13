using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERMS.Models
{
    public class EmployeeOffice
    {
        
        public int Id { get; set; }
        public int EmployeePositionId { get; set; }
        public int OfficeId { get; set; }
        public DateTime EntryDate { get; set; }

        public Office Office { get; set; }
        public EmployeePosition EmployeePosition { get; set; }

        public ICollection<EmployeeDesignation> EmployeeDesignations { get; set; }

        public EmployeeOffice()
        {
            EmployeeDesignations = new Collection<EmployeeDesignation>();
        }

    }
}
