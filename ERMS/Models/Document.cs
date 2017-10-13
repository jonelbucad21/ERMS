using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace ERMS.Models
{
    public partial class Document
    {
        public int Id { get; private set; }

        public string DocumentNumber { get; set; }
        public string DocumentDetails { get; set; }
        public int DocumentTypeId { get; set; }
        public int BoxId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EntryDate { get; set; }

        public DocumentType DocumentType { get; set; }
        public Box Box { get; set; }

        public Document()
        {
            DocumentType = new DocumentType();
            Box = new Box();
        }

    }
}