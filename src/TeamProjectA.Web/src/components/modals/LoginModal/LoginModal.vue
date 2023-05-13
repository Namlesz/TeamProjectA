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

const { handleSubmit } = useForm({
  validationSchema: {
    nickname(value: string) {
      if (value) return true

      return t('common.errors.nickname-is-empty-error')
    },
  },
})

defineEmits(['on-close'])

const tKey = 'loginModal'
const { t } = useI18n()
const nickname = useField('nickname')
const accountStore = useAccountStore()
const toasterStore = useToasterStore()

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

const loginUser = async () => {
  await refetch()

  if (isFetched.value) {
    if (isError.value) {
      toasterStore.triggerToaster(t('common.errors.internal-server-error'), 'error')

      return
    }

    accountStore.login(data.value.token)
  }
}

const submit = handleSubmit(() => {
  loginUser()
})

</script>
<template>
  <CenteredModal
    height='380px'
    width='400px'
    @on-close='$emit("on-close")'
  >
    <template #title>
      {{ t(`${tKey}.title`) }}
    </template>
    <template #body>
      <TextBody class='text-justify'>
        {{ t(`${tKey}.body`) }}
      </TextBody>
      <form
        fast-fail
        @submit.prevent='submit'
      >
        <v-text-field
          v-model='nickname.value.value'
          :error-messages='nickname.errorMessage.value ?? ""'
          :label='t(`${tKey}.form.nickname`)'
          :loading='isFetching'
          name='nickname'
        />
        <TextButton
          full-width
          variant='primary'
          type='submit'
          class='mt-5'
        >
          {{ t(`${tKey}.button`) }}
        </TextButton>
      </form>
    </template>
  </CenteredModal>
</template>