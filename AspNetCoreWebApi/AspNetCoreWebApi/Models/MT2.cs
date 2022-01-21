using System;
using System.Collections.Generic;

namespace AspNetCoreWebApi.Models
{
    public partial class MT2
    {
        public long MId { get; set; }
        public long MT1MId { get; set; }
        public string MC1Text { get; set; } = null!;
    }
}
