import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import { FontAwesomeIcon } from './icons'
import BootstrapVue from 'bootstrap-vue'
import BlockUI from 'vue-blockui'
import { focus } from 'vue-focus'
//import Moment from 'moment'
import { mixin as focusMixin } from 'vue-focus';
import VueQrcode from '@xkeshi/vue-qrcode'
import vueDateFormat from 'vue-date-format'
import Datepicker from 'vuejs-datepicker';

//import VueBarcodeScanner from 'vue-barcode-scanner'
Vue.component('Key-board', {
  data: function () {
    return {
      count: 0,
      numbers: ['0', '9', '8', '7', '6', '5', '4', '3', '2', '1'],
      keys: ['ر', 'ذ', 'د', 'خ', 'ح', 'ج', 'ث', 'ت', 'ب', 'ا'],
      keys1: ['غ', 'ء', 'ع', 'ظ', 'ط', 'ض', 'ص', 'ش', 'س', 'ز'],
      keys2: ['ي', 'ة', 'و', 'ه', 'ن', 'م', 'ل', 'ك', 'ق', 'ف'],

    }
  },
   methods: {
     addkey(key) {

    
       this.$emit('dojob', key)    
     },
   

  },
  props: ['type','value'],
  template: `
      <div v-if="this.type==1"  >
  <b-card bg-variant="light">
        <table  class="table table-sm table-borderless ">
          <tr >
            <td v-for="(key,index)  in numbers">
              <b-button  @click="addkey(key)" size="sm" variant="primary">
                {{key}}
              </b-button>
            </td>
          </tr>
          <tr >
            <td v-for="(key,index)  in keys">
              <b-button  @click="addkey(key)" size="sm" variant="primary">
                {{key}}
              </b-button>
            </td>
          </tr>
          <tr >
            <td v-for="(key,index)  in keys1">
              <b-button  @click="addkey(key)" size="sm" variant="primary">
                {{key}}
              </b-button>
            </td>
          </tr>
          <tr >
            <td v-for="(key,index)  in keys2">
              <b-button  @click="addkey(key)" size="sm" variant="primary">
                {{key}}
              </b-button>
            </td>
          </tr>
           
        </table>
    <div class="d-block text-center">
          <b-button  @click="addkey('clear')" size="sm" variant="primary">
            cleare
          </b-button>
          <b-button  @click="addkey(' ')" size="sm" variant="primary">
            Space
          </b-button>
          <b-button  @click="addkey('delete')" size="sm" variant="primary">
            delete
          </b-button>
        </div>
 </b-card>
  
    
  </div>
 
 <div v-else-if="this.type==0">
 <b-card bg-variant="light">
 <table  class=" table-sm  ">
          <tr >
            <td v-for="(key,index)  in numbers">
              <b-button  @click="addkey(key)" size="sm" variant="primary">
                {{key}}
              </b-button>
            </td>
           <td>  <b-button  @click="addkey('clear')" size="sm" variant="primary">
            cleare
          </b-button>
            </td>
          </tr>
</table>
</b-card>
</div>
`
})

// inject vue barcode scanner
//Vue.use(VueBarcodeScanner)

Vue.use(vueDateFormat)
Vue.component('qrcode', VueQrcode);
Vue.component('icon', FontAwesomeIcon)
Vue.use(BootstrapVue);
Vue.use(BlockUI)
//Vue.use(Moment);
Vue.component('datepicker', Datepicker)


Vue.prototype.$http = axios

sync(store, router)

const app = new Vue({
  store,
 
  directives: { focus: focus },
  router,
  ...App
})

export {

  app,
  router,
  store
}
