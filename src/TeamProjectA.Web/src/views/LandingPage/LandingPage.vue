<script setup lang="ts">
import router from "@/router";
import {useI18n} from "vue-i18n";

const tKey = 'landing-page'

const { t } = useI18n()

const goToLogin = () => {
  router.push({name: 'login'})
}

const goToRegister = () => {
  router.push({name: 'register'})
}
</script>
<template>
  <HeadlineL>Landing Page TODO PZ-13</HeadlineL>
  <Button @click="goToLogin">{{t(`${tKey}.login`)}}</Button>
  <Button @click="goToRegister">{{t(`${tKey}.register`)}}</Button>
</template>