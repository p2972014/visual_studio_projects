using System;
using System.Collections.Generic;

namespace AspNetCoreWebApi.Models.db1.Tables
{
    public partial class m_t1
    {
        public m_t1()
        {
            m_rel_m_t1_m_t2s = new HashSet<m_rel_m_t1_m_t2>();
        }

        public long m_id { get; set; }
        public string? m_c1_text { get; set; }
        public decimal? m_c2_decimal { get; set; }
        public DateTime? m_c3_date { get; set; }
        public Guid? m_c4_uid { get; set; }

        public virtual ICollection<m_rel_m_t1_m_t2> m_rel_m_t1_m_t2s { get; set; }
    }
}
