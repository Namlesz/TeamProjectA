<script setup lang='ts'>
import { useI18n } from 'vue-i18n'
import LoginModal from '@/components/modals/LoginModal/LoginModal.vue'
import { ref } from 'vue'

const { t } = useI18n()

const openLoginModal = ref<boolean>(false)

const goToLogin = () => {
  openLoginModal.value = true
}

const closeModal = () => {
  openLoginModal.value = false
}

</script>
<template>
  <HeadlineL>Landing Page TODO PZ-13</HeadlineL>
  <TextButton @click='goToLogin'>
    {{ t('login') }}
  </TextButton>
  <LoginModal
    v-model='openLoginModal'
    @on-close='closeModal'
  />
</template>
<i18n>{
  "en": {
    "login": "Login"
  },
  "pl": {
    "login": "Zaloguj się"
  }
}</i18n>