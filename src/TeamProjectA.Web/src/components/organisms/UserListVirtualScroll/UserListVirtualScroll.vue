<script setup lang='ts'>
import UserListItem from '@/components/molecules/UserListItem/UserListItem.vue'
import { useUserListStore } from '@/stores/userList'
import ActionButton from '@/components/molecules/Buttons/ActionButton.vue'

type Action = {
  icon: string,
  name: string
}

defineProps<{ items: any[], primaryAction?: Action, secondaryAction?: Action, clickableRow?: boolean }>()
const emit = defineEmits(['onPrimaryAction', 'onSecondaryAction', 'onListItemClick'])

const userListStore = useUserListStore()

const handleClickUser = (name: string) => {
  userListStore.setSelectedUser(name)
  emit('onListItemClick')
}

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
        v-on='clickableRow && {click: () => handleClickUser(item.name)}'
      >
        <template #actions>
          <ActionButton
            v-if='primaryAction'
            :name='primaryAction.name'
            :icon='primaryAction.icon'
            variant='positive'
          />
          <ActionButton
            v-if='secondaryAction'
            :name='secondaryAction.name'
            :icon='secondaryAction.icon'
            variant='negative'
          />
        </template>
      </UserListItem>
    </template>
  </v-virtual-scroll>
</template>