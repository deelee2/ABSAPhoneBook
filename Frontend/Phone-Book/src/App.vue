<template>
  <div class="container">
    <app-header></app-header>
    <div class="row">
      <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
        <book :phoneBook = books></book>
      </div>
    </div>
  </div>
</template>

<script>

  import Header from './components/Header';
  import Book from './components/Book';

  export default {

    components: {
      appHeader: Header,
      book: Book
    },
    data() {
      return {
        phoneBook: this.books
      }
    },
    computed: {
      books() {
        return this.$store.getters.phoneBooks.find(book => book.phoneBookName === this.phoneBookSelected);
      },
      phoneBookSelected() {
        return this.$store.getters.phoneBookSelected;
      }
    },
    created() {
      this.$store.dispatch('loadPhoneBooks');
    }
  }

</script>

<style lang="scss">
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }

  h1, h2 {
    font-weight: normal;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    display: inline-block;
    margin: 0 10px;
  }

  a {
    color: #42b983;
  }
</style>
