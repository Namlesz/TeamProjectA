<script setup lang='ts'>
defineProps<{ height?: string, width?: string, maxWidth?: string, maxHeight?: string }>()
</script>
<template>
  <v-sheet
    border
    rounded='xl'
    :elevation='15'
    :height='height ?? "auto"'
    :width='width ?? "auto"'
    :max-width='maxWidth ?? "auto"'
    :max-height='maxHeight ?? "auto"'
    class='overflow-auto'
  >
    <slot />
  </v-sheet>
</template>