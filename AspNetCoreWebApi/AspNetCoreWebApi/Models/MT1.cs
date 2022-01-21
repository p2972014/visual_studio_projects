using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AspNetCoreWebApi.Models
{
    public partial class MT1
    {        
        public long MId { get; set; }
        [DisplayName("myname1")]
        public string? MC1Text { get; set; }
        public decimal? MC2Decimal { get; set; }
        public DateTime? MC3Date { get; set; }
    }
}
