using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class ItemsExpDate
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public float? Qyt { get; set; }
        public DateTime? ExpDate { get; set; }
        public bool? BatchSt { get; set; }
    }
}
