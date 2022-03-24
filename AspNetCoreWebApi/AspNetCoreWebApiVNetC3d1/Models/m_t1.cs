using System;
using System.Collections.Generic;

namespace AspNetCoreWebApiVNetC3d1.Models
{
    public partial class m_t1
    {
        public m_t1()
        {
            m_rel_m_t1_m_t2 = new HashSet<m_rel_m_t1_m_t2>();
        }

        public long m_id { get; set; }
        public string m_c1_text { get; set; }
        public decimal? m_c2_decimal { get; set; }
        public DateTime? m_c3_date { get; set; }

        public virtual m_t3 m_t3 { get; set; }
        public virtual ICollection<m_rel_m_t1_m_t2> m_rel_m_t1_m_t2 { get; set; }
    }
}
