using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class HoldInvoice
    {
        public int HoldId { get; set; }
        public DateTime HoldTime { get; set; }
        public int CusId { get; set; }
        public string CusName { get; set; }
        public byte PriceLevel { get; set; }
        public float InvoiceTotal { get; set; }
        public float InvoiceDis { get; set; }
        public short OperId { get; set; }
        public byte Ws { get; set; }
        public byte BranchId { get; set; }
    }
}
