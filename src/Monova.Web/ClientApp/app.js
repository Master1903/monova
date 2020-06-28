import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/root/app-root'
import { FontAwesomeIcon } from './icons'
import Notifications from 'vue-notification'
import MVIText from '@/components/input/text'
import VueContentPlaceholders from 'vue-content-placeholders'

// Registration of global components
Vue.component('icon', FontAwesomeIcon)
Vue.component('mvi-text', MVIText)
Vue.use(Notifications)
Vue.use(VueContentPlaceholders)
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
