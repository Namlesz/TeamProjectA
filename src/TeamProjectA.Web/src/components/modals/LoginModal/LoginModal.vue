<script setup lang='ts'>
import CenteredModal from '@/components/organisms/CenteredModal/CenteredModal.vue'
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import { useI18n } from 'vue-i18n'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { useQuery } from '@tanstack/vue-query'
import axios from 'axios'
import { useField, useForm } from 'vee-validate'
import { useAccountStore } from '@/stores/account'
import { useToasterStore } from '@/stores/toaster'
import { object, string } from 'yup'
import TextFieldWithValidation from '@/components/atoms/TextFieldWithValidation/TextFieldWithValidation.vue'

defineEmits(['on-close'])

const { t } = useI18n()
const accountStore = useAccountStore()
const toasterStore = useToasterStore()

const schema = object({
  nickname: string().required(t('errors.nickname-is-empty-error')),
})

const { handleSubmit } = useForm({
  validationSchema: schema,
})

const nickname = useField('nickname')

const { refetch, isFetching, isFetched, isError, data } = useQuery({
  queryKey: ['loginUser'],
  queryFn: () => axios.post('/api/Auth/Login', null, {
    params: {
      login: nickname.value.value,
    },
  }),
  select: (response) => response.data,
  enabled: false,
})

const submit = handleSubmit(async () => {
  await refetch()

  if (isFetched.value) {
    if (isError.value) {
      toasterStore.triggerToaster(t('errors.internal-server-error'), 'error')

      return
    }

    accountStore.login(data.value.token)
  }
})

</script>
<template>
  <CenteredModal
    height='380px'
    width='400px'
    @on-close='$emit("on-close")'
  >
    <template #title>
      {{ t('title') }}
    </template>
    <template #body>
      <TextBody class='text-justify'>
        {{ t('body') }}
      </TextBody>
      <form
        @submit.prevent='submit'
      >
        <TextFieldWithValidation
          name='nickname'
          :label='t("form.nickname")'
          :loading='isFetching'
        />
        <TextButton
          full-width
          variant='primary'
          type='submit'
          class='mt-5'
        >
          {{ t('button') }}
        </TextButton>
      </form>
    </template>
  </CenteredModal>
</template>
<i18n>{
  "en": {
    "body": "All you need to do is provide us with your nickname to get started on your training adventure.",
    "button": "Let's go!",
    "form": {
      "nickname": "Nickname"
    },
    "title": "hey"
  },
  "pl": {
    "body": "Wystarczy, że podasz nam swoją nazwę użytkownika, aby rozpocząć przygodę z treningami.",
    "button": "Do dzieła!",
    "form": {
      "nickname": "Nazwa użytkownika"
    },
    "title": "Hej"
  }
}</i18n>