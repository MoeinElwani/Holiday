using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class Workstations
    {
        public byte WsId { get; set; }
        public byte? BarcodeRPort { get; set; }
        public byte? DrawerPort { get; set; }
        public string DrawerPrinter { get; set; }
        public string DisplayType { get; set; }
        public byte? DisplayPort { get; set; }
        public byte? FlineData { get; set; }
        public byte? SlineData { get; set; }
        public byte? EFlineData { get; set; }
        public byte? ESlineData { get; set; }
        public string FlineString { get; set; }
        public string SlineString { get; set; }
        public string ReceiptPrinter { get; set; }
        public string InvoicePrinter { get; set; }
        public string ReportPrinter { get; set; }
        public string BarcodePrinter { get; set; }
        public bool PrintReceipt { get; set; }
        public string PrinterType { get; set; }
        public string BarcodeFontName { get; set; }
        public byte DefultPage { get; set; }
    }
}
