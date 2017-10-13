using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS.Models
{
    public class Office
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; } 
        public int? DivisionId { get; set; }                 
        public int? SectionId { get; set; }
        public DateTime EntryDate { get; set; }

        public Department Department { get; set; }
        public Division Division { get; set; }
        public Section Section { get; set; }

        public OfficeCode OfficeCode { get; set; }
        public ICollection<Box> Boxes { get; set; } = new Collection<Box>();
        public ICollection<EmployeeOffice> EmployeeOffices { get; set; } = new Collection<EmployeeOffice>();


        [NotMapped]
        private string officename;

        [NotMapped]
        public string GetOffice
        {
            set { officename = value; }
            get { return Section != null ? Section.Name : Division != null ? Division.Name : Department.Name; }
        }

        public Office()
        {
            EmployeeOffices = new Collection<EmployeeOffice>();
           
        }

    }

}
