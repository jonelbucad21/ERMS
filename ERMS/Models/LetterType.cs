using System.Collections.Generic;
using System.Collections.ObjectModel;
using ERMS.Models;

namespace ERMS.Models
{
    public class LetterType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Letter> Letters { get; set; }

        public LetterType()
        {
            Letters = new List<Letter>();
        }
    }
}