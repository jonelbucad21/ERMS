using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERMS.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }

        public ICollection<Office> Offices { get; set; }
        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }

        public Department()
        {
            Offices = new Collection<Office>();
            EmployeeDepartments = new Collection<EmployeeDepartment>();
        }

    }
}
