using System;
using System.Collections.Generic;

namespace AspNetCoreWebApi.Models
{
    public partial class MT1
    {
        public MT1()
        {
            MT2s = new HashSet<MT2>();
        }

        public long MId { get; set; }
        public string? MC1Text { get; set; }
        public decimal? MC2Decimal { get; set; }
        public DateTime? MC3Date { get; set; }

        public virtual ICollection<MT2> MT2s { get; set; }
    }
}
