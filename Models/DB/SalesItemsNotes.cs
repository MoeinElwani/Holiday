using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class SalesItemsNotes
    {
        public int RecId { get; set; }
        public int SaleRecId { get; set; }
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
        public string ItemNote { get; set; }
    }
}
