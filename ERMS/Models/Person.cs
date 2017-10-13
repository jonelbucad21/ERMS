using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERMS.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "MiddleInitials is Required")]
        public string MiddleInitial { get; set; }
        [Required(ErrorMessage = "LastName Name is Required")]
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public DateTime EntryDate { get; set; }


        public Employee Employee { get; set; }
    }
}
