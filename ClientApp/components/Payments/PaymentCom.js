


export default {
  computed: {
   

  },
  data() {

    return {
      name: '',
      payments: null,
      payment: { paymentId: 0, PaymentDes: '', Status: false, discount: 0, currId:0, paymentType:0},
      show: false,

     error:'خطأ',
      message: 'الرجاء الأنتظار'
      , url: 'ملاحظة', showblock: false
      
    }
  },

  methods: {
    async loadPage(page) {
     
      this.currentPage = page

      try {
        var from = (page - 1) * (this.pageSize)
        var to = from + this.pageSize
        let response = await this.$http.get(`/api/payment/GetAllPAyments`)

        if (response.data.errorCode == 0)
        {
          this.payments = response.data.payments
        

        }
        else
          window.alert(response.data.errorCode )
       
      } catch (err) {
        window.alert(err)
        console.log(err)
       
      }

    }
    ,onSubmit(evt) {
      evt.preventDefault();


      try {
   
        this.showblock=true
        this.$http.post('/api/payment/Edit', this.payment).then(response => {
          this.showblock = false

          if (response.data.errorCode == 0)
   
          {
            this.error = 'تم تعديل سعر' + response.data.message + 'صنف بنجاح'


            if (response.data.message == 0)
              this.error='تم تغيير طريقة الدفع'
            
            this.showModal()
            this.loadPage(1)
            this.show = false
          }
          else {
            this.error = response.data.message
            this.showModal()
          
          }


        })
          .catch((error) => console.log(error))
        //let response = await this.$http.get(`/api/itmes/WeatherForecasts`)
     

      } catch (err) {
        window.alert('err' + err)
        return

      }

     
    },
     onReset(evt) {
      evt.preventDefault();
      /* Reset our form values */
      this.payment.iD = 0;
      this.payment.name = '';
      this.payment.state = false;
      this.payment.discount = 0;
      /* Trick to reset/clear native browser form validation state */
      this.show = false;
   //   this.$nextTick(() => { this.show = true });
    },
     edit(payment) {
       this.show = true
       this.payment.paymentId = payment.paymentId
       this.payment.PaymentDes = payment.paymentDes
       this.payment.Status = payment.status
       this.payment.discount = payment.discount
       this.payment.currId = payment.currId
       this.payment.paymentType = payment.paymentType
      
    
     },

       //-----------------------------------------------------------------------------------
      showModal() {
       this.$refs.myModalRef.show()
     },
     hideModal() {
       this.$refs.myModalRef.hide()
     }
     //----------------------------------------------------------------------------------------

  
  },

  async created() {
    this.loadPage(1)
  }
}
