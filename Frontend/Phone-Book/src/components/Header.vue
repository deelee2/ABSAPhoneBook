<template>

  <nav class="navbar navbar-dark bg-dark">
    <form class="form-inline">
      <input @input="addSearchCriteria" v-model="search" class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
    </form>
    <div class="dropdown">
      <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        Select Phone Book
      </button>
      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
        <ul class="dropdown-ul">
          <li class="dropdown-item" v-for="book in this.$store.getters.phoneBooks">
            <strong @click="bookSelected(book.phoneBookName)"> {{ book.phoneBookName }}  </strong>
          </li>
        </ul>
      </div>
    </div>
  </nav>

</template>

<script>

  export default {

    data() {
      return {
        search: ''
      }
    },
    methods: {

      bookSelected(phoneBookName) {

        //clear search criteria to ensure we see an updated view
        this.search = '';
        this.$store.dispatch('addSearchCriteria', '');

        this.$store.dispatch('phoneBookSelected', phoneBookName);
      },

      addSearchCriteria(event) {
        this.$store.dispatch('addSearchCriteria', event.target.value);
      }
    }
  }
</script>

<style scoped>

  .dropdown-ul {
    display: block;
    width: 100%;
    padding: .25rem 1.5rem;
    clear: both;
    font-weight: 400;
    color: red;
    text-align: inherit;
    white-space: nowrap;
    background-color: transparent;
    border: 0;
  }

</style>


