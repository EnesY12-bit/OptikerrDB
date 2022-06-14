#nullable disable
using System;
using System.Collections.Generic;

namespace OptikerService.Models
{
    public partial class geschaeft
    {
        public int geschaeftsid { get; set; }
        public string adresse { get; set; }
        public string name { get; set; }
        public int personalid { get; set; }

        public virtual mitarbeiter personal { get; set; }
    }
}