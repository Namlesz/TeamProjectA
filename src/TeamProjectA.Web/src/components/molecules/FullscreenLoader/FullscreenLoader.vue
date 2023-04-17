<script setup lang='ts'>
defineProps<{ isLoading: boolean }>()
</script>
<template>
  <v-overlay
    :model-value='isLoading'
    class='align-center justify-center'
  >
    <ProgressCircular />
  </v-overlay>
</template>