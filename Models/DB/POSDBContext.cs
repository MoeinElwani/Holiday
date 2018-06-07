using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vue2Spa.Models.DB
{
    public partial class POSDBContext : DbContext
    {
        public POSDBContext(DbContextOptions<POSDBContext> options) : base(options)
        { }
        public virtual DbSet<AjsQytInfo> AjsQytInfo { get; set; }
        public virtual DbSet<AmountTypes> AmountTypes { get; set; }
        public virtual DbSet<AppoinInfo> AppoinInfo { get; set; }
        public virtual DbSet<BranchInfo> BranchInfo { get; set; }
        public virtual DbSet<CasherInfo> CasherInfo { get; set; }
        public virtual DbSet<CasherLogfile> CasherLogfile { get; set; }
        public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<CurrencyInfo> CurrencyInfo { get; set; }
        public virtual DbSet<CusCompanyInfo> CusCompanyInfo { get; set; }
        public virtual DbSet<CusCreditDebit> CusCreditDebit { get; set; }
        public virtual DbSet<CusgroupInfo> CusgroupInfo { get; set; }
        public virtual DbSet<CusReceipts> CusReceipts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<ExpiredItems> ExpiredItems { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<HoldDetails> HoldDetails { get; set; }
        public virtual DbSet<HoldInvoice> HoldInvoice { get; set; }
        public virtual DbSet<InvoiceTypes> InvoiceTypes { get; set; }
        public virtual DbSet<ItemPrices> ItemPrices { get; set; }
        public virtual DbSet<ItemsExpDate> ItemsExpDate { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Master> Master { get; set; }
        public virtual DbSet<PaymentInfo> PaymentInfo { get; set; }
        public virtual DbSet<PdtFiles> PdtFiles { get; set; }
        public virtual DbSet<PerformaInvoices> PerformaInvoices { get; set; }
        public virtual DbSet<PerformaInvoicesDetails> PerformaInvoicesDetails { get; set; }
        public virtual DbSet<PurchasesInvoices> PurchasesInvoices { get; set; }
        public virtual DbSet<PurchasesInvoicesDetails> PurchasesInvoicesDetails { get; set; }
        public virtual DbSet<RefUsersGroups> RefUsersGroups { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesItemsNotes> SalesItemsNotes { get; set; }
        public virtual DbSet<SalesmanInfo> SalesmanInfo { get; set; }
        public virtual DbSet<ScreenInfo> ScreenInfo { get; set; }
        public virtual DbSet<SoldItemsSn> SoldItemsSn { get; set; }
        public virtual DbSet<SourceCreditDebit> SourceCreditDebit { get; set; }
        public virtual DbSet<SourceReceipts> SourceReceipts { get; set; }
        public virtual DbSet<Sources> Sources { get; set; }
        public virtual DbSet<Spend> Spend { get; set; }
        public virtual DbSet<SpendSets> SpendSets { get; set; }
        public virtual DbSet<StockMovement> StockMovement { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<TransTypes> TransTypes { get; set; }
        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Workstations> Workstations { get; set; }

        // Unable to generate entity type for table 'dbo.LAST_TICKET'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.LabelsToPrint'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.items'. Please see the warning messages.

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AjsQytInfo>(entity =>
            {
                entity.HasKey(e => e.AjsId);

                entity.ToTable("AJS_QYT_INFO");

                entity.Property(e => e.AjsId).HasColumnName("AJS_ID");

                entity.Property(e => e.Adate)
                    .HasColumnName("ADATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.Newqyt).HasColumnName("NEWQYT");

                entity.Property(e => e.Oldqyt).HasColumnName("OLDQYT");

                entity.Property(e => e.OperId).HasColumnName("OPER_ID");

                entity.Property(e => e.Variance).HasColumnName("VARIANCE");
            });

            modelBuilder.Entity<AmountTypes>(entity =>
            {
                entity.HasKey(e => e.AmountTypeId);

                entity.ToTable("amount_types");

                entity.Property(e => e.AmountTypeId)
                    .HasColumnName("amount_type_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AmountTypeDes)
                    .IsRequired()
                    .HasColumnName("amount_type_des")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AppoinInfo>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.ToTable("appoin_info");

                entity.Property(e => e.RecId).HasColumnName("rec_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.AppoinDate)
                    .HasColumnName("appoin_date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Invoiceid).HasColumnName("invoiceid");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Paymented).HasColumnName("paymented");

                entity.Property(e => e.SourId).HasColumnName("sour_id");
            });

            modelBuilder.Entity<BranchInfo>(entity =>
            {
                entity.HasKey(e => e.BranchId);

                entity.ToTable("branch_info");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.BAddress)
                    .HasColumnName("b_address")
                    .HasMaxLength(50);

                entity.Property(e => e.BranchName)
                    .HasColumnName("branch_name")
                    .HasMaxLength(50);

                entity.Property(e => e.DefaultCurrencyId)
                    .HasColumnName("Default_currency_ID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasColumnType("image");

                entity.Property(e => e.Msg1)
                    .HasColumnName("msg1")
                    .HasMaxLength(50);

                entity.Property(e => e.Msg2)
                    .HasColumnName("msg2")
                    .HasMaxLength(50);

                entity.Property(e => e.Msg3)
                    .HasColumnName("msg3")
                    .HasMaxLength(50);

                entity.Property(e => e.TelNum)
                    .HasColumnName("tel_num")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CasherInfo>(entity =>
            {
                entity.HasKey(e => e.OperId);

                entity.ToTable("CASHER_INFO");

                entity.Property(e => e.OperId).HasColumnName("OPER_ID");

                entity.Property(e => e.AddCus).HasColumnName("ADD_CUS");

                entity.Property(e => e.AddItem).HasColumnName("ADD_ITEM");

                entity.Property(e => e.AddSou).HasColumnName("ADD_SOU");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.AutoCloseSaleWindow)
                    .HasColumnName("auto_close_sale_window")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CanDisplayItemCost)
                    .HasColumnName("canDisplayItemCost")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CanEditItemCost)
                    .HasColumnName("canEditItemCost")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CanEditItemPrice)
                    .HasColumnName("canEditItemPrice")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CancleDis).HasColumnName("CANCLE_DIS");

                entity.Property(e => e.CashSale).HasColumnName("CASH_SALE");

                entity.Property(e => e.CasherLogfile)
                    .HasColumnName("Casher_logfile")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CasherReport)
                    .HasColumnName("casher_report")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CasherSetup).HasColumnName("Casher_setup");

                entity.Property(e => e.ChangeInvoiceDiscount)
                    .HasColumnName("change_invoice_discount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ClearInvoice).HasColumnName("CLEAR_INVOICE");

                entity.Property(e => e.Companys).HasColumnName("COMPANYS");

                entity.Property(e => e.Curancy).HasColumnName("CURANCY");

                entity.Property(e => e.CusAcc).HasColumnName("CUS_ACC");

                entity.Property(e => e.CusSale).HasColumnName("CUS_SALE");

                entity.Property(e => e.Customers).HasColumnName("CUSTOMERS");

                entity.Property(e => e.DelItem).HasColumnName("DEL_ITEM");

                entity.Property(e => e.Department).HasColumnName("DEPARTMENT");

                entity.Property(e => e.DisByAmount).HasColumnName("DIS_BY_AMOUNT");

                entity.Property(e => e.DisByPer).HasColumnName("DIS_BY_PER");

                entity.Property(e => e.ExitSale).HasColumnName("EXIT_SALE");

                entity.Property(e => e.Groups).HasColumnName("GROUPS");

                entity.Property(e => e.HoldInvoice).HasColumnName("HOLD_INVOICE");

                entity.Property(e => e.InvoiceNote).HasColumnName("INVOICE_NOTE");

                entity.Property(e => e.IsActiveAccount).HasDefaultValueSql("(0)");

                entity.Property(e => e.Items).HasColumnName("ITEMS");

                entity.Property(e => e.ListsRep).HasColumnName("LISTS_REP");

                entity.Property(e => e.Location).HasColumnName("LOCATION");

                entity.Property(e => e.MangRep).HasColumnName("MANG_REP");

                entity.Property(e => e.OpenDrawer).HasColumnName("OPEN_DRAWER");

                entity.Property(e => e.OperatorPhone).HasMaxLength(20);

                entity.Property(e => e.OtherSale).HasColumnName("OTHER_SALE");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(30);

                entity.Property(e => e.Payment).HasColumnName("PAYMENT");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");

                entity.Property(e => e.PriceLevel)
                    .HasColumnName("price_level")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PrintLable).HasColumnName("PRINT_LABLE");

                entity.Property(e => e.PrintLastInvoice)
                    .HasColumnName("print_last_invoice")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PrintNoPrint).HasColumnName("PRINT_NO_PRINT");

                entity.Property(e => e.PurchRep).HasColumnName("PURCH_REP");

                entity.Property(e => e.Purchers).HasColumnName("PURCHERS");

                entity.Property(e => e.PurchersReturn)
                    .HasColumnName("PURCHERS_return")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.RecallInvoice).HasColumnName("RECALL_INVOICE");

                entity.Property(e => e.Refund).HasColumnName("REFUND");

                entity.Property(e => e.RunBackoffice).HasColumnName("RUN_BACKOFFICE");

                entity.Property(e => e.SaleRep).HasColumnName("SALE_REP");

                entity.Property(e => e.SaleReport)
                    .HasColumnName("sale_report")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sales).HasColumnName("SALES");

                entity.Property(e => e.ShowItemCost).HasDefaultValueSql("(0)");

                entity.Property(e => e.SouAcc).HasColumnName("SOU_ACC");

                entity.Property(e => e.Sources).HasColumnName("SOURCES");

                entity.Property(e => e.Spends).HasColumnName("SPENDS");

                entity.Property(e => e.StatRep).HasColumnName("STAT_REP");

                entity.Property(e => e.Types).HasColumnName("TYPES");

                entity.Property(e => e.Units).HasColumnName("UNITS");

                entity.Property(e => e.UpdateCus).HasColumnName("UPDATE_CUS");

                entity.Property(e => e.UpdateExpir).HasColumnName("UPDATE_EXPIR");

                entity.Property(e => e.UpdateItem).HasColumnName("UPDATE_ITEM");

                entity.Property(e => e.UpdateMinMax).HasColumnName("UPDATE_MIN_MAX");

                entity.Property(e => e.UpdatePrice).HasColumnName("UPDATE_PRICE");

                entity.Property(e => e.UpdateSou).HasColumnName("UPDATE_SOU");

                entity.Property(e => e.UpdateStock).HasColumnName("UPDATE_STOCK");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasMaxLength(30);

                entity.Property(e => e.UserState).HasColumnName("USER_STATE");

                entity.Property(e => e.UsersGroupIdFk)
                    .HasColumnName("UsersGroupID_FK")
                    .HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<CasherLogfile>(entity =>
            {
                entity.HasKey(e => e.LoginoutId);

                entity.ToTable("CASHER_LOGFILE");

                entity.Property(e => e.LoginoutId).HasColumnName("LOGINOUT_ID");

                entity.Property(e => e.LoginDate)
                    .HasColumnName("login_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogoutDate)
                    .HasColumnName("logout_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModelId)
                    .HasColumnName("MODEL_ID")
                    .HasDefaultValueSql("(2)");

                entity.Property(e => e.ModleId).HasColumnName("MODLE_ID");

                entity.Property(e => e.OperId).HasColumnName("OPER_ID");
            });

            modelBuilder.Entity<CompanyInfo>(entity =>
            {
                entity.HasKey(e => e.CompId);

                entity.ToTable("COMPANY_INFO");

                entity.Property(e => e.CompId).HasColumnName("COMP_ID");

                entity.Property(e => e.CompDes)
                    .HasColumnName("COMP_DES")
                    .HasMaxLength(35);
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasKey(e => e.Workstation);

                entity.ToTable("configuration");

                entity.Property(e => e.Workstation).HasColumnName("workstation");

                entity.Property(e => e.Ask).HasColumnName("ask");

                entity.Property(e => e.Askmin).HasColumnName("askmin");

                entity.Property(e => e.Backupdrive)
                    .HasColumnName("backupdrive")
                    .HasMaxLength(5);

                entity.Property(e => e.BranchCostExportedFiled).HasDefaultValueSql("(0)");

                entity.Property(e => e.BranchPrice1ExportedFiled).HasDefaultValueSql("(1)");

                entity.Property(e => e.BranchPrice2ExportedFiled).HasDefaultValueSql("(2)");

                entity.Property(e => e.BranchPrice3ExportedFiled).HasDefaultValueSql("(3)");

                entity.Property(e => e.BranchPrice4ExportedFiled).HasDefaultValueSql("(4)");

                entity.Property(e => e.CashCustomerName)
                    .HasColumnName("cash_customer_name")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ConfirmSoldItemUnit).HasDefaultValueSql("(0)");

                entity.Property(e => e.ConfirmSoldItemUnitMethod).HasDefaultValueSql("(1)");

                entity.Property(e => e.Copys).HasColumnName("copys");

                entity.Property(e => e.DefultCashCustomerCaption)
                    .IsRequired()
                    .HasColumnName("defult_cash_customer_caption")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('بيع نقدي')");

                entity.Property(e => e.ExpirDateFormat)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('yyyy/MM')");

                entity.Property(e => e.Expirremdays).HasColumnName("expirremdays");

                entity.Property(e => e.HoldOption).HasColumnName("hold_option");

                entity.Property(e => e.HoldTimes).HasColumnName("hold_times");

                entity.Property(e => e.InvoiceItemGrouping)
                    .HasColumnName("invoice_item_grouping")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ItemNameAlignment).HasDefaultValueSql("(0)");

                entity.Property(e => e.Minstock).HasColumnName("minstock");

                entity.Property(e => e.Price1Caption)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('السعر الافتراضي')");

                entity.Property(e => e.Price2Caption)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('السعر الثاني')");

                entity.Property(e => e.Price3Caption)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('السعر الثالث')");

                entity.Property(e => e.Price4Caption)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('السعر الرابع')");

                entity.Property(e => e.PrintCustomerNameLabel).HasDefaultValueSql("(0)");

                entity.Property(e => e.PrintDrugUsageLabel).HasDefaultValueSql("(0)");

                entity.Property(e => e.Printdevice).HasColumnName("printdevice");

                entity.Property(e => e.Printinvoice).HasColumnName("printinvoice");

                entity.Property(e => e.PurchItemCode)
                    .HasColumnName("purch_item_code")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RequestCustomerIdcardNumber)
                    .HasColumnName("RequestCustomerIDCardNumber")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RequestQytwhenselectItem).HasDefaultValueSql("(0)");

                entity.Property(e => e.ScaleBarcodeHeader)
                    .HasColumnName("Scale_BarcodeHeader")
                    .HasDefaultValueSql("(20)");

                entity.Property(e => e.ScaleBarcodedigits)
                    .HasColumnName("Scale_Barcodedigits")
                    .HasDefaultValueSql("(13)");

                entity.Property(e => e.ScaleDataBarcodeStartAtPostion)
                    .HasColumnName("Scale_DataBarcodeStartAtPostion")
                    .HasDefaultValueSql("(9)");

                entity.Property(e => e.ScaleDataBarcodedigits)
                    .HasColumnName("Scale_dataBarcodedigits")
                    .HasDefaultValueSql("(4)");

                entity.Property(e => e.ScaleDataType)
                    .IsRequired()
                    .HasColumnName("Scale_DataType")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('WEIGHT')");

                entity.Property(e => e.ScaleItemBarcodeDigits)
                    .HasColumnName("Scale_ItemBarcodeDigits")
                    .HasDefaultValueSql("(6)");

                entity.Property(e => e.ScaleItemBarcodeStartAtPostion)
                    .HasColumnName("Scale_ItemBarcodeStartAtPostion")
                    .HasDefaultValueSql("(3)");

                entity.Property(e => e.ShowDrugUsageGuide).HasDefaultValueSql("(0)");

                entity.Property(e => e.SupportExpirDate)
                    .HasColumnName("support_expir_date")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UseBalanceBarcode).HasColumnName("USE_BALANCE_BARCODE");
            });

            modelBuilder.Entity<CurrencyInfo>(entity =>
            {
                entity.HasKey(e => e.CurId);

                entity.ToTable("CURRENCY_INFO");

                entity.Property(e => e.CurId).HasColumnName("CUR_ID");

                entity.Property(e => e.CurDes)
                    .HasColumnName("CUR_DES")
                    .HasMaxLength(15);

                entity.Property(e => e.DecNum).HasColumnName("dec_num");

                entity.Property(e => e.Rate).HasColumnName("RATE");

                entity.Property(e => e.Symbol)
                    .HasColumnName("symbol")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<CusCompanyInfo>(entity =>
            {
                entity.HasKey(e => e.CusCompanyId);

                entity.ToTable("CusCompany_info");

                entity.Property(e => e.CusCompanyId).HasColumnName("CusCompany_id");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("Company_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactName)
                    .HasColumnName("Contact_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Telphone).HasMaxLength(20);
            });

            modelBuilder.Entity<CusCreditDebit>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.ToTable("cus_credit_debit");

                entity.Property(e => e.RecId).HasColumnName("rec_id");

                entity.Property(e => e.AmountType).HasColumnName("amount_type");

                entity.Property(e => e.AmountVal)
                    .HasColumnName("amount_val")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CreditAmount)
                    .HasColumnName("credit_amount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CusId).HasColumnName("CUS_ID");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DebitAmount)
                    .HasColumnName("debit_amount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.InvoiceId).HasColumnName("INVOICE_ID");

                entity.Property(e => e.OperId)
                    .HasColumnName("oper_id")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SalesmanId)
                    .HasColumnName("SALESMAN_ID")
                    .HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<CusgroupInfo>(entity =>
            {
                entity.HasKey(e => e.CusgroupId);

                entity.ToTable("cusgroup_info");

                entity.Property(e => e.CusgroupId)
                    .HasColumnName("cusgroup_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CusgroupName)
                    .IsRequired()
                    .HasColumnName("cusgroup_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CusReceipts>(entity =>
            {
                entity.HasKey(e => e.ReceiptId);

                entity.ToTable("cus_receipts");

                entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CusId).HasColumnName("cus_id");

                entity.Property(e => e.Note)
                    .HasColumnName("NOTE")
                    .HasMaxLength(150);

                entity.Property(e => e.OperId).HasColumnName("oper_id");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnName("receipt_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SalesmanId)
                    .HasColumnName("SALESMAN_ID")
                    .HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CusId);

                entity.ToTable("customers");

                entity.Property(e => e.CusId).HasColumnName("CUS_ID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50);

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.CloseAccDate)
                    .HasColumnName("close_acc_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Company)
                    .HasColumnName("COMPANY")
                    .HasMaxLength(30);

                entity.Property(e => e.CreditLimet).HasColumnName("credit_limet");

                entity.Property(e => e.CusCompanyId)
                    .HasColumnName("CusCompany_id")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CusName)
                    .HasColumnName("CUS_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.CusgroupId)
                    .HasColumnName("cusgroup_id")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DisType).HasColumnName("dis_type");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.DurTime).HasColumnName("dur_time");

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.IdCard)
                    .HasColumnName("ID_card")
                    .HasMaxLength(30);

                entity.Property(e => e.InvoiceAvr).HasColumnName("invoice_avr");

                entity.Property(e => e.LastSalDate)
                    .HasColumnName("last_sal_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpenAccDate)
                    .HasColumnName("open_acc_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpenValue).HasColumnName("open_value");

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(20);

                entity.Property(e => e.RetUnit).HasColumnName("ret_unit");

                entity.Property(e => e.SalePrice).HasColumnName("sale_price");

                entity.Property(e => e.SalesmanId)
                    .HasColumnName("SALESMAN_ID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TotalRet).HasColumnName("total_ret");

                entity.Property(e => e.TotalSale).HasColumnName("total_sale");

                entity.Property(e => e.TotalSaving).HasColumnName("total_saving");

                entity.Property(e => e.TotalUnit).HasColumnName("total_unit");

                entity.Property(e => e.TotalVisits).HasColumnName("total_visits");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.ToTable("departments");

                entity.Property(e => e.DepId).HasColumnName("dep_id");

                entity.Property(e => e.DepDesc)
                    .HasColumnName("dep_desc")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ExpiredItems>(entity =>
            {
                entity.ToTable("Expired_items");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CasherId).HasColumnName("casher_id");

                entity.Property(e => e.Cost).HasColumnName("COST");

                entity.Property(e => e.ExDate)
                    .HasColumnName("ex_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Qyt).HasColumnName("qyt");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("GROUPS");

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.GroupDes)
                    .HasColumnName("GROUP_DES")
                    .HasMaxLength(30);

                entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");
            });

            modelBuilder.Entity<HoldDetails>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.ToTable("hold_details");

                entity.Property(e => e.RecId).HasColumnName("rec_id");

                entity.Property(e => e.Cost).HasColumnName("COST");

                entity.Property(e => e.ExDateF).HasColumnName("ex_date_f");

                entity.Property(e => e.HoldId).HasColumnName("hold_id");

                entity.Property(e => e.InvUnitId).HasDefaultValueSql("(0)");

                entity.Property(e => e.InvUnitName)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("item_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ItemNote)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemPrice).HasColumnName("item_price");

                entity.Property(e => e.ItemType).HasColumnName("item_type");

                entity.Property(e => e.Opf)
                    .HasColumnName("OPF")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PackagePrice)
                    .HasColumnName("package_price")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PackageQyt).HasColumnName("package_qyt");

                entity.Property(e => e.PackageUnitId)
                    .HasColumnName("package_unit_ID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PackageUnitName)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Price2).HasColumnName("price2");

                entity.Property(e => e.Price3).HasColumnName("price3");

                entity.Property(e => e.Price4).HasColumnName("price4");

                entity.Property(e => e.Qyt).HasColumnName("qyt");

                entity.Property(e => e.SalePrice).HasColumnName("sale_price");

                entity.Property(e => e.SaledUnitIdF).HasDefaultValueSql("(1)");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<HoldInvoice>(entity =>
            {
                entity.HasKey(e => e.HoldId);

                entity.ToTable("hold_invoice");

                entity.Property(e => e.HoldId).HasColumnName("hold_id");

                entity.Property(e => e.BranchId).HasColumnName("BRANCH_ID");

                entity.Property(e => e.CusId).HasColumnName("cus_id");

                entity.Property(e => e.CusName)
                    .IsRequired()
                    .HasColumnName("cus_name")
                    .HasMaxLength(50);

                entity.Property(e => e.HoldTime)
                    .HasColumnName("hold_time")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.InvoiceDis).HasColumnName("invoice_dis");

                entity.Property(e => e.InvoiceTotal).HasColumnName("invoice_total");

                entity.Property(e => e.OperId).HasColumnName("oper_id");

                entity.Property(e => e.PriceLevel).HasColumnName("price_level");

                entity.Property(e => e.Ws).HasColumnName("WS");
            });

            modelBuilder.Entity<InvoiceTypes>(entity =>
            {
                entity.HasKey(e => e.InvoiceTypeId);

                entity.ToTable("invoice_types");

                entity.Property(e => e.InvoiceTypeId)
                    .HasColumnName("invoice_type_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DocDes)
                    .IsRequired()
                    .HasColumnName("doc_des")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ItemPrices>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.PaymentId });

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.State).HasColumnName("state");
            });

            modelBuilder.Entity<ItemsExpDate>(entity =>
            {
                entity.ToTable("ITEMS_EXP_DATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchSt).HasColumnName("BATCH_ST");

                entity.Property(e => e.ExpDate)
                    .HasColumnName("EXP_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.Qyt).HasColumnName("QYT");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("ITEM_TYPE");

                entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");

                entity.Property(e => e.TypeDes)
                    .HasColumnName("TYPE_DES")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocId);

                entity.ToTable("location");

                entity.Property(e => e.LocId).HasColumnName("LOC_ID");

                entity.Property(e => e.LocDes)
                    .HasColumnName("LOC_DES")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Master>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("master");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.Barcode3)
                    .HasColumnName("barcode3")
                    .HasMaxLength(30);

                entity.Property(e => e.Barcode4)
                    .HasColumnName("barcode4")
                    .HasMaxLength(30);

                entity.Property(e => e.Codebar)
                    .HasColumnName("codebar")
                    .HasMaxLength(30);

                entity.Property(e => e.CompId).HasColumnName("COMP_ID");

                entity.Property(e => e.ConfirmSoldItemUnit).HasDefaultValueSql("(0)");

                entity.Property(e => e.Cost).HasColumnName("COST");

                entity.Property(e => e.DepId).HasColumnName("DEP_ID");

                entity.Property(e => e.Discount).HasDefaultValueSql("((0))");

                entity.Property(e => e.EnNum)
                    .HasColumnName("en_num")
                    .HasMaxLength(30);

                entity.Property(e => e.ExDateF).HasColumnName("ex_date_f");

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.InStock).HasColumnName("in_stock");

                entity.Property(e => e.ItemName)
                    .HasColumnName("item_name")
                    .HasMaxLength(75);

                entity.Property(e => e.ItemName2)
                    .HasColumnName("item_name2")
                    .HasMaxLength(75);

                entity.Property(e => e.ItemPrice).HasColumnName("item_price");

                entity.Property(e => e.ItemType).HasColumnName("ITEM_TYPE");

                entity.Property(e => e.LastCost).HasColumnName("LAST_COST");

                entity.Property(e => e.LastQytadjdate)
                    .HasColumnName("lastQytadjdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastReceivedDate)
                    .HasColumnName("last_received_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastSoldDate)
                    .HasColumnName("last_sold_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LocId).HasColumnName("LOC_ID");

                entity.Property(e => e.LowAmount).HasColumnName("low_amount");

                entity.Property(e => e.ManfId)
                    .HasColumnName("MANF_ID")
                    .HasMaxLength(30);

                entity.Property(e => e.Margin).HasColumnName("MARGIN");

                entity.Property(e => e.Markdowp2).HasColumnName("MARKDOWP2");

                entity.Property(e => e.Markdowp3).HasColumnName("MARKDOWP3");

                entity.Property(e => e.Markdowp4).HasColumnName("MARKDOWP4");

                entity.Property(e => e.OpenPriceF)
                    .HasColumnName("OPEN_PRICE_F")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PackageBarcode)
                    .HasColumnName("package_Barcode")
                    .HasMaxLength(30);

                entity.Property(e => e.PackagePrice).HasColumnName("package_price");

                entity.Property(e => e.PackagePrice2).HasColumnName("package_price2");

                entity.Property(e => e.PackagePrice3).HasColumnName("package_price3");

                entity.Property(e => e.PackagePrice4).HasColumnName("package_price4");

                entity.Property(e => e.PackageQyt)
                    .HasColumnName("package_qyt")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PackageUnitId).HasColumnName("package_unit_ID");

                entity.Property(e => e.PicId).HasColumnName("PIC_ID");

                entity.Property(e => e.Price2).HasColumnName("PRICE2");

                entity.Property(e => e.Price3).HasColumnName("PRICE3");

                entity.Property(e => e.Price4).HasColumnName("PRICE4");

                entity.Property(e => e.Rslevel).HasColumnName("RSLEVEL");

                entity.Property(e => e.Secbarcode)
                    .HasColumnName("secbarcode")
                    .HasMaxLength(30);

                entity.Property(e => e.SnF)
                    .HasColumnName("sn_f")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Soldqyt).HasColumnName("soldqyt");

                entity.Property(e => e.StopSaleF)
                    .HasColumnName("stop_sale_f")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SysBarcode).HasColumnName("sys_barcode");

                entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");

                entity.Property(e => e.UnitId).HasColumnName("UNIT_ID");
            });

            modelBuilder.Entity<PaymentInfo>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("payment_info");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.CurrId).HasColumnName("curr_id");

                entity.Property(e => e.PaymentDes)
                    .HasColumnName("payment_des")
                    .HasMaxLength(20);

                entity.Property(e => e.PaymentType).HasColumnName("payment_type");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<PdtFiles>(entity =>
            {
                entity.ToTable("PDT_FILES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasColumnName("BARCODE")
                    .HasMaxLength(50);

                entity.Property(e => e.Qyt).HasColumnName("QYT");
            });

            modelBuilder.Entity<PerformaInvoices>(entity =>
            {
                entity.HasKey(e => e.Pinvoiceid);

                entity.ToTable("PERFORMA_INVOICES");

                entity.Property(e => e.Pinvoiceid).HasColumnName("pinvoiceid");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CusId).HasColumnName("cus_ID");

                entity.Property(e => e.DisTotal).HasColumnName("dis_total");

                entity.Property(e => e.Invoicedate)
                    .HasColumnName("invoicedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Invoiceid).HasColumnName("invoiceid");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.Property(e => e.NetTotal).HasColumnName("net_total");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.SubTotal).HasColumnName("sub_total");

                entity.Property(e => e.TaxTotal).HasColumnName("tax_total");
            });

            modelBuilder.Entity<PerformaInvoicesDetails>(entity =>
            {
                entity.HasKey(e => e.DetailsId);

                entity.ToTable("PERFORMA_INVOICES_DETAILS");

                entity.Property(e => e.DetailsId).HasColumnName("details_id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.DiscountValue)
                    .HasColumnName("discountValue")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.EpxDate)
                    .HasColumnName("EPX_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.NetTotal).HasColumnName("netTotal");

                entity.Property(e => e.Pinvoiceid).HasColumnName("pinvoiceid");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Qyt).HasColumnName("QYT");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unit_id")
                    .HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<PurchasesInvoices>(entity =>
            {
                entity.HasKey(e => e.Invoiceid);

                entity.ToTable("purchases_invoices");

                entity.Property(e => e.Invoiceid).HasColumnName("invoiceid");

                entity.Property(e => e.BranchId)
                    .HasColumnName("branch_id")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DisTotal).HasColumnName("dis_total");

                entity.Property(e => e.InvoiceTypeId).HasColumnName("INVOICE_TYPE_ID");

                entity.Property(e => e.Invoicedate)
                    .HasColumnName("invoicedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Invoicenum)
                    .HasColumnName("invoicenum")
                    .HasMaxLength(20);

                entity.Property(e => e.Invoicetime)
                    .HasColumnName("invoicetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.NetTotal).HasColumnName("net_total");

                entity.Property(e => e.OtherFee).HasColumnName("other_fee");

                entity.Property(e => e.PaymentId).HasColumnName("PAYMENT_ID");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.SourId).HasColumnName("SOUR_ID");

                entity.Property(e => e.SubTotal).HasColumnName("sub_total");

                entity.Property(e => e.SystemNum)
                    .HasColumnName("system_num")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TaxTotal).HasColumnName("tax_total");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<PurchasesInvoicesDetails>(entity =>
            {
                entity.HasKey(e => e.DetailsId);

                entity.ToTable("purchases_invoices_details");

                entity.Property(e => e.DetailsId).HasColumnName("details_id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.EpxDate)
                    .HasColumnName("EPX_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Invoiceid).HasColumnName("invoiceid");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.NewPrice)
                    .HasColumnName("new_price")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Qyt).HasColumnName("QYT");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<RefUsersGroups>(entity =>
            {
                entity.HasKey(e => e.UsersGroupIdPk);

                entity.Property(e => e.UsersGroupIdPk).HasColumnName("UsersGroupID_PK");

                entity.Property(e => e.UsersGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.ToTable("sales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("COST");

                entity.Property(e => e.DisAmount).HasColumnName("dis_amount");

                entity.Property(e => e.ExpDate)
                    .HasColumnName("EXP_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceId).HasColumnName("INVOICE_ID");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Qyt).HasColumnName("QYT");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UnitId).HasColumnName("UNIT_ID");
            });

            modelBuilder.Entity<SalesItemsNotes>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.ToTable("sales_items_notes");

                entity.Property(e => e.RecId).HasColumnName("rec_id");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.ItemNote)
                    .IsRequired()
                    .HasColumnName("item_note")
                    .HasMaxLength(150);

                entity.Property(e => e.SaleRecId).HasColumnName("sale_rec_id");
            });

            modelBuilder.Entity<SalesmanInfo>(entity =>
            {
                entity.HasKey(e => e.SalesmanId);

                entity.ToTable("salesman_info");

                entity.Property(e => e.SalesmanId)
                    .HasColumnName("salesman_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SalesmanName)
                    .HasColumnName("salesman_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ScreenInfo>(entity =>
            {
                entity.ToTable("screen_info");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BackcolorId).HasColumnName("BACKCOLOR_ID");

                entity.Property(e => e.ButtonId).HasColumnName("BUTTON_ID");

                entity.Property(e => e.ItemDesc)
                    .HasColumnName("ITEM_DESC")
                    .HasMaxLength(50);

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.PageId).HasColumnName("PAGE_ID");
            });

            modelBuilder.Entity<SoldItemsSn>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.ToTable("SOLD_ITEMS_SN");

                entity.Property(e => e.RecId)
                    .HasColumnName("REC_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.InvoiceId).HasColumnName("INVOICE_ID");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.Sn)
                    .HasColumnName("SN")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<SourceCreditDebit>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.ToTable("source_credit_debit");

                entity.Property(e => e.RecId).HasColumnName("rec_id");

                entity.Property(e => e.AmountType).HasColumnName("amount_type");

                entity.Property(e => e.AmountVal)
                    .HasColumnName("amount_val")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CreditAmount)
                    .HasColumnName("credit_amount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DebitAmount)
                    .HasColumnName("debit_amount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Invoiceid).HasColumnName("INVOICEID");

                entity.Property(e => e.OperId)
                    .HasColumnName("oper_id")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SourId).HasColumnName("sour_ID");
            });

            modelBuilder.Entity<SourceReceipts>(entity =>
            {
                entity.HasKey(e => e.ReceiptId);

                entity.ToTable("source_receipts");

                entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Note)
                    .HasColumnName("NOTE")
                    .HasMaxLength(50);

                entity.Property(e => e.OperId).HasColumnName("oper_id");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnName("receipt_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceId).HasColumnName("source_id");
            });

            modelBuilder.Entity<Sources>(entity =>
            {
                entity.HasKey(e => e.SourId);

                entity.ToTable("sources");

                entity.Property(e => e.SourId).HasColumnName("SOUR_ID");

                entity.Property(e => e.Address1)
                    .HasColumnName("ADDRESS1")
                    .HasMaxLength(50);

                entity.Property(e => e.Address2)
                    .HasColumnName("ADDRESS2")
                    .HasMaxLength(50);

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Company)
                    .HasColumnName("COMPANY")
                    .HasMaxLength(50);

                entity.Property(e => e.CurId).HasColumnName("CUR_ID");

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.OpenValue).HasColumnName("OPEN_VALUE");

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(35);

                entity.Property(e => e.SourName)
                    .HasColumnName("sour_NAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Spend>(entity =>
            {
                entity.ToTable("SPEND");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(75);

                entity.Property(e => e.Regdate)
                    .HasColumnName("regdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SetCode).HasColumnName("set_code");

                entity.Property(e => e.SpendName)
                    .HasColumnName("spend_name")
                    .HasMaxLength(50);

                entity.Property(e => e.SpendPrice).HasColumnName("spend_price");

                entity.Property(e => e.SpendingDate)
                    .HasColumnName("spending_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Weekday)
                    .HasColumnName("weekday")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<SpendSets>(entity =>
            {
                entity.HasKey(e => e.SetCode);

                entity.ToTable("spend_sets");

                entity.Property(e => e.SetCode).HasColumnName("set_code");

                entity.Property(e => e.SetName)
                    .HasColumnName("set_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StockMovement>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.ToTable("STOCK_MOVEMENT");

                entity.Property(e => e.RecId).HasColumnName("REC_ID");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.OpDate)
                    .HasColumnName("OP_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OperId).HasColumnName("OPER_ID");

                entity.Property(e => e.Qyt).HasColumnName("QYT");

                entity.Property(e => e.SourceType).HasColumnName("SOURCE_TYPE");
            });

            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.ToTable("tickets");

                entity.Property(e => e.InvoiceId).HasColumnName("INVOICE_ID");

                entity.Property(e => e.BranchId).HasColumnName("BRANCH_ID");

                entity.Property(e => e.Caption)
                    .HasColumnName("caption")
                    .HasMaxLength(75);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CusId).HasColumnName("CUS_ID");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(convert(varchar(10),getdate(),101))");

                entity.Property(e => e.Dis).HasColumnName("DIS");

                entity.Property(e => e.InvoiceTypeId).HasColumnName("invoice_type_id");

                entity.Property(e => e.ModelId)
                    .HasColumnName("model_id")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.ModleId)
                    .HasColumnName("modle_id")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(75);

                entity.Property(e => e.OperId).HasColumnName("OPER_ID");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.Posted)
                    .HasColumnName("posted")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.SalesmanId)
                    .HasColumnName("SALESMAN_ID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.StateId)
                    .HasColumnName("state_id")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(convert(varchar(8),getdate(),108))");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Ws)
                    .HasColumnName("ws")
                    .HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<TransTypes>(entity =>
            {
                entity.HasKey(e => e.SourceTypeId);

                entity.ToTable("TRANS_TYPES");

                entity.Property(e => e.SourceTypeId).HasColumnName("source_type_id");

                entity.Property(e => e.SourceTypeDes)
                    .IsRequired()
                    .HasColumnName("source_type_des")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("types");

                entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");

                entity.Property(e => e.DepId).HasColumnName("DEP_ID");

                entity.Property(e => e.TypeDesc)
                    .HasColumnName("type_desc")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.ToTable("units");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.UnitDes)
                    .HasColumnName("unit_des")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Workstations>(entity =>
            {
                entity.HasKey(e => e.WsId);

                entity.ToTable("workstations");

                entity.Property(e => e.WsId)
                    .HasColumnName("ws_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BarcodeFontName)
                    .HasColumnName("barcode_font_name")
                    .HasMaxLength(30);

                entity.Property(e => e.BarcodePrinter)
                    .HasColumnName("barcode_printer")
                    .HasMaxLength(150);

                entity.Property(e => e.BarcodeRPort).HasColumnName("barcode_r_port");

                entity.Property(e => e.DefultPage)
                    .HasColumnName("defult_page")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.DisplayPort).HasColumnName("display_port");

                entity.Property(e => e.DisplayType)
                    .HasColumnName("display_type")
                    .HasMaxLength(50);

                entity.Property(e => e.DrawerPort).HasColumnName("drawer_port");

                entity.Property(e => e.DrawerPrinter)
                    .HasColumnName("drawer_printer")
                    .HasMaxLength(150);

                entity.Property(e => e.EFlineData).HasColumnName("e_fline_data");

                entity.Property(e => e.ESlineData).HasColumnName("e_sline_data");

                entity.Property(e => e.FlineData).HasColumnName("fline_data");

                entity.Property(e => e.FlineString)
                    .HasColumnName("fline_string")
                    .HasMaxLength(20);

                entity.Property(e => e.InvoicePrinter)
                    .HasColumnName("invoice_printer")
                    .HasMaxLength(150);

                entity.Property(e => e.PrintReceipt).HasColumnName("print_receipt");

                entity.Property(e => e.PrinterType)
                    .HasColumnName("printer_type")
                    .HasMaxLength(30);

                entity.Property(e => e.ReceiptPrinter)
                    .HasColumnName("Receipt_printer")
                    .HasMaxLength(150);

                entity.Property(e => e.ReportPrinter)
                    .HasColumnName("report_printer")
                    .HasMaxLength(150);

                entity.Property(e => e.SlineData).HasColumnName("sline_data");

                entity.Property(e => e.SlineString)
                    .HasColumnName("sline_string")
                    .HasMaxLength(20);
            });
        }
    }
}
