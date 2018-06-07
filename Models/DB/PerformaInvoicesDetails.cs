using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class PerformaInvoicesDetails
    {
        public int DetailsId { get; set; }
        public int? Pinvoiceid { get; set; }
        public int? ItemId { get; set; }
        public float? Qyt { get; set; }
        public float? Cost { get; set; }
        public float? NetTotal { get; set; }
        public DateTime? EpxDate { get; set; }
        public short UnitId { get; set; }
        public float Price { get; set; }
        public float Subtotal { get; set; }
        public float DiscountValue { get; set; }
    }
}
