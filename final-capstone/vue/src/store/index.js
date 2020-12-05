import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    parkingSpots: [
      {
        spotName: "spot-1",
        spotId: 1,
        available: false
      },
      {
        spotName: "spot-2",
        spotId: 2,
        available: true
      },
      {
        spotName: "spot-3",
        spotId: 3,
        available: true
      },
      {
        spotName: "spot-4",
        spotId: 4,
        available: false
      },
      {
        spotName: "spot-5",
        spotId: 5,
        available: true
      },
      {
        spotName: "spot-6",
        spotId: 6,
        available: false
      },
      {
        spotName: "spot-7",
        spotId: 7,
        available: true
      },
      {
        spotName: "spot-8",
        spotId: 8,
        available: true
      },
      {
        spotName: "spot-9",
        spotId: 9,
        available: true
      },
      {
        spotName: "spot-10",
        spotId: 10,
        available: true
      },
    ],
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    }
  }
})
