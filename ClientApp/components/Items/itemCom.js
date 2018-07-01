var filters = {
  'all': function (items) {
    return items;
  },
  discounted: function (items) {
    return items.filter(function (item) {
      return item.packagePrice != item.itemPrice ? item : '';
    });
  },
  undiscounted: function (items) {
    return items.filter(function (item) {
      return item.packagePrice == item.itemPrice ? item : '';
    });
  }, 
  cannotdiscount: function(items) {
    return items.filter(function (item) {
      return item.discount == 'غير قابلة' ? item : '';
    });
  },
}


export default {
  computed: {


    itemss() {
    this.showblock = true  //referebced in your template just as booksList
      return this.items.map((b) => {
        this.itemstoedit=[]
        if (b.discount > 0)
        {
          b.packagePrice = b.itemPrice - ((b.discount / 100) * b.itemPrice); 
        }
        else if (b.discount == 0)
        { b.packagePrice = b.itemPrice - ((this.setdiscount(b.groupId) / 100) * b.itemPrice); console.log(b.groupId + '-' + b.discount) }
        else
          b.packagePrice = b.itemPrice



        if (b.packagePrice != b.itemPrice)
          b.discount = b.discount > 0 ? b.discount = b.discount + '% خاص ' : b.discount = this.setdiscount(b.groupId) + '% مجموعة '
        else if (b.discount ==-1)
          b.discount ='غير قابلة'
        else
          b.discount = '%0 بدون '


        if (b.daysReverse>0)
          b.daysReverse = b.daysReverse + ' خاص ' 
        else if (b.daysReverse == -1)
          b.daysReverse = 'غير قابلة'
        else
          b.daysReverse = this.getgroupDayes(b.groupId) + ' مجموعة '

        if (!b.stopSaleF)
          b.stopSaleF = "موقوف"
        else
          b.stopSaleF = "متاح"

        b.enNum = this.getgroupname(b.groupId) 
      
        b.compId = this.GetCompanyName(b.compId)
        this.showblock = false
        return b
      })
  
    },
    
    filterditems: function () {
      return filters[this.visibility](this.itemss);
    },
    totalPages: function () {
      return Math.ceil(this.total / this.pageSize)
    },
  
  }
  , watch: {
    currentPage: function () {
      
      this.GetItemsByName()
    },
      // whenever question changes, this function will run
    searshname: function ()
    {
      return this.GetItemsByName()
    },
    selected: function ()
    {
      this.GetDepartmentbyGroupId()
      this.GetItemsByName()
    }
    ,
    selecteddepartment: function ()
    {
      this.GetTypebyDepartments()
      this.selectedtypes=-1
      this.GetItemsByName()
    }
    ,
    selectedtypes: function ()
    {
      this.GetItemsByName()
    },
    selectedcompaies: function () {
      this.GetItemsByName()
    },
    pageSize: function () {
      this.pageSize = parseInt(this.pageSize)

      this.GetItemsByName()
    },
    },

  data() {
 
    return {
      format: ' yyyy - MM - dd ',
      type: 'fmt',
      autoUpdate: false,


      currentPage: 1,
      pageSize: 5,
      page:1,
      total:0,


      items:null,

   
      searshname: '',
      name: 'jjjjjjj',
      names: [],
      //ID:0
      message: "جاري تحميل الأصناف",
      showblock: false,
      visibility: 'all',

      showblock: false,
      error: 'خطأ!',
      compaies:[],
      groups: [],
      types: [],
      typesbydep:[],
      departments: [],
      itemstoedit:[],
      selectalltype:'معالجة الأصناف المحددة',
      number:0,//number of dayse to reverse or discount 
      options: [
        { text: 'تخفيض', value: 1 },
        { text: 'بدون تخفيض', value: -1 },
        { text: 'تخفيض على المجموعة', value: 10 },
        
        { text: 'ترجيع', value: 2 },
        { text: 'بدون ترجيع', value: -2 },
        { text: 'ترجيع على المجموعة', value: 20 },

        { text: 'أيقاف البيع', value: 31 },
        { text: 'أتاحة البيع', value: 30 },
      ]
    ,
      selectedprocess: 1,
      selectedtypes: null,
      selected: 0,
      selecteddepartment: null,
      selectedcompaies: 0,
      group: { groupId: 0, groupDes: 'الكل', typeId: 0, isReversabel: false, daysReverse: 0, discount: 0 }
    }
  },
  
  methods: {
    formatPrice(value) {
      let val = (value / 1).toFixed(2)

      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")
    },

    frontEndDateFormat: function (date) {
      return moment(date, 'YYYY-MM-DD').format('DD/MM/YYYY');
    },
    checkboxToggle()
   {     
      var temp = []
      if (this.selectalltype == 'معالجة الأصناف المحددة')
      {
        for (var i = 0; i < this.items.length; i++)
          if (this.itemstoedit.indexOf(this.items[i])<0)
            temp.push(this.items[i])
      }    
      else
      {
        for (var i = 0; i < this.items.length; i++)
          if (this.itemstoedit.indexOf(this.items[i]) < 0)
            temp.push(this.items[i])      
      }
      this.itemstoedit = temp
    },
    SlectItem(item) {
      //if (!this.selectalltype) {
        if (!item.snF) {
          if (this.itemstoedit.indexOf(item) < 0)
            this.itemstoedit.push(item)
        }
        else
          this.itemstoedit.splice(this.itemstoedit.indexOf(item), 1)
      },
    clearName() {
      this.number=0
    },
    handleOk(evt) {
      // Prevent modal from closing
      evt.preventDefault()
      if ((this.selectedprocess == 1 || this.selectedprocess == 2) && this.number <= 0) {
        this.error = 'يجب تحديد رقم أكبر من صفر'
        this.showModal()
      } else {
        this.handleSubmit()
      }
    },
    handleSubmit() {
     this.ProcessItems()
      this.$refs.modal.hide()
    },
    //--------------------------------------------------------------------------------------------
   
    showModal() {
      this.$refs.myModalRef.show()
    },
    hideModal() {
      this.$refs.myModalRef.hide()
    },

    //---------------------------------------------------------------------------------------------------------
 
    ProcessItems()
    {
      try {
        this.message="جاري معالجة الأصناف"
        this.showblock = true
        this.$http.post('/api/items/ProcessItems', { items: this.itemstoedit, process: this.selectedprocess, number: this.number }).then(response => {
        this.showblock = false
        if (response.data.errorCode == 0)
        {
          this.GetItemsByName()
          window.alert('تم ' + response.data.rows)     
        
          }
        else
         {
            this.error = response.data.errorCode + '' + response.data.message
            this.showModal()
          }
        })
          .catch((error) => console.log(error))
      } catch (err) {
        window.alert('err' + err)
        return

      }
      
    }
    , GetItemsByName() {
      //let fetch = new FetchData()
      try {

        //if (this.searshname=='')
        //  this.searshname = ' '
        var from = (this.currentPage - 1) * (this.pageSize)
        var to = from + this.pageSize
        console.log(from + "+" + to + "--" + this.pageSize)

        if (!this.selecteddepartment)
         this.selecteddepartment = -1 

        if (!this.selectedtypes)
          this.selectedtypes = -1
          this.message= "جاري تحميل الأصناف"
          this.showblock = true
          this.$http.get(`/api/items/SearshByName?from=${from}&to=${to}&name=${this.searshname}&comid=${this.selectedcompaies}&dapid=${this.selecteddepartment}&grpid=${this.selected}&typeid=${this.selectedtypes}`)
          .then(response => {
            this.showblock = false;


                if (response.data.errorCode == 0)
                {
                    this.items = response.data.items
                    this.total = response.data.count
                   // this.setdiscount()
                   
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
      
    }
    , AddItem(item) {
      //let fetch = new FetchData()
      //this.total = fetch.mm
      let axiosConfig = {
        headers: {
          'Content-Type': 'application/json;charset=UTF-8',
          "Access-Control-Allow-Origin": "*",
        }
      };
      try {
        this.$http.post('/api/itmes/Additem', item).then(response => {
         
          this.items = response.data.items
          // this.total = response.data.total
          window.alert('ppppp' + response)
        console.log(response)


        })
          .catch((error) => console.log(error))
        //let response = await this.$http.get(`/api/itmes/WeatherForecasts`)
        window.alert(error)

      } catch (err) {
        window.alert('pphhhhhhhhhhhhhhhhppp' +err)
        return 
       
      }

    }
    , GetGroups() {
      try {

        let response =  this.$http.get(`/api/groups/GetAllGroups`)
          .then(response => {

            if (response.data.errorCode == 0) {
              this.groups = response.data.groups
              this.groups.push(this.group)
              this.groups.reverse()
            }
            else
              window.alert(response.data.errorCode)

          

          })
          .catch((error) => console.log(error))
      

      } catch (err) {
        window.alert(err)
        console.log(err)

      }
    }
    , GetCompaies() {
      try {

        let response = this.$http.get(`/api/items/GetAllCompanies`)
          .then(response => {

            if (response.data.errorCode == 0) {
              {
              this.compaies = response.data.companies
                this.compaies.push({ compDes: 'الكل', compId: 0 })
                this.compaies.reverse()
              }
            }
            else
              window.alert(response.data.errorCode)



          })
          .catch((error) => console.log(error))


      } catch (err) {
        window.alert(err)
        console.log(err)

      }
    }
    , GetDepartments() {
      try {

        let response = this.$http.get(`/api/items/GetAllDepartment`)
          .then(response => {

            if (response.data.errorCode == 0) {
              this.departments = response.data.departments
            
            }
            else
              window.alert(response.data.errorCode)



          })
          .catch((error) => console.log(error))


      } catch (err) {
        window.alert(err)
        console.log(err)

      }
    }
    , GetTypebyDepartments(depId) {
      var depId=this.selecteddepartment
      try {
     
        let response = this.$http.get(`/api/items/GetTypebyDepartments?depId=${depId} `)

          .then(response => {

            if (response.data.errorCode == 0) {
              this.types = response.data.types 
            }
            else
              window.alert(response.data.errorCode)
          })
          .catch((error) => console.log(error))


      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    }
    , GetDepartmentbyGroupId(gId) {
      var gId = this.selected
      try {

        let response = this.$http.get(`/api/items/GetDepartmentbyGroupId?gId=${gId} `)
          .then(response => {
            if (response.data.errorCode == 0) {
              this.departments = response.data.departments
            }
            else
              window.alert(response.data.errorCode)
          })
          .catch((error) => console.log(error))


      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    }
    , setdiscount(group)
    {
      for (var i = 0; i < this.groups.length; i++)
        if (this.groups[i].groupId == group)
          return this.groups[i].discount
        

     // for (var i = 0; i < this.items.length; i++) {
     //   if (this.items[i].isReversabel <= 0) {
     //     for (var j = 0; j < this.groups.length; j++) {
     //       if (this.groups[j].groupId == this.items[i].groupId) {
     //         if (this.groups[j].discount > 0) {
     //           this.items[i].packagePrice = this.items[i].itemPrice - (this.groups[j].discount / 100 * this.items[i].itemPrice);
     //           break;
     //         }
     //         else {
     //           this.items[i].packagePrice = this.items[i].itemPrice - (this.groups[j].discount / 100 * this.items[i].itemPrice);
     //           break;
     //         }
     //       }
     //     }
     //   }
     //   else
     //     this.items[i].packagePrice = this.items[i].itemPrice - (this.items[i].isReversabel / 100 * this.items[i].itemPrice)
     //}
    },
     getgroupname(group)
    {
      for (var i = 0; i < this.groups.length; i++)
        if (this.groups[i].groupId == group)
          return this.groups[i].groupDes
    },
    GetCompanyName(company)
    {
      for (var i = 0; i < this.compaies.length; i++)
        if (this.compaies[i].compId == company)
          return this.compaies[i].compDes

    },
    getgroupDayes(group) {
      for (var i = 0; i < this.groups.length; i++)
        if (this.groups[i].groupId == group)
          return this.groups[i].daysReverse
    }
  }
  ,

  async created() {
 //   this.loadPage(1)
    this.GetGroups()
    this.GetDepartments()
    this.GetTypebyDepartments()
    this.GetCompaies()
      

  }
}
