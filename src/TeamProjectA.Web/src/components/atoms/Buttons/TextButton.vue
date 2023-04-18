<script setup lang='ts'>
defineProps<{ fullWidth?: boolean, variant?: 'primary' | 'secondary' }>()
</script>
<template>
  <v-btn
    :max-width='!fullWidth ? "300px" : ""'
    :width='fullWidth ? "100%" : ""'
    rounded='lg'
    :color='variant === "primary" ? "indigo" : ""'
  >
    <slot />
  </v-btn>
</template>
