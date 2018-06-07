using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class Master
    {
        public int ItemId { get; set; }
        public string EnNum { get; set; }
        public string ManfId { get; set; }
        public string Codebar { get; set; }
        public string Secbarcode { get; set; }
        public string ItemName { get; set; }
        public string ItemName2 { get; set; }
        public short? UnitId { get; set; }
        public float? InStock { get; set; }
        public float? Cost { get; set; }
        public float? LastCost { get; set; }
        public int? Margin { get; set; }
        public float? ItemPrice { get; set; }
        public float? Price2 { get; set; }
        public float? Price3 { get; set; }
        public float? Price4 { get; set; }
        public short? Markdowp2 { get; set; }
        public short? Markdowp3 { get; set; }
        public short? Markdowp4 { get; set; }
        public short? ItemType { get; set; }
        public short? DepId { get; set; }
        public short? TypeId { get; set; }
        public short? GroupId { get; set; }
        public short? CompId { get; set; }
        public float? LowAmount { get; set; }
        public float? Rslevel { get; set; }
        public float? Soldqyt { get; set; }
        public DateTime? LastSoldDate { get; set; }
        public bool ExDateF { get; set; }
        public bool? SnF { get; set; }
        public bool? StopSaleF { get; set; }
        public short? LocId { get; set; }
        public bool? SysBarcode { get; set; }
        public int? PicId { get; set; }
        public bool? OpenPriceF { get; set; }
        public float PackageQyt { get; set; }
        public DateTime? LastReceivedDate { get; set; }
        public short? PackageUnitId { get; set; }
        public float? PackagePrice { get; set; }
        public string PackageBarcode { get; set; }
        public string Barcode3 { get; set; }
        public string Barcode4 { get; set; }
        public DateTime? LastQytadjdate { get; set; }
        public float? PackagePrice2 { get; set; }
        public float? PackagePrice3 { get; set; }
        public float? PackagePrice4 { get; set; }
        public bool? ConfirmSoldItemUnit { get; set; }
        public int? IsReversabel { get; set; }
        public short? DaysReverse { get; set; }
        public short? Discount { get; set; }
    }
}
