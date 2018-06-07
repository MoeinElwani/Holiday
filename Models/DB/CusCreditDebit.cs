using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class CusCreditDebit
    {
        public int RecId { get; set; }
        public int CusId { get; set; }
        public DateTime? Date { get; set; }
        public byte? AmountType { get; set; }
        public int InvoiceId { get; set; }
        public float? AmountVal { get; set; }
        public float CreditAmount { get; set; }
        public float DebitAmount { get; set; }
        public short OperId { get; set; }
        public byte SalesmanId { get; set; }
    }
}
