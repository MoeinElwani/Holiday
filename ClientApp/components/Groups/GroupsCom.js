var filters = {
  'all': function (groups) {
    return groups;
  },
  discounted: function (groups) {
    return groups.filter(function (group) {
      return group.discount <= 0 ? '' : group;
    });
  },
  revesabel: function (groups) {
    return groups.filter(function (group) {
      return group.daysReverse > 0 ? group : '';
    });
  }
}


export default {
  computed: {
    filterdGroups: function () {
      return filters[this.visibility](this.groups);
    }
   

  },
  data() {

    return {
      error: 'خطأ!',
      groups: null,
      group: { GroupId: 0, GroupDes: '', TypeId: 0, IsReversabel: false, DaysReverse: 0, Discount:0},
      show: false,
      
      visibility: 'all',
      message: 'الرجاء الأنتظار'
      , url: 'ملاحظة', showblock: false
      
    }
  },

  methods: {
    async loadPage(page) {
      this.groups= null
     

      try {
        
        let response = await this.$http.get(`/api/groups/GetAllGroups`)

        if (response.data.errorCode == 0)
        {
          this.groups = response.data.groups
          console.log(response.data)

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
       
        this.showblock = true
        this.$http.post('/api/groups/Edit', this.group).then(response => {
          this.showblock = false

          if (response.data.errorCode == 0)
          {
          this.error = 'تم تعديل المجموعة'
          this.show = false
          this.group = { GroupId: 0, GroupDes: '', TypeId: 0, IsReversabel: false, DaysReverse: 0, Discount: 0 }
          this.loadPage(1)
          }
          else 
            this.error = response.data.message
          this.showModal()
          


        })
          .catch((error) => console.log(error))
      
      } catch (err) {
        window.alert('err' + err)
        return

      }
    
     
     
    },
     onReset(evt) {
       evt.preventDefault();
       this.group ={ GroupId: 0, GroupDes: '', TypeId: 0, IsReversabel: false, DaysReverse: 0, Discount:0 }
       this.show = false
    },
     edit(group) {
      this.show = true
     
       this.group.GroupId = group.groupId
       this.group.GroupDes = group.groupDes
       this.group.DaysReverse = group.daysReverse
       this.group.Discount = group.discount
    
       this.group.GypeId = group.typeId
       this.group.IsReversabel = group.isReversabel
    
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
