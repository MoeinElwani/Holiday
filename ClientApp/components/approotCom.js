import NavMenu from './nav-menu'

export default {
  components: {
    'nav-menu': NavMenu
  },

  data() {
    return {
      logedin: true,
      userId: null,
      password: null
      ,error:'err'
    }
  },
   methods: {
     Login() {
       try {

         this.showblock = true
         this.$http.post('/api/items/Login', { userId: this.userId, password: this.password }).then(response => {
           this.showblock = false

           if (response.data.errorCode == 0) {
             this.error = 'ok'
             this.show = false
             this.logedin=true
           }
           else
           //this.error = response.data.message
           //this.showModal()
           //logedin=false
           //userId = null
             //password = null
             console.log(response.data.errorCode)


         })
           .catch((error) => console.log(error))

       } catch (err) {
         window.alert('err' + err)
         return

       }




     },
     IsLogin() {
       try {
         this.showblock = true
         this.$http.post('/api/items/IsLogin', ).then(response => {
           this.showblock = false

           if (response.data.errorCode == 0) {

             this.logedin = true
             console.log('loged')
           }
           else {
             console.log(response.data.errorCode)
             this.logedin = false
           }

         })
           .catch((error) => console.log(error))

       } catch (err) {
         window.alert('err' + err)
         return

       }
     }
     
  }, async created() {
   //  this.IsLogin()
  }


}

