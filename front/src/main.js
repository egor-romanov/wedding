import Vue from 'vue';

import Vuelidate from 'vuelidate';
Vue.use(Vuelidate);

import 'components/Gallery/lightbox.css';
import Lightbox from 'components/Gallery';
Vue.use(Lightbox);

import { library } from '@fortawesome/fontawesome-svg-core';
import { faUserSecret } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

library.add(faUserSecret);
Vue.component('font-awesome-icon', FontAwesomeIcon);

Vue.use(require('vue-resource'));
const VueRouter = require('vue-router');
Vue.use(VueRouter);
const Config = require('./config.js');

Vue.http.options.root = Config.apiurl();

const routes = require('./routes.js');
const router = new VueRouter(routes);
import store from './store.js';

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth)) {
    // this route requires auth, check if logged in
    // if not, redirect to login page.
    if (store.getters.isLoggedIn) {
      next();
      return;
    }
    next('/login');
  } else {
    next(); // make sure to always call next()!
  }
});

import App from './App';
/* eslint-disable no-new */
new Vue({
  router,
  el: '#app',
  render: h => h(App),
  store: store,
});
