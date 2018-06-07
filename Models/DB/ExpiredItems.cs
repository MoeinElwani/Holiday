using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class ExpiredItems
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public float? Qyt { get; set; }
        public float? Cost { get; set; }
        public short? CasherId { get; set; }
        public DateTime? ExDate { get; set; }
    }
}
