using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERMS.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Display(Name = "Position")]
        public string Name { get; set; }

        public ICollection<EmployeePosition> EmployeePositions { get; set; }

        public Position()
        {
           EmployeePositions = new Collection<EmployeePosition>();
        }
    }
}
