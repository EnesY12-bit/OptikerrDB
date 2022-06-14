﻿#nullable disable
using System;
using System.Collections.Generic;

namespace OptikerService.Models
{
    public partial class mitarbeiter
    {
        public mitarbeiter()
        {
            geschaeft = new HashSet<geschaeft>();
        }

        public int personalid { get; set; }
        public string anrede { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public decimal sozialversicherung { get; set; }
        public decimal gehalt { get; set; }
        public string taetigkeit { get; set; }
        public int geschaeftsid { get; set; }
        public int? kundenid { get; set; }

        public virtual ICollection<geschaeft> geschaeft { get; set; }
    }
}