<template lang='pug'>
  .contact.jumbotron
    h1
      strong.text-danger Track request
    .panel.panel-primary.row.col-xs-12.col-s-12.col-md-8.flying
      .panel-body.row
        p.col-xs-12.col-md-8 Закажи музыку, не стесняйся
      .navbar-form.navbar-right.col-xs-8.col-md-4(role="submit")
        .form-group
          label(for="name") Название
            input.form-control(type="text"
                placeholder="Шуфутинский - Натали"
                v-model.trim='sendSong'
                id='name'
                @input="$v.sendSong.$touch()"
                :class="{ 'is-danger': $v.sendSong.$error }")
            p.help(v-if="$v.sendSong.$error && !$v.sendSong.required") Обязательное поле
            p.help(v-if="!$v.sendSong.minLength") Название должно быть длиннее {{$v.sendSong.$params.minLength.min}} букв.
            p.help(v-if="!$v.sendSong.maxLength") Название должно быть короче {{$v.sendSong.$params.maxLength.max}} букв.
            p.help(v-if="!$v.sendSong.$error") Введите трек
          label(for="ordered") Кто заказал
            input.form-control(type="text"
                placeholder="Натали"
                v-model.trim='sendOrdered'
                id='ordered'
                @input="$v.sendOrdered.$touch()"
                :class="{ 'is-danger': $v.sendOrdered.$error }")
            p.help(v-if="$v.sendOrdered.$error && !$v.sendOrdered.required") Обязательное поле
            p.help(v-if="!$v.sendOrdered.minLength") Название должно быть длиннее {{$v.sendOrdered.$params.minLength.min}} букв.
            p.help(v-if="!$v.sendOrdered.maxLength") Название должно быть короче {{$v.sendOrdered.$params.maxLength.max}} букв.
            p.help(v-if="!$v.sendOrdered.$error") Введите свое имя
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
import { required, minLength, maxLength } from 'vuelidate/lib/validators';
import songsApi from '../api/songsApi';

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
      sendSong: '',
      sendOrdered: '',
    };
  },
  validations: {
    sendSong: {
      required,
      minLength: minLength(2),
      maxLength: maxLength(50),
    },
    sendOrdered: {
      required,
      minLength: minLength(2),
      maxLength: maxLength(30),
    },
  },
  async mounted() {
    this.songs = await songsApi.getSongs();
    this.showSongs = this.songs;
  },
  methods: {
    search() {
      this.showSongs = this.songs.filter(g => g.name.toLowerCase().indexOf(this.filter.toLowerCase()) > -1);
    },
    async send() {
      this.$v.$touch();
      if (this.$v.$invalid) {
        return;
      }

      await songsApi.addSong(this.sendSong, this.sendOrdered);

      this.sendSong = '';
      this.sendOrdered = '';

      this.songs = await songsApi.getSongs();
      this.showSongs = this.songs;
    },
  },
};
</script>
<style scoped>
.help {
  font-size: small;
  text-align: end;
}
.is-danger {
  border-color: #d43a4f;
  border-width: 2px;
}
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
.flying{
  box-shadow: 10pt 10pt #000;
  margin-bottom: 20pt;
}
</style>
