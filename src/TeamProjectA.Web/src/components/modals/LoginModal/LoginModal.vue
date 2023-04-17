<script setup lang='ts'>
import CenteredModal from '@/components/organisms/CenteredModal/CenteredModal.vue'
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import { useI18n } from 'vue-i18n'
import { ref } from 'vue'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'

const tKey = 'loginModal'

const { t } = useI18n()

const nickname = ref<string>('')

const rules = [
  (value: string) => {
    if (value) return true

    return t(`${tKey}.form.nickname-is-empty-error`)
  },
]

defineEmits(['on-close'])
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
      <v-form
        fast-fail
        @submit.prevent
      >
        <v-text-field
          v-model='nickname'
          :rules='rules'
          :label='t(`${tKey}.form.nickname`)'
        />
        <TextButton
          full-width
          variant='primary'
          type='submit'
          class='mt-5'
        >
          {{ t(`${tKey}.button`) }}
        </TextButton>
      </v-form>
    </template>
  </CenteredModal>
</template>