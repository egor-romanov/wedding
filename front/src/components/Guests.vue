<template lang='pug'>
  .contact.jumbotron
    h1
      strong.text-danger Guests
    .panel.panel-primary.row.col-xs-12.col-s-12.col-md-12
      .panel-heading Список гостей
      .panel-body.row
        p.col-xs-12.col-md-8 Можно посмотреть, кто будет на мероприятии, а также добавить важную информацию о тех, кого вы знаете :)
        .navbar-form.navbar-right.col-xs-8.col-md-4(role="search")
          .form-group
            input.form-control(type="text" placeholder="Search" v-model.trim='filter' @keyup.enter='search')
          button.btn.btn-default(@click='search') Submit
      table.table
        thead
          tr
            th.col-xs-2.col-s-2.col-md-2 Name
            th.hidden-xs.col-s-1.col-md-1 Image
            th.col-xs-3.col-s-3.col-md-6 Description
            th.col-xs-1.col-s-1.col-md-2 Comment
            th.hidden-xs.hidden-sm.col-md-1 Coming
        tbody
          tr(v-for="guest in showGuests" :key="guest.id" :class="{ 'active': key == $route.name }")
            td
              router-link(:to="{ name: 'guest', params: { id: guest.id }}") {{ guest.name }}
            td.hidden-xs
              img(:src='guest.imagePath')
            td.visible-lg
              pre(style='max-width: 50rem;') {{ guest.comments.length > 0 ? guest.comments.join('\r\n') : 'Тут пока никто не написал :(' }}
              div(style='width: 100%; text-align: right;')
                router-link(:to="{ name: 'guest', params: { id: guest.id }}", v-if='guest.comments.length > 0')  Читать дальше...
            td.visible-md
              pre(style='max-width: 40rem;') {{ guest.comments.length > 0 ? guest.comments.join('\r\n') : 'Тут пока никто не написал :(' }}
              div(style='width: 100%; text-align: right;')
                router-link(:to="{ name: 'guest', params: { id: guest.id }}", v-if='guest.comments.length > 0')  Читать дальше...
            td.visible-xs.visible-sm
              span {{ guest.comments.length > 0 ? guest.comments[0] : 'Тут пока никто не написал :(' }}
              br(v-if='guest.comments.length > 0')
              router-link(:to="{ name: 'guest', params: { id: guest.id }}", v-if='guest.comments.length > 0')  Читать дальше...
            td
              button.hidden-xs.btn.btn-success.dropdown-toggle(type="button") Add comment
              button.visible-xs.btn-mini.btn-success.btn-xs.dropdown-toggle(type="button") Add ✍️
            td.hidden-xs.hidden-sm(v-if='guest.accept') ➕
            td.hidden-xs.hidden-sm(v-else) ➖
</template>

<script>
import guestsApi from '../api/guestsApi';

export default {
  data() {
    return {
      filter: '',
      guestLine: '',
      guests: [
        {
          id: 1,
          name: 'Романов Егор',
          image: '',
          comments: 'Жених, синьор помидор',
          accept: true,
        },
      ],
      showGuests: [],
    };
  },
  async mounted() {
    await this.listGuests();
  },
  methods: {
    search() {
      this.showGuests = this.guests.filter(g => g.name.toLowerCase().indexOf(this.filter.toLowerCase()) > -1);
    },
    async addComment(id) {
      await guestsApi.addGuestLine(id, this.guestLine);

      this.guests = await guestsApi.listGuests();
      this.showGuests = this.guests;
    },
    async listGuests() {
      this.guests = await guestsApi.listGuests();
      this.showGuests = this.guests;
    },
  },
};
</script>
<style scoped>
img {
  width: 80pt;
}
.table {
  word-wrap:break-word;
}
.form-control{
  color: #000;
}
.btn-mini{
  box-shadow: 5px 5px #000;
}
</style>
