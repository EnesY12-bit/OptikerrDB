#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OptikerService.Models
{
    public partial class betreut
    {
        public int personalid { get; set; }
        public int kundenid { get; set; }

        [JsonIgnore]
        public virtual kunden kunden { get; set; }
        [JsonIgnore]
        public virtual mitarbeiter personal { get; set; }
    }
}