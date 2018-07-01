export default {
  watch: {
    datesalesInvoices: function ()
    {
      if (this.ticketType=='sales')
        return this.GetSelesInvoices
      else if (this.ticketType == 'return')
        return this.GetReturnInvoices()
      else
        return  this.GetSuspendedInvoice()

    }
    , currentPage: function () {

      if (this.ticketType == "sales")
         this.GetSelesInvoices()
      else if (this.ticketType == 'return')
         this.GetReturnInvoices()
      else
         this.GetSuspendedInvoice()
    }
  },
  computed: {
    totalPages: function () {
      return Math.ceil(this.total / this.pageSize)
    }
  },
  data() {
    return {
      datesalesInvoices: new Date(),
      format: 'yyyy-MM-dd hh:mm:ss ',
      type: 'fmt',
      autoUpdate: false,
      page:1,

      selesInvoices: null,
      total: 0,
      pageSize: 5,
      currentPage: 1,

      ticketType:'sales'
    }
  },
  methods: {
    GetSelesInvoices() {
      this.ticketType = 'sales'
      var from = (this.currentPage - 1) * (this.pageSize)
      var to = from + this.pageSize

      var day = this.datesalesInvoices.getDate()
      var month= this.datesalesInvoices.getMonth()

     var year = this.datesalesInvoices.getFullYear()
      try {
        this.showblock = true;
        let response = this.$http.get(`/api/main/GetSelesInvoices?from=${from}&to=${to}&day=${day}&month=${month}&year=${year}`).then(response => {
          this.showblock = false;
          if (response.data.errorCode == 0) {
            this.selesInvoices = response.data.tickets
            this.total = response.data.count
          }
          else {
            alert('error')
          }

        }).catch((error) => console.log(error))

      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    },
    GetSuspendedInvoice() {
      this.ticketType = 'suspend'
      var from = (this.currentPage - 1) * (this.pageSize)
      var to = from + this.pageSize
      try {
        this.showblock = true;
        let response = this.$http.get(`/api/main/GetSuspendedInvoice?from=${from}&to=${to}`).then(response => {
          this.showblock = false;
          if (response.data.errorCode == 0) {
            this.selesInvoices = response.data.tickets
            this.total = response.data.count
          }
          else {
            alert('error')
          }

        }).catch((error) => console.log(error))

      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    },
    GetReturnInvoices() {
      this.ticketType= 'return'
      var from = (this.currentPage - 1) * (this.pageSize)
      var to = from + this.pageSize

      var day = this.datesalesInvoices.getDate()
      var month = this.datesalesInvoices.getMonth()

     var year = this.datesalesInvoices.getFullYear()
      console.log(month)
      try {
        this.showblock = true;
        let response = this.$http.get(`/api/main/GetReturnInvoices?from=${from}&to=${to}&day=${day}&month=${month}&year=${year}`).then(response => {
          this.showblock = false;
          if (response.data.errorCode == 0) {
            this.selesInvoices = response.data.tickets
            this.total = response.data.count
          }
          else {
            alert('error')
          }

        }).catch((error) => console.log(error))

      } catch(err) {
        window.alert(err)
        console.log(err)
      }
    },
    }
  , async created() {
    this.GetSelesInvoices()

  }
}
