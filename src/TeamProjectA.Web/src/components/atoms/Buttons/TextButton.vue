<script setup lang='ts'>
defineProps<{ fullWidth?: boolean, variant?: 'primary' | 'secondary' | 'positive' }>()
</script>
<template>
  <v-btn
    :max-width='!fullWidth ? "300px" : ""'
    :width='fullWidth ? "100%" : ""'
    rounded='lg'
    :color='variant === "primary" ? "indigo" : variant === "positive" ? "green" : ""'
  >
    <slot />
  </v-btn>
</template>
