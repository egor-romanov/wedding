<template lang='pug'>
  .col.col-sm-12.col-md-8
    .row
      .caption
        .thumbnail.bs-callout-info.bs-callout
          div
            img.col-sm-12.col-md-4(:src='guest.imagePath')
            h3.text-danger {{ guest.name }}
            span(v-for='comment in guest.comments') - {{ comment }}
              br
              br
            .navbar-right(style='height: 100%;')
              p
                a.btn.btn-success(@click='showComment' role='button') Add comment
    .panel.panel-primary.row.col-xs-12.col-s-12.col-md-12.flying(v-if='showCommentFlag')
      .panel-body.row
        p.col-xs-12.col-md-12 Тут можно анонимно оставить пару слов о знакомом )
      .navbar-form.row(role="submit")
        .form-group.col-xs-12.col-md-9
          input.form-control(type="text"
              placeholder="Помню, как-то раз в тайге мы..."
              v-model.trim='line'
              id='line'
              @input="$v.line.$touch()"
              :class="{ 'is-danger': $v.line.$error }")
          p.help(v-if="$v.line.$error && !$v.line.required") Обязательное поле
          p.help(v-if="!$v.line.minLength") Комментарий должен быть длиннее {{$v.line.$params.minLength.min}} букв.
          p.help(v-if="!$v.line.maxLength") Комментарий должен быть короче {{$v.line.$params.maxLength.max}} букв.
          p.help(v-if="!$v.line.$error") Введите комментарий
        button.btn.btn-default.col-md-2(@click='addComment') Submit
    nav
      ul.pager
        li(:class='guest.id < 2 && "disabled"')
          router-link(:event="guest.id > 1 ? 'click' : ''" :to="{ name: 'guest', params: { id: guest.id - 1 }}") Previous
        li(:class='guest.id > guestsNumber - 1 && "disabled"')
          router-link(:event="guest.id < guestsNumber ? 'click' : ''" :to="{ name: 'guest', params: { id: guest.id + 1 }}") Next
</template>

<script>
import guestsApi from '../api/guestsApi';
import { required, minLength, maxLength } from 'vuelidate/lib/validators';

export default {
  props: ['id', 'comment'],
  data() {
    return {
      showCommentFlag: false,
      guestsNumber: 67,
      line: '',
      guest: {},
    };
  },
  validations: {
    line: {
      required,
      minLength: minLength(4),
      maxLength: maxLength(300),
    },
  },
  watch: {
    // will fire on route changes
    // '$route.params.id': function(val, oldVal){ // Same
    '$route.path': async function(val, oldVal) {
      await this.getGuest();
    },
  },
  async mounted() {
    if (this.comment) {
      this.showCommentFlag = true;
    }
    await this.getGuest();
    await this.listGuests();
  },
  methods: {
    search() {
      this.showGuests = this.guests.filter(g => g.name.toLowerCase().indexOf(this.filter.toLowerCase()) > -1);
    },
    async addComment() {
      this.$v.$touch();
      if (this.$v.$invalid) {
        return;
      }
      await guestsApi.addGuestLine(this.guest.id, this.line);

      await this.getGuest();
      this.line = '';
      this.hideComment();
    },
    async getGuest() {
      this.guest = await guestsApi.getGuestById(this.id);
    },
    showComment() {
      this.showCommentFlag = true;
    },
    hideComment() {
      this.showCommentFlag = false;
    },
    async listGuests() {
      const guests = await guestsApi.listGuests();
      this.guestsNumber = guests.length;
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
