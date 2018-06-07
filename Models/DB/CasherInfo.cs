using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class CasherInfo
    {
        public short OperId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public short? UserState { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool HoldInvoice { get; set; }
        public bool RecallInvoice { get; set; }
        public bool ClearInvoice { get; set; }
        public bool DelItem { get; set; }
        public bool OpenDrawer { get; set; }
        public bool PrintNoPrint { get; set; }
        public bool CusSale { get; set; }
        public bool DisByAmount { get; set; }
        public bool DisByPer { get; set; }
        public bool CancleDis { get; set; }
        public bool Refund { get; set; }
        public bool InvoiceNote { get; set; }
        public bool ExitSale { get; set; }
        public bool CashSale { get; set; }
        public bool OtherSale { get; set; }
        public bool RunBackoffice { get; set; }
        public bool Items { get; set; }
        public bool AddItem { get; set; }
        public bool UpdateItem { get; set; }
        public bool UpdateStock { get; set; }
        public bool UpdateExpir { get; set; }
        public bool Customers { get; set; }
        public bool UpdateCus { get; set; }
        public bool CusAcc { get; set; }
        public bool AddCus { get; set; }
        public bool Sources { get; set; }
        public bool AddSou { get; set; }
        public bool UpdateSou { get; set; }
        public bool SouAcc { get; set; }
        public bool SaleRep { get; set; }
        public bool PurchRep { get; set; }
        public bool MangRep { get; set; }
        public bool StatRep { get; set; }
        public bool ListsRep { get; set; }
        public bool Department { get; set; }
        public bool Types { get; set; }
        public bool Groups { get; set; }
        public bool Units { get; set; }
        public bool Companys { get; set; }
        public bool Location { get; set; }
        public bool Payment { get; set; }
        public bool Curancy { get; set; }
        public bool Sales { get; set; }
        public bool Purchers { get; set; }
        public bool UpdatePrice { get; set; }
        public bool UpdateMinMax { get; set; }
        public bool PrintLable { get; set; }
        public bool Spends { get; set; }
        public bool? CasherSetup { get; set; }
        public bool? PurchersReturn { get; set; }
        public bool? CasherReport { get; set; }
        public bool? SaleReport { get; set; }
        public bool? PrintLastInvoice { get; set; }
        public bool? PriceLevel { get; set; }
        public bool? AutoCloseSaleWindow { get; set; }
        public bool? ChangeInvoiceDiscount { get; set; }
        public bool? CasherLogfile { get; set; }
        public byte[] Photo { get; set; }
        public bool? ShowItemCost { get; set; }
        public bool? CanDisplayItemCost { get; set; }
        public bool? CanEditItemCost { get; set; }
        public bool? CanEditItemPrice { get; set; }
        public string OperatorPhone { get; set; }
        public byte UsersGroupIdFk { get; set; }
        public bool? IsActiveAccount { get; set; }
    }
}
