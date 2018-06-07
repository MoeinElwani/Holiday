using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class PurchasesInvoices
    {
        public int Invoiceid { get; set; }
        public string Invoicenum { get; set; }
        public DateTime? Invoicedate { get; set; }
        public DateTime? Invoicetime { get; set; }
        public int? SourId { get; set; }
        public short? UserId { get; set; }
        public float? SubTotal { get; set; }
        public float? DisTotal { get; set; }
        public float? TaxTotal { get; set; }
        public float? OtherFee { get; set; }
        public float? NetTotal { get; set; }
        public bool? Posted { get; set; }
        public byte? InvoiceTypeId { get; set; }
        public byte? PaymentId { get; set; }
        public short? BranchId { get; set; }
        public bool? SystemNum { get; set; }
    }
}
