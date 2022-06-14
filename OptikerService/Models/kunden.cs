#nullable disable
using System;
using System.Collections.Generic;

namespace OptikerService.Models
{
    public partial class kunden
    {
        public int kundenid { get; set; }
        public string anrede { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public decimal telefonnummer { get; set; }
        public string adresse { get; set; }
        public decimal? kosten { get; set; }
        public decimal bestellungsnummer { get; set; }
        public DateTime datum { get; set; } //DateOnly

        public kunden(int kundenid, string anrede, string name, string email, decimal telefonnummer, string adresse, decimal? kosten, decimal bestellungsnummer, DateTime datum)
        {
            this.kundenid = kundenid;
            this.anrede = anrede;
            this.name = name;
            this.email = email;
            this.telefonnummer = telefonnummer;
            this.adresse = adresse;
            this.kosten = kosten;
            this.bestellungsnummer = bestellungsnummer;
            this.datum = datum;
        }

    }
}