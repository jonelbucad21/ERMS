using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ERMS.Models;

namespace ERMS.Models
{
    public class Sender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime EntryDate { get; set; }

        public List<Letter> Letters { get; set; }
        public Sender()
        {
            Letters = new List<Letter>();
        }
    }
}