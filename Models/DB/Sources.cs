using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class Sources
    {
        public int SourId { get; set; }
        public string SourName { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public float? Balance { get; set; }
        public float? OpenValue { get; set; }
        public short? CurId { get; set; }
    }
}
