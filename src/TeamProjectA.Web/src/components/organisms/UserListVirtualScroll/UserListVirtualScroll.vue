<script setup lang='ts'>
import UserListItem from '@/components/molecules/UserListItem/UserListItem.vue'
import { useUserListStore } from '@/stores/userList'
import ActionButton from '@/components/molecules/Buttons/ActionButton.vue'
import type { UserDto } from '@/types/dto/UserDto'
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import { useI18n } from 'vue-i18n'
import ProgressCircular from '@/components/atoms/ProgressCircular/ProgressCircular.vue'

type Action = {
  icon: string,
  name: string
}

defineProps<{
  items: any[],
  primaryAction?: Action,
  secondaryAction?: Action,
  clickableRow?: boolean,
  isLoading?: boolean
}>()
const emit = defineEmits(['onPrimaryAction', 'onSecondaryAction', 'onListItemClick'])

const { t } = useI18n()
const userListStore = useUserListStore()

const handleClickUser = (user: UserDto) => {
  userListStore.setSelectedUser(user)
  emit('onListItemClick')
}

</script>
<template>
  <div
    v-if='isLoading'
    class='d-flex align-center justify-center'
  >
    <ProgressCircular />
  </div>
  <v-virtual-scroll
    v-else-if='items.length >= 1'
    :items='items'
    item-height='48'
  >
    <template #default='{ item }'>
      <UserListItem
        :initials='item.initials ?? "TT"'
        :name='item.login'
        :description='item.description'
        v-on='clickableRow && {click: () => handleClickUser(item)}'
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

  <div
    v-else
    class='d-flex justify-center align-center flex-column'
  >
    <v-icon icon='mdi-alert-circle' />
    <TextBody>
      {{ t('errors.not-found-error') }}
    </TextBody>
  </div>
</template>