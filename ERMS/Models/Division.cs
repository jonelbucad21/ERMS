using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERMS.Models
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime EntryDate { get; set; }

        public ICollection<Office> Offices { get; set; }

        public Division()
        {
            Offices = new Collection<Office>();
        }
    }
}
