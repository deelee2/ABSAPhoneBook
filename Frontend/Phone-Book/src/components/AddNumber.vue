<template>

  <form @submit.prevent="onSubmit">

    <div class="row">
      <div class="col input" :class="{invalid: $v.enteredName.$error}">
        <input
          type="text"
          class="form-control"
          placeholder="Name"
          id="enteredName"
          @blur="$v.enteredName.$touch()"
          v-model="enteredName">

        <p v-if="!$v.enteredName.required"> Name is required.</p>
        <p v-if="!$v.enteredName.maxLength"> Name can be a max length of {{ $v.enteredName.$params.maxLength.max }}.</p>
      </div>


      <!--    <div class="row">-->

      <div class="col input" :class="{invalid: $v.enteredPhoneNumber.$error}">
        <input
          type="text"
          class="form-control"
          placeholder="Phone Number"
          id="phoneNumber"
          @blur="$v.enteredPhoneNumber.$touch()"
          v-model="enteredPhoneNumber">

        <p v-if="!$v.enteredPhoneNumber.required"> Number is required.</p>
        <p v-if="!$v.enteredPhoneNumber.numeric"> Must be a number (no spaces).</p>
        <p v-if="!$v.enteredPhoneNumber.unique"> Number already exists.</p>
        <p v-if="!$v.enteredPhoneNumber.maxLength"> Number can be a max length of {{ $v.enteredPhoneNumber.$params.maxLength.max }}.</p>
      </div>

    <!--    </div>-->

    <div class="col input submit">
      <button type="submit" :disabled="$v.$invalid">Add</button>
    </div>
    </div>

  </form>


</template>

<script>

  import {required, maxLength, numeric} from 'vuelidate/lib/validators';

  export default {

    data() {
      return {
        enteredName: '',
        enteredPhoneNumber: ''
      }
    },
    validations: {
      enteredName: {
        required,
        maxLength: maxLength(30)
      },

      enteredPhoneNumber: {
        required,
        numeric,
        maxLength: maxLength(10),
        unique: (val, vm) => {
          return vm.isNumberUnique(val);
        }
      }
    },
    methods: {
      addEntry(event) {

        this.$store.dispatch('addEntry', event.target.value);
      },

      isNumberUnique(val) {

        const exists = (element) => element.phoneNumber === val;
        return !this.$store.getters.phoneBooks.find(book => book.phoneBookName === this.currentPhoneBookSelected).entries
                                              .some(exists);
      },
      onSubmit() {

        const formData = {
          phoneBookName: this.currentPhoneBookSelected,
          entry: {
            name: this.enteredName,
            phoneNumber: this.enteredPhoneNumber
          }
        };

        this.$store.dispatch('addPhoneBookEntry', formData);

        this.enteredName = '';
        this.enteredPhoneNumber = '';
        this.$v.$reset();
      }
    },
    computed: {
      currentPhoneBookSelected() {
        return this.$store.getters.currentPhoneBookSelected;
      }
    }
  }

</script>

<style scoped>

  .input {
    margin: 10px auto;
  }

  .input.invalid label {
    color: red;
  }

  .input.invalid input {
    border: 1px solid red;
    background-color: lightcoral;
  }


  .input {
    margin: 10px auto;
  }

  .input label {
    display: block;
    color: #4e4e4e;
    margin-bottom: 6px;
  }

  .input input {
    font: inherit;
    width: 100%;
    padding: 6px 12px;
    box-sizing: border-box;
    border: 1px solid #ccc;
  }

  .input input:focus {
    outline: none;
    border: 1px solid #521751;
    background-color: #eee;
  }

  .submit button {
    border: 1px solid #521751;
    color: #521751;
    padding: 10px 20px;
    font: inherit;
    cursor: pointer;
  }

  .submit button:hover,
  .submit button:active {
    background-color: #521751;
    color: white;
  }

  .submit button[disabled],
  .submit button[disabled]:hover,
  .submit button[disabled]:active {
    border: 1px solid #ccc;
    background-color: transparent;
    color: #ccc;
    cursor: not-allowed;
  }

</style>
