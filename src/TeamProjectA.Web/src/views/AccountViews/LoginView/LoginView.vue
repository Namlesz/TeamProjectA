<script setup lang='ts'>
import { useI18n } from 'vue-i18n'
import { useAccountStore } from '@/stores/account'

const { t } = useI18n()

const tKey = 'loginView'

const accountStore = useAccountStore()

const goToHome = () => {
  accountStore.login()
}
</script>

<template>
  <v-sheet
    border
    rounded
    :height='500'
    :width='500'
  >
    <div>
      <HeadlineL>
        {{ t(`${tKey}.title`) }}
      </HeadlineL>
      <TextButton @click='goToHome'>
        {{ t('test') }}
      </TextButton>
    </div>
  </v-sheet>
</template>
