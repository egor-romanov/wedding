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
            th.col-xs-1.col-s-1.col-md-1 Image
            th.col-xs-3.col-s-3.col-md-6 Description
            th.col-xs-1.col-s-1.col-md-2 Comment
            th.hidden-xs.col-md-1 Coming
        tbody
          tr(v-for="guest in showGuests" :key="guest.id" :class="{ 'active': key == $route.name }")
            router-link(:to="{ name: 'guest', params: { id: guest.id }}") {{ guest.name }}
            td {{ guest.image }}
            td {{ guest.comments }}
            td
              button.hidden-xs.btn.btn-success.dropdown-toggle(type="button") Add comment
              button.visible-xs.btn-mini.btn-success.btn-xs.dropdown-toggle(type="button") Add ✍️
            td.hidden-xs(v-if='guest.accept') ➕
            td.hidden-xs(v-else) ➖
</template>

<script>
export default {
  data() {
    return {
      filter: '',
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
  mounted() {
    this.showGuests = this.guests;
  },
  methods: {
    search() {
      this.showGuests = this.guests.filter(g => g.name.toLowerCase().indexOf(this.filter.toLowerCase()) > -1);
    },
  },
};
</script>
<style scoped>
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
