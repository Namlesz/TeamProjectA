<script setup lang="ts">
import { useI18n } from 'vue-i18n'
import router from '@/router'
import { useAccountStore } from '@/stores/account'

const { t } = useI18n()

const tKey = 'loginView'

const accountStore = useAccountStore()

const goToHome = () => {
  accountStore.login()
}
</script>

<template>
  <v-sheet border rounded :height="500" :width="500">
    <div>
      <HeadlineL>{{ t(`${tKey}.title`) }}</HeadlineL>
      <Button @click="goToHome">{{ t('test') }}</Button>
    </div>
  </v-sheet>
</template>
