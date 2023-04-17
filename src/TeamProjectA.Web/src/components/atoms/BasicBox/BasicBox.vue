<script setup lang='ts'>
defineProps<{ height?: string, width?: string }>()
</script>
<template>
  <v-sheet
    border
    rounded='xl'
    :elevation='15'
    :height='height ?? "auto"'
    :width='width ?? "auto"'
  >
    <slot />
  </v-sheet>
</template>