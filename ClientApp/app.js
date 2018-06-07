import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import { FontAwesomeIcon } from './icons'
import BootstrapVue from 'bootstrap-vue'
import BlockUI from 'vue-blockui'


import VueQrcode from '@xkeshi/vue-qrcode'
Vue.use(BlockUI)
Vue.component('qrcode', VueQrcode);
Vue.use(BootstrapVue);
//import { FormInput } from 'bootstrap-vue/es/components';
Vue.use(require('vue-moment'));

//Vue.use(FormInput);

// Registration of global components
Vue.component('icon', FontAwesomeIcon)

Vue.prototype.$http = axios

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
