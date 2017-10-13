using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ERMS.Models
{
    public class Designation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }

        public ICollection<EmployeeDesignation> EmployeeDesignations { get; set; }

        public Designation()
        {
           EmployeeDesignations = new Collection<EmployeeDesignation>();
        }
    }
}
