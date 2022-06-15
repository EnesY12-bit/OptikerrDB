#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OptikerService.Models
{
    public partial class kauft
    {
        public int kundenid { get; set; }
        public int modellid { get; set; }
        [JsonIgnore]
        public virtual kunden kunden { get; set; }
        [JsonIgnore]
        public virtual brillen modell { get; set; }
    }
}