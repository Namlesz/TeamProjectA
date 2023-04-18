<script setup lang='ts'>
defineProps<{ height?: string, width?: string }>()
</script>
<template>
  <div class='fill-height d-flex'>
    <BasicBox
      class='mx-auto my-auto d-flex flex-column'
      :height='height ?? "auto"'
      :width='width ?? "auto"'
    >
      <slot />
    </BasicBox>
  </div>
</template>