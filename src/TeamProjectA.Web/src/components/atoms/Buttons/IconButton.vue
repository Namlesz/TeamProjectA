<script setup lang='ts'>

defineProps<{ icon?: string, variant?: 'default' | 'noBackground' }>()

</script>
<template>
  <v-btn :icon='icon'
         variant='plain'
         :ripple='false'
  />
</template>
