using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class PerformaInvoices
    {
        public int Pinvoiceid { get; set; }
        public DateTime? Invoicedate { get; set; }
        public int? CusId { get; set; }
        public short? CreatedBy { get; set; }
        public float? SubTotal { get; set; }
        public float? DisTotal { get; set; }
        public float? TaxTotal { get; set; }
        public float? NetTotal { get; set; }
        public bool Posted { get; set; }
        public int? Invoiceid { get; set; }
        public byte? BranchId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public short? LastModifyBy { get; set; }
    }
}
