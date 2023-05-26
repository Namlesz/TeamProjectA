<script setup lang='ts'>

import BasicModal from '@/components/atoms/BasicModal/BasicModal.vue'
import CenteredBox from '@/components/molecules/CenteredBox/CenteredBox.vue'
import IconButton from '@/components/atoms/Buttons/IconButton.vue'
import HeadlineL from '@/components/atoms/Typography/HeadlineL.vue'

defineProps<{ height?: string, width?: string }>()
defineEmits(['on-close'])
</script>
<template>
  <BasicModal>
    <CenteredBox
      :width='width ?? "auto"'
      :height='height ?? "auto"'
      max-width='600px'
      max-height='750px'
    >
      <div class='position-absolute align-self-end'>
        <IconButton
          icon='mdi-close'
          @click='$emit("on-close")'
        />
      </div>
      <div class='d-flex flex-column align-center fill-height px-lg-5'>
        <HeadlineL class='mx-12 my-2 text-center'>
          <slot name='title' />
        </HeadlineL>
        <div class='mx-5 mb-10 px-5 d-flex flex-column justify-space-between fill-height w-100'>
          <slot name='body' />
        </div>
      </div>
    </CenteredBox>
  </BasicModal>
</template>