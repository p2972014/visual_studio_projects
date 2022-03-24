using System;
using System.Collections.Generic;

namespace AspNetCoreWebApiVNetC3d1.Models
{
    public partial class m_rel_m_t1_m_t2
    {
        public long m_t1_m_id { get; set; }
        public long m_t2_m_id { get; set; }
        public long m_id { get; set; }

        public virtual m_t1 m_t1_m_ { get; set; }
        public virtual m_t2 m_t2_m_ { get; set; }
    }
}
