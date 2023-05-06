<script setup lang='ts'>
import UserListItem from '@/components/molecules/UserListItem/UserListItem.vue'
import IconButton from '@/components/atoms/Buttons/IconButton.vue'
import TextButtonWithIcon from '@/components/atoms/Buttons/TextButtonWithIcon.vue'
import { useDisplay } from 'vuetify'

const { mobile } = useDisplay()

type Action = {
  icon: string,
  name: string
}

defineProps<{ items: any[], primaryAction: Action, secondaryAction?: Action }>()
defineEmits(['onPrimaryAction', 'onSecondaryAction'])

</script>
<template>
  <v-virtual-scroll
    :items='items'
    item-height='48'
  >
    <template #default='{ item }'>
      <UserListItem
        :initials='item.initials'
        :name='item.name'
        :description='item.description'
      >
        <template #actions>
          <TextButtonWithIcon
            v-if='!mobile'
            variant='positive'
            :icon='primaryAction.icon'
            @click='$emit("onPrimaryAction")'
          >
            {{ primaryAction.name }}
          </TextButtonWithIcon>
          <IconButton
            v-if='mobile'
            :icon='primaryAction.icon'
            variant='positive'
          />
          <TextButtonWithIcon
            v-if='secondaryAction && !mobile'
            :icon='secondaryAction.icon'
            variant='negative'
            class='mx-1'
          >
            {{ secondaryAction.name }}
          </TextButtonWithIcon>
          <IconButton
            v-if='secondaryAction && mobile'
            :icon='secondaryAction.icon'
            variant='negative'
          />
        </template>
      </UserListItem>
    </template>
  </v-virtual-scroll>
</template>