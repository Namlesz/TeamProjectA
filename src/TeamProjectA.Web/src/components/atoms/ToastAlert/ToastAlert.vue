<script setup lang='ts'>
defineProps<{ message: string, variant: 'success' | 'info' | 'warning' | 'error' }>()
</script>
<template>
  <v-snackbar
    location='top right'
    timeout='2000'
    variant='text'
  >
    <v-alert :type='variant'>
      {{ message }}
    </v-alert>
  </v-snackbar>
</template>