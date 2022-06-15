#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OptikerService.Models
{
    public partial class liefert
    {
        public int lieferid { get; set; }
        public int brillenid { get; set; }
        [JsonIgnore]
        public virtual lieferer liefer { get; set; }
        [JsonIgnore]
        public virtual brillen lieferNavigation { get; set; }
    }
}