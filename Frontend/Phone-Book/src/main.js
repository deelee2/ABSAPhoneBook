import Vue from 'vue';
import VueResource from 'vue-resource';
import App from './App.vue';
import Vuelidate from 'vuelidate';
import { store } from './store/store';

Vue.use(VueResource);
Vue.use(Vuelidate);

Vue.http.options.root = 'https://localhost:5001/api/phonebook';

new Vue({
  el: '#app',
  store,
  render: h => h(App)
})
