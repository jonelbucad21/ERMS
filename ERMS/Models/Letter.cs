using System;

namespace ERMS.Models
{
   
    public class Letter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int SenderId { get; set; }
        public int LetterTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EntryDate { get; set; }

        public Sender Sender { get; set; }
        public LetterType LetterType { get; set; }


    }

   
}