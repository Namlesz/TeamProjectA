<script setup lang='ts'>
import TextCaption from '@/components/atoms/Typography/TextCaption.vue'
import { useDisplay } from 'vuetify'

const { mobile } = useDisplay()

defineProps<{ initials: string, name: string, description?: string }>()
</script>
<template>
  <v-list-item
    border
    rounded='lg'
    class='mx-5 my-2'
  >
    <template #prepend>
      <v-avatar
        color='red'
        class='text-white'
        size='60'
      >
        {{ initials }}
      </v-avatar>
    </template>
    <div class='d-flex flex-column'>
      <v-list-item-title>{{ name }}</v-list-item-title>
      <TextCaption v-if='!mobile'>
        {{ description }}
      </TextCaption>
    </div>
    <template #append>
      <slot name='actions' />
    </template>
  </v-list-item>
</template>