<template lang='pug'>
  .row
    .col-sm-12.col-md-8
      .thumbnail
        img
        .caption
          h3 {{ guest.name }}
          p {{ guest.comments }}
          p.navbar-right
            a.btn.btn-success(href='#' role='button') Add comment
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
