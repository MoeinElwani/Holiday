<template>
  <div>
    <b-btn v-b-modal.modalPrevent>Launch demo modal</b-btn>
    <!-- Main UI -->
    <div class="mt-3 mb-3">
      Submitted Names:
      <ul>
        <li v-for="n in names">{{n}}</li>
      </ul>
    </div>
    <!-- Modal Component -->
    <b-modal id="modalPrevent"
             ref="modal"
             title="Submit your name"
             @ok="handleOk"
             @shown="clearName">
      <form @submit.stop.prevent="handleSubmit">
        <b-form-input type="text"
                      placeholder="Enter your name"
                      v-model="name"></b-form-input>

        <b-form-select v-model="selected" :options="options" class="mb-3" />
        <b-form-select v-model="selected" :options="options" class="mb-3" size="sm" />-
      </form>
    </b-modal>
  </div>
</template>

<script>
  export default {
  data () {
  return {
  name: '',
  names: [],

  selected: null,
  options: [
  { value: null, text: 'Please select an option' },
  { value: 'a', text: 'This is First option' },
  { value: 'b', text: 'Selected Option' },
  { value: {'C': '3PO'}, text: 'This is an option with object value' },
  { value: 'd', text: 'This one is disabled', disabled: true }
  ]


  }
  },
  methods: {
  clearName () {
  this.name = ''
  },
  handleOk (evt) {
  // Prevent modal from closing
  evt.preventDefault()
  if (!this.name) {
  alert('Please enter your name')
  } else {
  this.handleSubmit()
  }
  },
  handleSubmit () {
  this.names.push(this.name)
  this.clearName()
  this.$refs.modal.hide()
  }
  }
  }
</script>
