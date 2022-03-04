using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AspNetCoreWebApi.Models
{
    public partial class MT1
    {
        public MT1()
        {
            MRelMT1MT2s = new HashSet<MRelMT1MT2>();
        }

        public long MId { get; set; }
        public string? MC1Text { get; set; }
        public decimal? MC2Decimal { get; set; }
        public DateTime? MC3Date { get; set; }

        [JsonIgnore]
        public virtual MT3 MT3 { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<MRelMT1MT2> MRelMT1MT2s { get; set; }
    }
}
