#nullable disable
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


        public lieferer(int lieferid, string name, string adresse, string email, decimal telefonnummer)
        {
            this.lieferid = lieferid;
            this.name = name;
            this.adresse = adresse;
            this.email = email;
            this.telefonnummer = telefonnummer;
        }
    }
}