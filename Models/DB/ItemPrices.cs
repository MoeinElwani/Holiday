using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class ItemPrices
    {
        public int ItemId { get; set; }
        public int PaymentId { get; set; }
        public double? Price { get; set; }
        public bool? State { get; set; }
    }
}
