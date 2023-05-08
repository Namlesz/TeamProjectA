<script setup lang='ts'>
import { useI18n } from 'vue-i18n'
import UserListVirtualScroll from '@/components/organisms/UserListVirtualScroll/UserListVirtualScroll.vue'
import router from '@/router'
import { useUserListStore } from '@/stores/userList'

type Friend = {
  name: string
  initials: string
}

const { t } = useI18n()
const userListStore = useUserListStore()

// TODO delete when data will be fetched from backend
const friends: Friend[] = [
  {
    name: 'Trener Testowy',
    initials: 'TT',
  },
]

const goToFriendDetails = () => {
  router.push({ name: 'friend', params: { name: userListStore.selectedUser } })
}
</script>
<template>
  <HeadlineL>{{ t('friends-list') }}</HeadlineL>
  <UserListVirtualScroll
    :items='friends'
    clickable-row
    @on-list-item-click='goToFriendDetails'
  />
</template>
<i18n>
{
  "pl": {
    "friends-list": "Lista znajomych"
  },
  "en": {
    "friends-list": "Friends list"
  }
}
</i18n>
