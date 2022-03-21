using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.Models
{
    public partial class MT3
    {
        public long MId { get; set; }
        public string MText { get; set; } = null!;
        public long MT1MId { get; set; }

        public virtual MT1 MIdNavigation { get; set; } = null!;
    }
}
