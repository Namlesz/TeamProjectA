<script setup lang='ts'>
import { useI18n } from 'vue-i18n'
import UserListVirtualScroll from '@/components/organisms/UserListVirtualScroll/UserListVirtualScroll.vue'
import router from '@/router'
import { useUserListStore } from '@/stores/userList'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { useField, useForm } from 'vee-validate'
import TextFieldWithValidation from '@/components/atoms/TextFieldWithValidation/TextFieldWithValidation.vue'
import { object, string } from 'yup'
import { useQuery } from '@tanstack/vue-query'
import axios from 'axios'
import { ref } from 'vue'
import type { FriendDto } from '@/types/dto/FriendDto'
import TextBody from '@/components/atoms/Typography/TextBody.vue'

const { t } = useI18n()
const userListStore = useUserListStore()

const schema = object({
  friendName: string().required(t('errors.nickname-is-empty-error')),
})

const { handleSubmit } = useForm({
  validationSchema: schema,
})

const friendName = useField('friendName')

const friends = ref<FriendDto[]>()

const { refetch: getTrainers, isFetching, isFetched, isError, data } = useQuery({
  queryKey: ['getTrainers'],
  queryFn: () => axios.get('/api/Trainer/SearchTrainer', {
    headers: {
      Authorization: 'Bearer ' + localStorage.getItem('userToken'),
    },
    params: {
      Login: friendName.value.value,
    },
  }),
  select: (response) => response.data,
  enabled: false,
})

const submit = handleSubmit(async () => {
  console.log(friendName)

  await getTrainers()

  if (isFetched.value) {
    if (isError.value) {
      return
    }

    friends.value = data.value
  }
})

const goToFriendDetails = () => {
  router.push({ name: 'friend', params: { name: userListStore.selectedUser?.login } })
}
</script>
<template>
  <HeadlineL>{{ t('friends-list') }}</HeadlineL>
  <v-form
    class='ma-5'
    @submit.prevent='submit'
  >
    <HeadlineXS>{{ t('search-friend') }}</HeadlineXS>
    <div class='d-flex align-center justify-center'>
      <TextFieldWithValidation
        name='friendName'
        :label='t(`form.friend-name`)'
      />
      <TextButton
        variant='primary'
        type='submit'
        class='ml-5'
      >
        {{ t('search') }}
      </TextButton>
    </div>
  </v-form>
  <UserListVirtualScroll
    v-if='friends'
    :items='friends'
    clickable-row
    :is-loading='isFetching'
    @on-list-item-click='goToFriendDetails'
  />
  <div
    v-else
    class='d-flex justify-center align-center flex-column'
  >
    <v-icon icon='mdi-text-search' />
    <TextBody>
      {{ t('information') }}
    </TextBody>
  </div>
</template>
<i18n>{
  "en": {
    "form": {
      "friend-name": "Friend name"
    },
    "friends-list": "Friends list",
    "information": "Enter a user name in the search box to display a list of friends",
    "search-friend": "Search friends"
  },
  "pl": {
    "form": {
      "friend-name": "Nazwa znajomego"
    },
    "friends-list": "Lista znajomych",
    "information": "Wpisz nazwę użytkownika w polu wyszukiwania, aby wyświetlić listę znajomych",
    "search-friend": "Szukaj znajomych"
  }
}</i18n>
