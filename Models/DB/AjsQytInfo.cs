using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class AjsQytInfo
    {
        public int AjsId { get; set; }
        public DateTime? Adate { get; set; }
        public int? ItemId { get; set; }
        public float? Oldqyt { get; set; }
        public float? Newqyt { get; set; }
        public float? Variance { get; set; }
        public short? OperId { get; set; }
    }
}
