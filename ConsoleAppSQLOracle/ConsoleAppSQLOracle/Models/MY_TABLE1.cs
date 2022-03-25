using System;
using System.Collections.Generic;

namespace ConsoleAppSQLOracle.Models
{
    public partial class MY_TABLE1
    {
        public decimal M_ID { get; set; }
        public decimal? M_C1_INT { get; set; }
        public decimal? M_C2_INTEGER { get; set; }
        public string? M_C3_LONG { get; set; }
        public decimal? M_C4_NUMBER { get; set; }
        public decimal? M_C5_NUMERIC { get; set; }
        public string? M_C6_VARCHAR2 { get; set; }
        public string? M_C7_NVARCHAR2 { get; set; }
        public byte[]? M_C8_BLOB { get; set; }
        public byte[]? M_C9_BFILE { get; set; }
        public DateTime? M_C10_DATE { get; set; }
        public DateTime? M_C11_TIME { get; set; }
    }
}
