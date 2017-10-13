using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ERMS.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }

        public ICollection<Office> Offices { get; set; }

        public Section()
        {
            Offices = new Collection<Office>();
        }
    }
}
