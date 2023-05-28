<script setup lang='ts'>
defineProps<{ icon: string, variant?: 'positive' | 'default' | 'negative' | 'primary' }>()
</script>
<template>
  <v-btn
    :icon='icon'
    variant='plain'
    :ripple='false'
    :color='variant === "positive" ? "green" : variant === "negative" ? "red" : variant === "primary" ? "indigo" : "" '
  />
</template>
