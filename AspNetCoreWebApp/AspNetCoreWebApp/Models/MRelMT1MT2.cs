using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.Models
{
    public partial class MRelMT1MT2
    {
        public long MT1MId { get; set; }
        public long MT2MId { get; set; }
        public long MId { get; set; }

        public virtual MT1 MT1M { get; set; } = null!;
        public virtual MT2 MT2M { get; set; } = null!;
    }
}
