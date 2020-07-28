<template lang='pug'>
  .row
    .col-sm-6.col-md-4
      .thumbnail
        img
        .caption
          h3 {{ guest.name }}
          p {{ guest.comments }}
          p
            a.btn.btn-primary(href='#' role='button') Button
            a.btn.btn-default(href='#' role='button') Button
</template>

<script>
export default {
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
  methods: {
  },
};
</script>
