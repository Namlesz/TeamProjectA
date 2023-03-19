<script setup lang='ts'>
defineProps<{ icon?: string }>()
</script>
<template>
  <v-btn :icon='icon' />
</template>
