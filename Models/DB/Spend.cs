using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class Spend
    {
        public int Id { get; set; }
        public short SetCode { get; set; }
        public DateTime? Regdate { get; set; }
        public DateTime? SpendingDate { get; set; }
        public string Weekday { get; set; }
        public string SpendName { get; set; }
        public float? SpendPrice { get; set; }
        public string Notes { get; set; }
    }
}
