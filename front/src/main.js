import Vue from 'vue';

Vue.use(require('vue-resource'));
const VueRouter = require('vue-router');
Vue.use(VueRouter);
const Config = require('./config.js');

Vue.http.options.root = Config.apiurl();

const routes = require('./routes.js');
const router = new VueRouter(routes);
import App from './App';
/* eslint-disable no-new */
new Vue({
  router,
  el: '#app',
  render: h => h(App),
});
