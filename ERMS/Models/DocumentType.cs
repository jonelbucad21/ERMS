using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace ERMS.Models
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Active { get; set; }
        public int Storage { get; set; }
        public string Remarks { get; set; }
        public DateTime EntryDate { get; set; }

        [NotMapped]
        public int GetRetention => Active + Storage;

        public ICollection<Document> Documents { get; set; }

        public DocumentType()
        {
            Documents = new Collection<Document>();
        }
    }
}