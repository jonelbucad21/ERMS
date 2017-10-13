using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERMS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateTime EntryDate { get; set; }

        public Person Person { get; set; }
        public ApplicationUser  ApplicationUser { get; set; }

        public ICollection<EmployeePosition> EmployeePositions { get; set; }

        public Employee()
        {
            EmployeePositions = new Collection<EmployeePosition>();
        }
    }
}
