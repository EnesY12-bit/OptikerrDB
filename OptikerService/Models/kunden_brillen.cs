#nullable disable
using System;
using System.Collections.Generic;

namespace OptikerService.Models
{
    public partial class kunden_brillen
    {
        public int? id { get; set; }
        public string name { get; set; }
        public decimal? kosten { get; set; }
        public decimal? bestellungsnummer { get; set; }
        public string brillenname { get; set; }
    }
}