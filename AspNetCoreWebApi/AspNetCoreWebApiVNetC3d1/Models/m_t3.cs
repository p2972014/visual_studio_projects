using System;
using System.Collections.Generic;

namespace AspNetCoreWebApiVNetC3d1.Models
{
    public partial class m_t3
    {
        public long m_id { get; set; }
        public string m_text { get; set; }
        public long m_t1_m_id { get; set; }

        public virtual m_t1 m_ { get; set; }
    }
}
