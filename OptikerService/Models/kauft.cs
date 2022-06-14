#nullable disable
using System;
using System.Collections.Generic;

namespace OptikerService.Models
{
    public partial class kauft
    {
        public int kundenid { get; set; }
        public int modellid { get; set; }

        public virtual kunden kunden { get; set; }
        public virtual brillen modell { get; set; }
    }
}