using System;
using System.Collections.Generic;

namespace AspNetCoreWebApi.Models.db1.Tables
{
    public partial class m_rel_m_t1_m_t2
    {
        public long m_id { get; set; }
        public long m_t1_m_id { get; set; }
        public long m_t2_m_id { get; set; }

        public virtual m_t1 m_t1_m { get; set; } = null!;
        public virtual m_t2 m_t2_m { get; set; } = null!;
    }
}
