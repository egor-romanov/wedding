import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);
export default new Vuex.Store({
  state: {
    status: '',
    token: localStorage.getItem('token') || '',
    user: {},
  },
  mutations: {
    auth_request(state) {
      state.status = 'loading';
    },
    auth_success(state, token, user) {
      state.status = 'success';
      state.token = token;
      state.user = user;
    },
    auth_error(state) {
      state.status = 'error';
    },
  },
  actions: {
    login({ commit }, user) {
      commit('auth_request');

      if (+user.pin === 3118) {
        localStorage.setItem('token', 3118);
        commit('auth_success', 3118, user);
      } else {
        commit('auth_error');
        localStorage.removeItem('token');
      }
    },
  },
  getters: {
    isLoggedIn: state => !!state.token,
    authStatus: state => state.status,
  },
});
