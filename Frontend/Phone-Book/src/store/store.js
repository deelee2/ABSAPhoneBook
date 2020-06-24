import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export const store = new Vuex.Store({

  state: {

    phoneBooks: [],
    search: '',
    phoneBookSelected: ''
  },

  getters: {

    currentPhoneBookSelected: state => {
      return state.phoneBookSelected;
    },
    search: state => {
      return state.search;
    },
    phoneBooks: state => {
      return state.phoneBooks;
    },
    phoneBookSelected: state => {
      return state.phoneBookSelected;
    }
  },

  mutations: {

    phoneBookSelected: (state, phoneBookSelected) => {
      state.phoneBookSelected = phoneBookSelected;
    },

    addPhoneBookEntry: (state, payload) => {
      let phoneBook = state.phoneBooks.find( (book) => book.phoneBookName === payload.phoneBookName);
      phoneBook.entries.push(payload.entry);
    },

    setPhoneBooks: (state, payload) => {
      state.phoneBooks = payload;
    },

    //Search criteria set through the header
    addSearchCriteria: (state, payload) => {
      state.search = payload;
    }

  },

  actions: {

    /**
     * Indicates a phone book has been selected
     * @param {Function} commit object providing commit capabilities
     * @param {String} phoneBookName the phone book we are loading from memory
     */
    phoneBookSelected: ({commit}, phoneBookName)  => {
      commit('phoneBookSelected', phoneBookName);
    },

    /**
     * Indicates a search term has been entered
     * @param {Function} commit object providing commit capabilities
     * @param {String} payload search criteria entered in the search bar within the header
     */
    addSearchCriteria: ({commit}, payload) => {
      commit('addSearchCriteria', payload);
    },

    /**
     * Add an entry to the phone book specified in the payload
     * @param {Function} commit object providing commit capabilities
     * @param {String} payload the new entry we are sending to the server
     */
    addPhoneBookEntry: ({commit}, payload) => {

      Vue.http.put('', payload)
        .then(data => {

          if (data && data.body) {
            commit('addPhoneBookEntry', data.body);
          }
        });
    },

    /**
     * The initial call made to load all the available phone book data
     * @param {Function} commit object providing commit capabilities
     */
    loadPhoneBooks: ({commit}) => {

      Vue.http.get('')
        .then(response => response.json())
        .then(data => {

          if (data) {
            commit('setPhoneBooks', data);
          }
        });
    }
  }
});
