using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class BranchInfo
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BAddress { get; set; }
        public string TelNum { get; set; }
        public byte[] Logo { get; set; }
        public string Msg1 { get; set; }
        public string Msg2 { get; set; }
        public string Msg3 { get; set; }
        public byte DefaultCurrencyId { get; set; }
    }
}
