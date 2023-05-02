<script setup lang='ts'>
import TextCaption from '@/components/atoms/Typography/TextCaption.vue'
import TextButtonWithIcon from '@/components/atoms/Buttons/TextButtonWithIcon.vue'
import { useDisplay } from 'vuetify'
import IconButton from '@/components/atoms/Buttons/IconButton.vue'

const { mobile } = useDisplay()

defineProps<{ initials: string, name: string, description: string, actionName: string }>()
defineEmits(['onAction'])

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
      <TextButtonWithIcon
        v-if='!mobile'
        variant='positive'
        icon='mdi-plus'
        @click='$emit("onAction")'
      >
        {{ actionName }}
      </TextButtonWithIcon>
      <IconButton
        v-if='mobile'
        icon='mdi-plus'
        variant='positive'
      />
    </template>
  </v-list-item>
</template>