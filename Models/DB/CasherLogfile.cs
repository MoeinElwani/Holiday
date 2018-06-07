using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class CasherLogfile
    {
        public int LoginoutId { get; set; }
        public short OperId { get; set; }
        public DateTime? LoginDate { get; set; }
        public DateTime? LogoutDate { get; set; }
        public byte? ModleId { get; set; }
        public byte ModelId { get; set; }
    }
}
