using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class StockMovement
    {
        public int RecId { get; set; }
        public DateTime OpDate { get; set; }
        public int ItemId { get; set; }
        public float Qyt { get; set; }
        public byte SourceType { get; set; }
        public short OperId { get; set; }
    }
}
