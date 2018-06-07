using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class Groups
    {
        public short GroupId { get; set; }
        public short? TypeId { get; set; }
        public string GroupDes { get; set; }
        public double? Discount { get; set; }
        public bool? IsReversabel { get; set; }
        public short? DaysReverse { get; set; }
    }
}
