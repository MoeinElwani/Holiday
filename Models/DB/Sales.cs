using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class Sales
    {
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        public int? ItemId { get; set; }
        public float? Qyt { get; set; }
        public float? Cost { get; set; }
        public float? Price { get; set; }
        public float? Total { get; set; }
        public float? DisAmount { get; set; }
        public DateTime? ExpDate { get; set; }
        public short? UnitId { get; set; }
        
        public int? ReturenQantity { get; set; }
    }
}
