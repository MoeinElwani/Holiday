using System;
using System.Collections.Generic;

namespace Vue2Spa.Models.DB
{
    public partial class Customers
    {
        public int CusId { get; set; }
        public string IdCard { get; set; }
        public short CusCompanyId { get; set; }
        public short CusgroupId { get; set; }
        public string CusName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public DateTime? OpenAccDate { get; set; }
        public DateTime? CloseAccDate { get; set; }
        public short? DisType { get; set; }
        public short? SalePrice { get; set; }
        public short? Discount { get; set; }
        public float? CreditLimet { get; set; }
        public float? Balance { get; set; }
        public short? DurTime { get; set; }
        public double? OpenValue { get; set; }
        public DateTime? LastSalDate { get; set; }
        public float? TotalSaving { get; set; }
        public int? TotalVisits { get; set; }
        public float? TotalSale { get; set; }
        public float? TotalRet { get; set; }
        public float? InvoiceAvr { get; set; }
        public float? TotalUnit { get; set; }
        public float? RetUnit { get; set; }
        public byte? SalesmanId { get; set; }
    }
}
