using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class Configuration
    {
        public byte Workstation { get; set; }
        public bool Printinvoice { get; set; }
        public bool Ask { get; set; }
        public byte? Printdevice { get; set; }
        public short? Copys { get; set; }
        public byte Minstock { get; set; }
        public bool Askmin { get; set; }
        public string Backupdrive { get; set; }
        public short? Expirremdays { get; set; }
        public bool? PurchItemCode { get; set; }
        public bool? UseBalanceBarcode { get; set; }
        public byte? HoldOption { get; set; }
        public byte? HoldTimes { get; set; }
        public bool? SupportExpirDate { get; set; }
        public bool? CashCustomerName { get; set; }
        public string DefultCashCustomerCaption { get; set; }
        public bool? InvoiceItemGrouping { get; set; }
        public string ExpirDateFormat { get; set; }
        public byte ScaleBarcodeHeader { get; set; }
        public byte ScaleBarcodedigits { get; set; }
        public byte ScaleItemBarcodeDigits { get; set; }
        public byte ScaleItemBarcodeStartAtPostion { get; set; }
        public string ScaleDataType { get; set; }
        public byte ScaleDataBarcodedigits { get; set; }
        public byte ScaleDataBarcodeStartAtPostion { get; set; }
        public bool? ConfirmSoldItemUnit { get; set; }
        public string Price1Caption { get; set; }
        public string Price2Caption { get; set; }
        public string Price3Caption { get; set; }
        public string Price4Caption { get; set; }
        public byte ItemNameAlignment { get; set; }
        public byte BranchCostExportedFiled { get; set; }
        public byte BranchPrice1ExportedFiled { get; set; }
        public byte BranchPrice2ExportedFiled { get; set; }
        public byte BranchPrice3ExportedFiled { get; set; }
        public byte BranchPrice4ExportedFiled { get; set; }
        public bool? RequestCustomerIdcardNumber { get; set; }
        public bool? RequestQytwhenselectItem { get; set; }
        public bool? ShowDrugUsageGuide { get; set; }
        public bool? PrintDrugUsageLabel { get; set; }
        public bool? PrintCustomerNameLabel { get; set; }
        public byte ConfirmSoldItemUnitMethod { get; set; }
    }
}
