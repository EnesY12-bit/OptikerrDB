﻿#nullable disable
using System;
using System.Collections.Generic;

namespace OptikerService.Models
{
    public partial class liefert
    {
        public int lieferid { get; set; }
        public int brillenid { get; set; }

        public virtual lieferer liefer { get; set; }
        public virtual brillen lieferNavigation { get; set; }
    }
}