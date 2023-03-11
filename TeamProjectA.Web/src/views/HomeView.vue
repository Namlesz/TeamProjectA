<script setup lang='ts'>
import { useI18n } from 'vue-i18n'

const { t } = useI18n()
</script>

<template>
  <v-sheet border rounded :height='500' :width='500'>
    <div>
      <Button>{{ t('test') }}</Button>
    </div>
  </v-sheet>

</template>
<style lang='scss'>
.centeredBox {

}
</style>
