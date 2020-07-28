<template lang='pug'>
  nav.navbar.navbar-default
    .container-fluid
      .navbar-header
        button.navbar-toggle(type="button" data-toggle="collapse" :class='navExpanded ? "" : "collapsed"' @click='toggleNav' data-target="#navbar" :aria-expanded='navExpanded ? "true" : "false"' aria-controls="navbar-wed")
          span.sr-only Toggle navigation
          span.icon-bar
          span.icon-bar
          span.icon-bar
        a.navbar-brand(href="/") Свадьба Романовых
      .collapse(id="navbar-wed" :style='navExpanded ? "" : "height: 1px;"' :aria-expanded='navExpanded ? "true" : "false"' :class='navExpanded ? "in" : ""')
        ul.nav.navbar-nav
          li(v-for="(link, key) in links" :key="key" :class="{ 'active': key == $route.name }")
            router-link(:to="link.to") {{ link.text }}
          li.dropdown(:class='photosExpanded && "open"')
            a.dropdown-toggle(href="#" @click='togglePhoto' data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false") Photos
              span.caret
            ul.dropdown-menu
              li.divider(role='separator')
              li
                a(href="#") Coming soon...
              li.divider(role='separator')
</template>

<script>
export default {
  data() {
    return {
      navExpanded: true,
      photosExpanded: false,
      windowWidth: window.innerWidth,
      links: {
        home: { to: '/', text: 'Home' },
        info: { to: '/info', text: 'Info' },
        guests: { to: '/guests', text: 'Guests' },
        contact: { to: '/contact', text: 'Contact' },
        giftList: { to: '/gifts', text: 'Gift List' },
      },
    };
  },
  watch: {
    windowWidth(newWidth, oldWidth) {
      if (newWidth < 768) {
        this.navExpanded = false;
      } else {
        this.navExpanded = true;
      }
    },
  },
  mounted() {
    this.$nextTick(() => {
      window.addEventListener('resize', this.onResize);
    });
  },
  beforeDestroy() {
    window.removeEventListener('resize', this.onResize);
  },
  methods: {
    toggleNav() {
      this.navExpanded = !this.navExpanded;
    },
    togglePhoto() {
      this.photosExpanded = !this.photosExpanded;
      this.photosExpanded && setTimeout(this.togglePhoto, 3000);
    },
    onResize() {
      this.windowWidth = window.innerWidth;
    },
  },
};
</script>

<style scoped>
.dropdown-menu .dropdown-item > li > a:hover {
  background-image: none;

  background-color: #000!important;
}
.dropdown-content a:hover {
    background-color: transparent;
}
</style>
