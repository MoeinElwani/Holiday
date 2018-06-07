using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class HoldDetails
    {
        public int RecId { get; set; }
        public int HoldId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public float Qyt { get; set; }
        public float SalePrice { get; set; }
        public float Total { get; set; }
        public byte ItemType { get; set; }
        public bool ExDateF { get; set; }
        public float Cost { get; set; }
        public float ItemPrice { get; set; }
        public float Price2 { get; set; }
        public float Price3 { get; set; }
        public float Price4 { get; set; }
        public float PackageQyt { get; set; }
        public bool? Opf { get; set; }
        public float PackagePrice { get; set; }
        public short PackageUnitId { get; set; }
        public string PackageUnitName { get; set; }
        public short InvUnitId { get; set; }
        public string InvUnitName { get; set; }
        public byte SaledUnitIdF { get; set; }
        public string ItemNote { get; set; }
    }
}
