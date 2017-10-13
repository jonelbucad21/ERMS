using ERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERMS.Controllers.api.DTOs
{
    public class LetterDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int SenderId { get; set; }
        public int LetterTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EntryDate { get; set; }
        public string GetDateCreated
        { get
            {
                return DateCreated.ToString("yyyy-MM-d");
            }
        }
        public string GetEntryDate
        {
            get
            {
                return EntryDate.ToString("yyyy-MM-d");
            }
        }

        public SenderDto Sender { get; set; }
        public LetterTypeDto LetterType { get; set; }
    }
}
