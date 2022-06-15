#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OptikerService.Models
{
    public partial class geschaeft
    {

        public int geschaeftsid { get; set; }
        public string adresse { get; set; }
        public string name { get; set; }
        public int personalid { get; set; }
        [JsonIgnore]
        public virtual mitarbeiter personal { get; set; }

        public geschaeft(int geschaeftsid, string adresse, string name, int personalid)
        {
            this.geschaeftsid = geschaeftsid;
            this.adresse = adresse;
            this.name = name;
            this.personalid = personalid;
        }
    }
}