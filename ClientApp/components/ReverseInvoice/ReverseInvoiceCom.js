export default {
  computed: {
    total: function () {
      var t = 0 
      for (var i = 0; i < this.sales.length; i++)
      {
        t = t + (this.sales[i].price - this.sales[i].disAmount) * this.sales[i].qyt
      }
      return t 
    },
      totalreturn: function () {
      var t = 0
      for (var i = 0; i < this.sales.length; i++) {
        t = t + (this.sales[i].price - this.sales[i].disAmount) * this.sales[i].ruturnQuantity
       
      }
      return t
      },
       totalPages: function () {
         return Math.ceil(this.totals / this.pageSize)
    },
  },
   directives: { focus: focus }
  , watch:
  {
    cusName: function () {

          this.SearshCostomer()
    }
    , phone: function () {

      this.SearshCostomer()
    }
  }
  ,data() {

    return {
      focused: false,

      format: 'yyyy-MM-dd hh:mm:ss ',
      type: 'fmt',
      autoUpdate: false,

      sales: [],
    
      name:'',

      payments: [],
      payment: 0,
      show: false,
      message: 'الرجاء الأنتظار',
      showblock: false,
      error:'خطأ!',
      date: null,
      newticket:false,
      ticket: {
        InvoiceId: 0, CusId: 0, Date: '', Time: '', Total: '', Dis: 0,
        OperId: 0, Caption: '', PaymentId: 0, invoiceTypeId: 0, BranchId: 0,
        SalesmanId: 0, Ws: 0, ModleId: 0, StateId:0, ModelId:0, Note: '', Posted: false, CreatedDate:''
      },
      customers: [],
      showkeyboard: true,
      cusId: 0, phone: '', company: '', cusName: '',
      btncusname: "تغيير",
  
      tickets:[],
      invoiceId:0
    }
  },

  methods: {
   
 
      SetKeyboard(val)
      {
        if (val == 'clear') {
          if (this.focused == 'name')
            this.cusName = ''

          else if ((this.focused == 'phone'))
            this.phone =''

          else if ((this.focused == 'company'))
            this.ticket.note = ''
             
              return;
          }
        if (val == 'delete') {
          if (this.focused == 'name')
            this.cusName = this.cusName.slice(0, this.cusName.length - 1);

          else if ((this.focused == 'phone'))
            this.phone = this.phone.slice(0, this.phone.length - 1);

          else if ((this.focused == 'company'))
            this.ticket.note = this.ticket.note.slice(0, this.ticket.note.length - 1);


              return;
        }

      
        if (this.focused == 'name')
              this.cusName = this.cusName + val

        else if ((this.focused == 'phone'))
          this.phone = this.phone + val

        else if ((this.focused == 'company'))
          this.ticket.note = this.ticket.note + val
   
    },

    SetNumbers(val) {
      if (val == 'clear') {
       
        this.invoiceId = 0
          ; return;
      }
      if (val == 'delete') {
        this.invoiceId = this.invoiceId.slice(0, this.invoiceId.length - 1);
        return;
       }


      this.invoiceId = this.invoiceId + val
     

        },

    //-----------------------------------------------------------------
    GetPayments() {
      try {
        this.showblock = true;
        let response =  this.$http.get(`/api/payment/GetActivePayments`).then(response => {
          this.showblock = false;

          if (response.data.errorCode == 0) {
            this.payments = response.data.payments
          }
          else
          {
            this.error = response.data.errorCode + '' + response.data.message
            this.showModal()
          }
        }).catch((error) => console.log(error))

        } catch (err) {
          window.alert(err)
          console.log(err)
        }
    },
    GetCustomers() {
      try {
        this.showblock = true;
        let response = this.$http.get(`/api/customers/GetActiveCustomersTop`).then(response => {
          this.showblock = false;

          if (response.data.errorCode == 0) {
            this.customers = response.data.customers
          }
          else {
            this.error = response.data.errorCode + '' + response.data.message
            this.showModal()
          }
        }).catch((error) => console.log(error))

      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    },
    SelectCustomer(customer) {
      this.cusName = customer.cusName
      this.phone = customer.phone
      this.company = customer.company
      this.cusId = customer.cusId

      this.showkeyboard= false
    },
    SearshCostomer()
    {
        try {
            console.log('ffff')

            this.message = "جاري  البحت"
            this.showblock = true
            this.$http.get(`/api/customers/SearshCostomer?name=${this.cusName}&comid=${this.company}&phone=${this.phone}`)
                .then(response => {
                    this.showblock = false;


                    if (response.data.errorCode == 0) {
                      this.customers = response.data.customers
                       

                    }
                    else {
                        window.alert(response.data.Message)
                        console.log(response)
                    }

                })
                .catch((error) => console.log(error))



        } catch (err) {
            window.alert(err)
            console.log(err)
        }
    },
    AddCustomer() {
      if (this.cusName.length < 4) {
        alert('الاسم قصير'); return
      }
      if (this.phone.length < 10) {
        alert('الرقم غير صحيح'); return;
      }
      try {

        this.showblock = true
        this.$http.post('/api/customers/AddCustomer', {  phone: this.phone, company: this.company, cusName: this.cusName, }).then(response => {
          this.showblock = false

          if (response.data.errorCode == 0) {
            this.SearshCostomer()
          }
          else {
          this.error = response.data.message
            this.showModal()
          }



        })
          .catch((error) => console.log(error))

      } catch (err) {
        window.alert('err' + err)
        return

      }


    },
    //--------------------------------------------------------------------------------------------------------
    showModal() {
      this.$refs.myModalRef.show()
    },
    hideModal() {
      this.$refs.myModalRef.hide()
    },
    formatPrice(value) {
      let val = (value / 1).toFixed(2)

      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")
    },
    //-----------------------------------------------------------------------------------------------------------
    OpenExistTicket() {
      try {
        this.showblock = true;
        let response = this.$http.get(`/api/pos/OpenExistTicket?InvoiceId=${this.invoiceId}`).then(response => {
          this.showblock = false;

          if (response.data.errorCode == 0) {
            this.ticket = response.data.ticket
            this.payment = this.ticket.paymentId
            this.GetSalesById()
            this.date = this.ticket.createdDate
            if (!this.ticket.note)
             this.ticket.note = ''
          }
          else {

            this.ticket = {
              InvoiceId: 0, CusId: 0, Date: '', Time: '', Total: '', Dis: 0,
              OperId: 0, Caption: '', PaymentId: 0, InvoiceTypeId: 0, BranchId: 0,
              SalesmanId: 0, Ws: 0, ModleId: 0, StateId: 0, ModelId: 0, Note: '', Posted: false, CreatedDate: ''
            }
            this.sales = []
            this.error = response.data.errorCode + '' + response.data.message
            this.showModal()
          }
        }).catch((error) => console.log(error))

      } catch (err) {
        window.alert(err)
        console.log(err)
      }

    },
    handleOk(evt) {
      // Prevent modal from closing
      evt.preventDefault()
      if (this.cusId < 0) {

      } else {
        this.submitRuturn()
      }
    },
    submitRuturn() {
      try {
        console.log(this.sales)
        if (this.cusId < 1) {
          return
        }

        this.ticket.cusId = this.cusId

        this.showblock = true;
        this.$http.post('/api/pos/SubmitRuturn', { sales: this.sales, ticket: this.ticket }).then(response => {

          this.showblock = false;
          if (response.data.errorCode == 0) {
            this.newticket = false;
            this.cusId = -1
            this.cusName = ''
            this.company = ''
            this.phone=''
            this.ticket = {
              InvoiceId: 0, CusId: 0, Date: '', Time: '', Total: '', Dis: 0,
              OperId: 0, Caption: '', PaymentId: 0, InvoiceTypeId: 0, BranchId: 0,
              SalesmanId: 0, Ws: 0, ModleId: 0, StateId: 0, ModelId: 0, Note: '', Posted: false, CreatedDate: ''
            }
            this.sales = [];
            this.error = 'تمت معالجة الفاتورة بنجاح'
            this.showModal()
            this.tickets = []
            this.invoiceId=0
          }
          else {
            this.error = response.data.errorCode + '' + response.data.message
            this.showModal()
          }
        }).catch((error) => console.log(error))


      } catch (err) {
        window.alert('eroor=' + err)
        return

      }

    },
    GetSalesById() {
      try {
        var invoiceid = this.ticket.invoiceId

        this.showblock = true;
        let response = this.$http.get(`/api/pos/GetSalesById?InvoiceId=${invoiceid}`).then(response => {
          this.showblock = false;
          if (response.data.errorCode == 0) {
            this.sales = response.data.sales
            this.GetReversalTicktes()
          }
          else {
            this.error = response.data.errorCode + '' + response.data.message
            this.showModal()
          }

        }).catch((error) => console.log(error))

      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    },
    EditSaleQuantity(sale, type) {
      if (type === '+')
        sale.ruturnQuantity = sale.ruturnQuantity + 1
      else if (type === '-')
        sale.ruturnQuantity = sale.ruturnQuantity - 1
      if (sale.ruturnQuantity < 0)
        sale.ruturnQuantity = 0

      if (sale.ruturnQuantity > sale.qyt - sale.returenQantity)
        sale.ruturnQuantity = sale.qyt - sale.returenQantity

      if (sale.qyt === '' || sale.qyt === '0' || parseInt(sale.qyt) <= 0) {
        //this.error = 'يجب تحديد كمية'
        //this.GetSalesById()
        //this.showModal()
      }
      else {
        try {
          //this.showblock = true
          //this.$http.post('/api/pos/EditSaleQuantity', sale).then(response => {
          //  this.showblock = false

          //  if (response.data.errorCode == 0) {

          //    this.GetSalesById()
          //  }
          //  else {
          //    this.error = response.data.errorCode + '' + response.data.message
          //    this.GetSalesById()
          //    this.showModal()
          //  }
          //})
          //  .catch((error) => console.log(error))
        } catch (err) {
          window.alert('err' + err)
          return

        }


      }



    },
    GetReversalTicktes() {
      try {
 
        this.showblock = true;
        let response = this.$http.get(`/api/pos/GetReversalTicktes?InvoiceId=${this.ticket.invoiceId}`).then(response => {
          this.showblock = false;
          if (response.data.errorCode == 0) {
            this.tickets = response.data.tickets
            console.log(response.data.tickets)
          }
          else {
            this.error = response.data.errorCode + '' + response.data.message
            this.showModal()
          }

        }).catch((error) => console.log(error))

      } catch (err) {
        window.alert(err)
        console.log(err)
      }

    },
    
    OpenReverced(ticket) {
      this.invoiceId = ticket.invoiceId
      this.ticket = ticket
      this.tickets = [];
      this.tickets[0] = ticket
      this.OpenExistTicket()
    },
    //---------------------------------------------------------------------------------------------------------
  },
  async created() {
    this.GetPayments()
  
  }
}
