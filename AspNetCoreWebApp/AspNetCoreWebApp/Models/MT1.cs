using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.Models
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

        public virtual MT3 MT3 { get; set; } = null!;
        public virtual ICollection<MRelMT1MT2> MRelMT1MT2s { get; set; }
    }
}
