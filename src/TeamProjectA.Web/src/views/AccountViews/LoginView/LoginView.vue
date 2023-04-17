<script setup lang='ts'>
import { useI18n } from 'vue-i18n'
import { useAccountStore } from '@/stores/account'
import CenteredBox from '@/components/molecules/CenteredBox/CenteredBox.vue'

const { t } = useI18n()

const tKey = 'loginView'

const accountStore = useAccountStore()

const goToHome = () => {
  accountStore.login()
}
</script>

<template>
  <CenteredBox>
    <div>
      <HeadlineL>
        {{ t(`${tKey}.title`) }}
      </HeadlineL>
      <TextButton @click='goToHome'>
        {{ t('test') }}
      </TextButton>
    </div>
  </CenteredBox>
</template>
