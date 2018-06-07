using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class PaymentInfo
    {
        public short PaymentId { get; set; }
        public string PaymentDes { get; set; }
        public short? CurrId { get; set; }
        public byte? PaymentType { get; set; }
        public bool? Status { get; set; }
        public double? Discount { get; set; }
    }
}
