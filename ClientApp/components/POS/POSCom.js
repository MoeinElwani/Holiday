


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
      totaldiscount: function () {
      var t = 0
      for (var i = 0; i < this.sales.length; i++) {
        t = t +  this.sales[i].disAmount * this.sales[i].qyt
      }
      return t
    }
  }
  , watch:
  {
   
    payment: function () { this.ChangePayment() }
  }

  ,
  data() {

    return {
      sale: {
        id: 0,
        qyt: 0,
        cost: 0,
        price: 9,
        total: 0,
        invoiceId: 0,
        itemId: 0,
      },id:0,
      item: {
        id: 0,
        qyt: 0,
        cost: 0,
        price: 0,
        total: 0,
        invoiceId: 0,
        itemId: 0,
      },
      sales: [],

      name:'',

      payments: [],
      payment: 1,
      show: false,
      message: 'الرجاء الأنتظار',
      showblock: false,
      error:'خطأ!',
      date: new Date(),



      
      newticket:false,
      ticket: {
        InvoiceId: 0, CusId: 0, Date: '', Time: '', Total: '', Dis: 0,
        OperId: 0, Caption: '', PaymentId: 0, InvoiceTypeId: 0, BranchId: 0,
        SalesmanId: 0, Ws: 0, ModleId: 0, StateId:0, ModelId:0, Note: '', Posted: false, CreatedDate:''
      },
      tickets:[],

    }
  },

  methods: {
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
    ChangePayment()
    {
      if (this.sales.length <= 0)
        return

      this.ticket.PaymentId = this.payment
      try {
        this.showblock = true;
        this.$http.post('/api/pos/ChangePayment', this.ticket).then(response => {
          this.showblock = false;
          if (response.data.errorCode == 0)
          {
            this.GetSalesById()
          }
          else
          {
            this.error = response.data.errorCode + '' + response.data.message
            this.showModal()
          }
        })
          .catch((error) => console.log(error))


      } catch (err) {
        window.alert('eroor=' + err)
        return

      }

    },
 
    GetitemById()
    {
      var itemId = this.id
      try {
     
        this.showblock = true;
        let response = this.$http.get(`/api/items/GetitemById?itemId=${itemId}`).then(response => {
        this.showblock = false;
          if (response.data.errorCode == 0) {
            this.item = response.data.item
            this.AddItemToTicket()
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
    AddItemToTicket() {
      this.item.invoiceId = this.ticket.invoiceId
      this.item.qyt = 1
      this.item.total = this.item.price * this.item.qyt
      console.log(this.payment)
      try {
        this.showblock = true;
        this.$http.post('/api/pos/AddItemToTicket', { sale: this.item, payment: this.payment  }).then(response => {
          this.showblock = true;
          if (response.data.errorCode == 0) {
            this.GetSalesById()
          }
          else {
            this.error = response.data.errorCode + '' + response.data.message

            this.showModal()
          }
        })
          .catch((error) => console.log(error))
        

      } catch (err) {
        window.alert('err' + err)
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
    RemoveSaleFromTicket(sale)
    {
      try {
        this.showblock = true
        this.$http.post('/api/pos/RemoveSaleFromTicket', sale).then(response => {
          this.showblock = false

          if (response.data.errorCode == 0) {
            window.alert('تم delete ' + response.data.rows)
            this.GetSalesById()
          }
          else {
            this.error = response.data.errorCode + '' + response.data.message
            this.showModal()
          }
        })
          .catch((error) => console.log(error))
      } catch (err) {
        window.alert('err' + err)
        return

      }
     
    },
    EditSaleQuantity(sale)
    {
      
      if (sale.qyt === '' || sale.qyt === '0' || parseInt(sale.qyt) <= 0  ) {
        this.error = 'يجب تحديد كمية'
        this.GetSalesById()
        this.showModal()
      }
      else
      {
        try {
          this.showblock = true
          this.$http.post('/api/pos/EditSaleQuantity', sale).then(response => {
            this.showblock = false

            if (response.data.errorCode == 0) {
             
              this.GetSalesById()
            }
            else {
              this.error = response.data.errorCode + '' + response.data.message
              this.GetSalesById()
              this.showModal()
            }
          })
            .catch((error) => console.log(error))
        } catch (err) {
          window.alert('err' + err)
          return

        }
       

      }



    },
    //--------------------------------------------------------------------------------------------------------
    clearName() {
      this.name = ''
    },
    handleOk(evt) {
      // Prevent modal from closing
      evt.preventDefault()
      if (this.id == 0) {
       
      } else {
        this.handleSubmit()
      }
    },

    CreateNewticket() {
      
      this.newticket = true

      try {

        this.$http.get('/api/pos/CreateNewticket').then(response => {

          if (response.data.errorCode == 0) {
            this.ticket = response.data.ticket
            this.GetSalesById()
            this.ticket.total = this.total
          }
          else {
            this.error = response.data.errorCode + '' + response.data.message

            this.showModal()
          }
        })
          .catch((error) => console.log(error))


      } catch (err) {
        window.alert('eroor=' + err)
        return

      }
    },
    OpenExistTicket(ticket) {
      this.newticket = true
      this.ticket = ticket
      this.payment = ticket.paymentId
      this.GetSalesById()
      this.date = ticket.createdDate
      },
    
  
    SubmitTicket()
    {
      try {
        this.ticket.dis =  this.totaldiscount
        this.ticket.total = this.total
        this.Posted = true;
        this.showblock = true;
        this.$http.post('/api/pos/SubmitTicket', this.ticket).then(response => {
          this.showblock = false;
          if (response.data.errorCode == 0) {
            this.newticket = false;
             this. ticket= {
              InvoiceId: 0, CusId: 0, Date: '', Time: '', Total: '', Dis: 0,
                OperId: 0, Caption: '', PaymentId: 0, InvoiceTypeId: 0, BranchId: 0,
                  SalesmanId: 0, Ws: 0, ModleId: 0, StateId:0, ModelId:0, Note: '', Posted: false, CreatedDate:''
            }
             this.sales = [];
             this.error='تمت معالجة الفاتورة بنجاح'
             this.showModal()

          }
          else {
            this.error = response.data.errorCode + '' + response.data.message
            this.showModal()
          }
        })
          .catch((error) => console.log(error))


      } catch (err) {
        window.alert('eroor=' + err)
        return

      }

    },
    SuspendTicket() {
      console.log('1')
      try {
        this.ticket.dis = this.totaldiscount
        this.ticket.total = this.total
        this.Posted = false;
        this.showblock = true;
        this.$http.post('/api/pos/SubmitTicket', this.ticket).then(response => {
          this.showblock = false;
          if (response.data.errorCode == 0) {
            this.newticket = false;
           
            this.sales = [];
            this.error = 'تم تعليق الفاتورة رقم' + this.ticket.invoiceId 
            this.showModal()
            this.payment = 1
            this.ticket = {
              InvoiceId: 0, CusId: 0, Date: '', Time: '', Total: '', Dis: 0,
              OperId: 0, Caption: '', PaymentId: 0, InvoiceTypeId: 0, BranchId: 0,
              SalesmanId: 0, Ws: 0, ModleId: 0, StateId: 0, ModelId: 0, Note: '', Posted: false, CreatedDate: ''
            }
            this.GetsSuspendedTicket()
          }
          else {
            this.error = response.data.errorCode + '' + response.data.message
            this.showModal()
          }
        })
          .catch((error) => console.log(error))


      } catch (err) {
        window.alert('eroor=' + err)
        return

      }

    },
    GetsSuspendedTicket() {
      try {
      

        this.showblock = true;
        let response = this.$http.get(`/api/pos/GetsSuspendedTicket`).then(response => {
          this.showblock = false;
          if (response.data.errorCode == 0) {
            this.tickets = response.data.tickets
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

    handleSubmit() {
      this.GetitemById()
      this.$refs.modal.hide()
    },
    //-----------------------------------------------------------------------------------------------------------
    showModal() {
      this.$refs.myModalRef.show()
    },
    hideModal() {
      this.$refs.myModalRef.hide()
    }
    //---------------------------------------------------------------------------------------------------------
  },
  async created() {
    this.GetPayments()
    this.GetsSuspendedTicket()
  }
}
