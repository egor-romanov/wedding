<template lang='pug'>
  .contact.row.jumbotron.col-xs-12.col-s-12.col-md-8
    h1
      strong.text-danger Список подарков
    panel.panel-default
      .panel-heading
        .panel-body
          ul.list-group
            li.list-group-item.active Саундбар Bose &lt;3
              span.badge ✔️
            li.list-group-item Cash
              span.badge ◽️
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
.list-group-item {
  border-bottom-width: 1px;
  border-bottom-color: #000;
}
.list-group-item .active {
  border-bottom-width: 1px;
  border-bottom-color: #000;
}
</style>
