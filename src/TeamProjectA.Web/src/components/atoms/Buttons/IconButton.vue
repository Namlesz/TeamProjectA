<script setup lang='ts'>
defineProps<{ icon: string, variant?: 'positive' | 'default' }>()
</script>
<template>
  <v-btn
    :icon='icon'
    variant='plain'
    :ripple='false'
    :color='variant === "positive" ? "green" : "" '
  />
</template>
