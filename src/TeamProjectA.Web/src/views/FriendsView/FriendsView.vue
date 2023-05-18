<script setup lang='ts'>
import { useI18n } from 'vue-i18n'
import UserListVirtualScroll from '@/components/organisms/UserListVirtualScroll/UserListVirtualScroll.vue'
import router from '@/router'
import { useUserListStore } from '@/stores/userList'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { useField, useForm } from 'vee-validate'

type Friend = {
  name: string
  initials: string
}

const { handleSubmit } = useForm({
  validationSchema: {
    friendName(value: string) {
      if (value) return true

      return t('errors.nickname-is-empty-error')
    },
  },
})

const { t } = useI18n()
const userListStore = useUserListStore()

const friendName = useField('friendName')
const isFetching = false // TODO handle isFetching

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

const searchFriend = () => {
  // TODO get friends list
}

const submitFriendSearch = handleSubmit(() => {
  searchFriend()
})
</script>
<template>
  <HeadlineL>{{ t('friends-list') }}</HeadlineL>
  <form
    fast-fail
    class='ma-5'
    @submit.prevent='submitFriendSearch'
  >
    <HeadlineXS>{{ t('search-friend') }}</HeadlineXS>
    <div class='d-flex align-center justify-center'>
      <v-text-field
        v-model='friendName.value.value'
        :error-messages='friendName.errorMessage.value ?? ""'
        :label='t(`form.friend-name`)'
        :loading='isFetching'
        name='trainerName'
      />
      <TextButton
        variant='primary'
        type='submitTrainer'
        class='ml-5'
      >
        {{ t('search') }}
      </TextButton>
    </div>
  </form>
  <UserListVirtualScroll
    :items='friends'
    clickable-row
    @on-list-item-click='goToFriendDetails'
  />
</template>
<i18n>{
  "en": {
    "form": {
      "friend-name": "Friend name"
    },
    "friends-list": "Friends list",
    "search-friend": "Search friends"
  },
  "pl": {
    "form": {
      "friend-name": "Nazwa znajomego"
    },
    "friends-list": "Lista znajomych",
    "search-friend": "Szukaj znajomych"
  }
}</i18n>
