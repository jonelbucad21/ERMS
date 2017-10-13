using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ERMS.Models
{
    public class OfficeCode
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int OfficeId { get; set; }

        public Office Office { get; set; } = new Office();


    }
}
