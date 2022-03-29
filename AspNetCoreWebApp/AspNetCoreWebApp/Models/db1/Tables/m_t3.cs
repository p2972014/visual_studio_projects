using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.Models.db1.Tables
{
    public partial class m_t3
    {
        public long m_id { get; set; }
        public string m_text { get; set; } = null!;
        public long m_t1_m_id { get; set; }

        public virtual m_t1 m_idNavigation { get; set; } = null!;
    }
}
