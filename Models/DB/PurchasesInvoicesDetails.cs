using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class PurchasesInvoicesDetails
    {
        public int DetailsId { get; set; }
        public int? Invoiceid { get; set; }
        public int? ItemId { get; set; }
        public float? Qyt { get; set; }
        public float? Cost { get; set; }
        public float? Total { get; set; }
        public DateTime? EpxDate { get; set; }
        public float NewPrice { get; set; }
    }
}
