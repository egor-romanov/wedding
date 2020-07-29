<template lang='pug'>
  .col.col-sm-12.col-md-8
    .row
      .caption
        .thumbnail.bs-callout-info.bs-callout
          div
            img.col-sm-12.col-md-4(:src='guest.imagePath')
            h3.text-danger {{ guest.name }}
            span(v-for='comment in guest.comments') {{ comment }}
              br
              br
            .navbar-right(style='height: 100%;')
              p
                a.btn.btn-success(href='#' role='button') Add comment
    nav
      ul.pager
        li(:class='guest.id < 2 && "disabled"')
          router-link(v-if='guest.id > 1' :to="{ name: 'guest', params: { id: guest.id - 1 }}") Previous
          a(v-else) Previous
        li(:class='guest.id > 65 && "disabled"')
          router-link(v-if='guest.id < 66' :to="{ name: 'guest', params: { id: guest.id + 1 }}") Next
          a(v-else) Previous
</template>

<script>
import guestsApi from '../api/guestsApi';

export default {
  props: ['id'],
  data() {
    return {
      guest: {
        id: 1,
        name: 'Романов Егор',
        image: '',
        comments: 'Жених, синьор помидор',
        accept: true,
      },
    };
  },
  watch: {
    // will fire on route changes
    // '$route.params.id': function(val, oldVal){ // Same
    '$route.path': async function(val, oldVal) {
      console.log(this.$route.params.id);
      await this.getGuest();
    },
  },
  async mounted() {
    await this.getGuest();
  },
  methods: {
    search() {
      this.showGuests = this.guests.filter(g => g.name.toLowerCase().indexOf(this.filter.toLowerCase()) > -1);
    },
    async addComment(id) {
      await guestsApi.addGuestLine(id, this.guestLine);

      await this.getGuest();
    },
    async getGuest() {
      this.guest = await guestsApi.getGuestById(this.$route.params.id);
    },
  },
};
</script>
<style scoped>
.thumbnail {
  display: grid;
}
img {
  width: 200pt;
}
</style>
