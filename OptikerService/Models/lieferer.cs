﻿#nullable disable
using System;
using System.Collections.Generic;

namespace OptikerService.Models
{
    public partial class lieferer
    {
        public int lieferid { get; set; }
        public string name { get; set; }
        public string adresse { get; set; }
        public string email { get; set; }
        public decimal telefonnummer { get; set; }
    }
}