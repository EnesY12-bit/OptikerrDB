#nullable disable
using System;
using System.Collections.Generic;

namespace OptikerrDB.Models
{
    public partial class betreut
    {
        public int personalid { get; set; }
        public int kundenid { get; set; }

        public virtual kunden kunden { get; set; }
        public virtual mitarbeiter personal { get; set; }
    }
}