using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERMS.Models
{
    public class Box
    {   
        public int Id { get; private set; }
        public string ControlNumber { get; set; }
        public string Remarks { get; set; }
        public ApplicationUser Creator { get; set; }
        public int OfficeId { get; set; }
        public DateTime EntryDate { get; set; }


        public Office Office { get; set; }
        public ICollection<Document> Documents { get; set; }

        public Box()
        {
            Documents = new Collection<Document>();
            Creator = new ApplicationUser();
            Office = new Office();
        }
    }
}