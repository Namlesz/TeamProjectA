<script setup lang="ts">
import { useI18n } from 'vue-i18n'

const { t } = useI18n()

const tKey = 'registerView'
</script>

<template>
  <v-sheet border rounded :height="500" :width="500">
    <div>
      <HeadlineL>{{ t(`${tKey}.title`) }}</HeadlineL>
      <Button>{{ t('test') }}</Button>
    </div>
  </v-sheet>
</template>
