<template lang="pug">
  .form
    form.form-group.col-xs-12.col-md-4(@submit.prevent='login')
      h1 Enter pin
      input.form-control(required v-model="pin" type='password' placeholder="Pin-code")
      button.btn.btn-default Submit
</template>
<script>
  export default {
    data() {
      return {
        pin: '',
      };
    },
    methods: {
      login: function() {
        const pin = this.pin;
        this.$store.dispatch('login', { pin })
          .then(() => this.$router.push('/photos'))
          .catch(err => console.log(err));
      },
    },
};
</script>
<style scoped>
.form-control{
  color: #000;
  width: -webkit-fill-available;
}
.form-group{
  display: grid;
}
.flying{
  box-shadow: 10pt 10pt #000;
  margin-bottom: 20pt;
}
</style>
