using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AspNetCoreWebApi.Models
{
    public partial class MT2
    {
        public MT2()
        {
            MRelMT1MT2s = new HashSet<MRelMT1MT2>();
        }

        public long MId { get; set; }
        public string MC1Text { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<MRelMT1MT2> MRelMT1MT2s { get; set; }
    }
}
