<script setup lang='ts'>
import IconButton from '@/components/atoms/Buttons/IconButton.vue'
import TextButtonWithIcon from '@/components/atoms/Buttons/TextButtonWithIcon.vue'
import { useDisplay } from 'vuetify'

defineProps<{ name: string, icon: string, variant: 'positive' | 'negative' }>()
defineEmits(['onAction'])

const { mobile } = useDisplay()
</script>
<template>
  <TextButtonWithIcon
    v-if='!mobile'
    :variant='variant'
    :icon='icon'
    class='mx-1'
    @click='$emit("onAction")'
  >
    {{ name }}
  </TextButtonWithIcon>
  <IconButton
    v-if='mobile'
    :icon='icon'
    :variant='variant'
    @click='$emit("onAction")'
  />
</template>