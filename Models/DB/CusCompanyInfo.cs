using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class CusCompanyInfo
    {
        public short CusCompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Telphone { get; set; }
        public string ContactName { get; set; }
    }
}
