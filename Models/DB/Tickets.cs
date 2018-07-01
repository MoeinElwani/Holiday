using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class Tickets
    {
        public int InvoiceId { get; set; }
        public int? CusId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public float? Total { get; set; }
        public float Dis { get; set; }
        public short? OperId { get; set; }
        public string Caption { get; set; }
        public short? PaymentId { get; set; }
        public short? InvoiceTypeId { get; set; }
        public short? BranchId { get; set; }
        public byte? SalesmanId { get; set; }
        public byte? Ws { get; set; }
        public byte? ModleId { get; set; }
        public byte StateId { get; set; }
        public byte ModelId { get; set; }
        public string Note { get; set; }
        public bool? Posted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ParentId { set; get; }

    }
}
