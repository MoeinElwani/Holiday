using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class SoldItemsSn
    {
        public int RecId { get; set; }
        public int? InvoiceId { get; set; }
        public int? ItemId { get; set; }
        public string Sn { get; set; }
    }
}
