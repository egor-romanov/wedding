<template lang="pug">
  .hello
    h1
      strong.text-danger(v-if='name2') Дорогие {{ name1 }} и {{ name2 }}!
      strong.text-danger(v-else) Дорогой(-ая) {{ name1 }}!
    span Приглашаем вас на празднование нашей свадьбы, которое состоится 29 августа в 17:00. Место проведения — ресторан «Ферма Бенуа», Тихорецкий проспект 17. Просьба приехать без опозданий.<br><br>
    span Будем рады разделить с вами наш день &lt;3 <br><br>
    span На нашем портале вы можете найти всю необходимую информацию о мероприятии:<br>
    span ⁃ Покопаться в списке гостей (оставить пару ласковых комментариев о своих друзьях — приветствуется:)<br>
    span ⁃ Свериться со списком подарков<br>
    span ⁃ Заказать свою любимую песню у диджея<br>
    span ⁃ Узнать информацию о мероприятии<br>
    span ⁃ Посмотреть фото (если ты не Марти Макфлай и профессор Браун, то с этим пунктом придётся немного подождать :р )<br>
    span ⁃ Список контактов по горячим вопросам<br>
    span ⁃ Посмотреть карту сайта<br>
    span <br>
    span С уважением, Наталья и Егор<br>
    .btn-group(role="group" aria-label="...")
      button.btn(type="button" :class="accept == false ? 'btn-danger' : 'btn-default'" @click='setComing(false)') Не смогу прийти
      button.btn(type="button" :class="accept ? 'btn-success' : 'btn-default'" @click='setComing(true)') Приду
</template>

<script>
import invitationApi from '../api/invitationApi';

export default {
  data() {
    return {
      name1: '',
      name2: '',
      accept: null,
      msg: 'sdfasd',
    };
  },
  async created() {
    await this.getGuestData(this.$route.params.id);
  },
  methods: {
    async getGuestData(secret) {
      const data = await invitationApi.getInvitationById(secret);
      if (data && data.length > 0) {
        this.name1 = data[0].name;
        if (data.length > 1) {
          this.name2 = data[1].name;
        }
      } else {
        return;
      }

      this.accept = data[0].accepted;
    },
    async setComing(accepted) {
      await invitationApi.setComingById(this.$route.params.id, accepted);

      await this.getGuestData(this.$route.params.id);
    },
  },
};
</script>
<style scoped>
.btn-group{
  margin-top: 20pt;
}
</style>
