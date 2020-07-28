<template lang='pug'>
  .contact.jumbotron
    h1
      strong.text-danger Track request
    .panel.panel-primary.row.col-xs-12.col-s-12.col-md-8
      .panel-body.row
        p.col-xs-12.col-md-8 Закажи музыку, не стесняйся
      .navbar-form.navbar-right.col-xs-8.col-md-4(role="submit")
        .form-group
          label(for="name") Название
            input.form-control(type="text" placeholder="Шуфутинский - Натали" v-model.trim='sendSong' id='name')
          label(for="ordered") Кто заказал
            input.form-control(type="text" placeholder="Натали" v-model.trim='sendOrdered' id='ordered')
        button.btn.btn-default(@click='send') Submit
    .panel.panel-primary.row.col-xs-12.col-s-12.col-md-12
      .panel-heading Список заказов
      .panel-body.row
        p.col-xs-12.col-md-8
        .navbar-form.navbar-right.col-xs-8.col-md-4(role="search")
          .form-group
            input.form-control(type="text" placeholder="Search" v-model.trim='filter' @keyup.enter='search')
          button.btn.btn-default(@click='search') Submit
      table.table
        thead
          tr
            th.col-xs-1.col-md-1 Id
            th.col-xs-4.col-md-4 Name
            th.col-xs-4.col-md-4 Ordered By
        tbody
          tr(v-for="song in showSongs" :key="song.id" :class="{ 'active': key == $route.name }")
            td {{ song.id }}
            td {{ song.name }}
            td {{ song.ordered }}

</template>

<script>
export default {
  data() {
    return {
      filter: '',
      songs: [
        {
          id: 1,
          name: 'Шуфутинский - Натали',
          ordered: 'Натали',
        },
      ],
      showSongs: [],
    };
  },
  mounted() {
    this.showSongs = this.songs;
  },
  methods: {
    search() {
      this.showSongs = this.songs.filter(g => g.name.toLowerCase().indexOf(this.filter.toLowerCase()) > -1);
    },
    send() {

    },
  },
};
</script>
<style scoped>
label {
  margin-left: 10pt;
}
input {
  margin-left: 5pt;
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
