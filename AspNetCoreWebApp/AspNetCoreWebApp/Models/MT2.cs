using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.Models
{
    public partial class MT2
    {
        public MT2()
        {
            MRelMT1MT2s = new HashSet<MRelMT1MT2>();
        }

        public long MId { get; set; }
        public string MC1Text { get; set; } = null!;

        public virtual ICollection<MRelMT1MT2> MRelMT1MT2s { get; set; }
    }
}
