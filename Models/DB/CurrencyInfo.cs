using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class CurrencyInfo
    {
        public short CurId { get; set; }
        public string CurDes { get; set; }
        public string Symbol { get; set; }
        public float? Rate { get; set; }
        public byte? DecNum { get; set; }
    }
}
