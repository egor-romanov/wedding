<template lang='pug'>
  .contact.row.jumbotron
    h1
      strong.text-danger Contacts
    .panel.panel-primary.col-xs-12.col-s-12.col-md-8
      .panel-heading Список контактов
      .panel-body
        p Если вы потерялись или у вас поменялись планы, пожалуйста свяжитесь с нами :)
      table.table
        thead
          tr
            th.col-xs-1.col-s-1.col-md-1 #
            th.col-xs-3.col-s-3.col-md-2 Name
            th.col-xs-5.col-s-5.col-md-3 Telegram
            th.col-xs-3.col-s-3.col-md-2 Phone
        tbody
          tr
            td 1
            td Natasha
            td
              a(href='https://t.me/zabelinanatalia') @zabelinanatalia
            td +7 (981) 781-3453
          tr
            td 2
            td Egor
            td
              a(href='https://t.me/eromanov') @eromanov
            td +7 (999) 202-3902
          tr
            td 3
            td Official channel
            td
              a(href='https://t.me/joinchat/BMQDDBPzZkzax6o30VwIVQ') tgchannel
            td
</template>

<script>
export default {
  data() {
    return {
    };
  },
};
</script>
<style scoped>
.table {
  word-wrap:break-word;
}
</style>
