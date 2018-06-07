using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class AppoinInfo
    {
        public int RecId { get; set; }
        public int SourId { get; set; }
        public DateTime AppoinDate { get; set; }
        public float Amount { get; set; }
        public int Invoiceid { get; set; }
        public bool Paymented { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
