#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OptikerService.Models
{
    public partial class mitarbeiter
    {
        public mitarbeiter()
        {
            geschaeft = new HashSet<geschaeft>();
        }


        public int personalid { get; set; }
        public string anrede { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public decimal sozialversicherung { get; set; }
        public decimal gehalt { get; set; }
        public string taetigkeit { get; set; }
        public int geschaeftsid { get; set; }
        public int? kundenid { get; set; }

        [JsonIgnore]
        public virtual ICollection<geschaeft> geschaeft { get; set; }


        public mitarbeiter(int personalid, string anrede, string name, string adress, decimal sozialversicherung, decimal gehalt, string taetigkeit, int geschaeftsid, int? kundenid)
        {
            this.personalid = personalid;
            this.anrede = anrede;
            this.name = name;
            this.adress = adress;
            this.sozialversicherung = sozialversicherung;
            this.gehalt = gehalt;
            this.taetigkeit = taetigkeit;
            this.geschaeftsid = geschaeftsid;
            this.kundenid = kundenid;
        }
    }
}