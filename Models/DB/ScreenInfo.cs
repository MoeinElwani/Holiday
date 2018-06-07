using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class ScreenInfo
    {
        public int Id { get; set; }
        public byte PageId { get; set; }
        public byte ButtonId { get; set; }
        public int ItemId { get; set; }
        public string ItemDesc { get; set; }
        public int BackcolorId { get; set; }
    }
}
