#nullable disable
using System;
using System.Collections.Generic;

namespace OptikerService.Models
{
    public partial class mitarbeiter_kunden
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string kundenname { get; set; }
        public int? kundenid { get; set; }
    }
}