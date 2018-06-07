using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class SourceCreditDebit
    {
        public int RecId { get; set; }
        public int SourId { get; set; }
        public DateTime? Date { get; set; }
        public short? AmountType { get; set; }
        public float? AmountVal { get; set; }
        public int? Invoiceid { get; set; }
        public float CreditAmount { get; set; }
        public float DebitAmount { get; set; }
        public short OperId { get; set; }
    }
}
