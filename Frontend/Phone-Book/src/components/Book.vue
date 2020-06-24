<template>

  <div>

    <add-number v-if="phoneBook != null" ></add-number>

    <section class="row log text-left">
      <div class="small-12 columns">

        <ul v-if="phoneBook != null" class="list-group list-group-flush">
          <li class="list-group-item" v-for="entry in filteredPhoneBook">
            <span v-for="(value) in entry">
              {{ value }}
            </span>
          </li>
        </ul>



      </div>
    </section>

  </div>

</template>

<script>

  import AddNumber from './AddNumber';

  export default {

    props: ['phoneBook'],
    components: {
      addNumber: AddNumber
    },
    data() {
      return {
        //phoneBook: this.$store.state.phoneBook
      }
    },
    methods: {
      addEntry(event) {

        this.$store.dispatch('addEntry', event.target.value);
      }
    },
    computed: {
      filteredPhoneBook() {
        return this.phoneBook.entries.filter((entry) => entry.name.toLowerCase().match(this.$store.getters.search.toLowerCase()) ||
                                                        entry.phoneNumber.match(this.$store.getters.search));
      }
    }
  }

</script>

<style scoped>

  .text-left {
    text-align: left;
  }

  .log ul {
    display: flex;
    justify-content: center;
    list-style: none;
    font-weight: bold;
    text-transform: uppercase;
  }

  .log ul li {
    margin: 5px;
  }

</style>
