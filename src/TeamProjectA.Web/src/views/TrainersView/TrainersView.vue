<script setup lang='ts'>
import { useI18n } from 'vue-i18n'
import UserListVirtualScroll from '@/components/organisms/UserListVirtualScroll/UserListVirtualScroll.vue'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { useField, useForm } from 'vee-validate'

const { handleSubmit } = useForm({
  validationSchema: {
    trainerName(value: string) {
      if (value) return true

      return t('errors.nickname-is-empty-error')
    },
  },
})

const { t } = useI18n()

type Trainer = {
  name: string,
  initials: string,
  description: string
}

// TODO delete when data will be fetched from backend
const trainers: Trainer[] = [
  {
    name: 'Trener Testowy',
    initials: 'TT',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ornare dignissim ipsum, nec consequat\n' +
      '        ligula dignissim non. Ut ultricies feugiat pellentesque. Cras viverra pulvinar gravida. Duis ullamcorper ut orci\n' +
      '        in faucibus. Donec id tellus porttitor neque pretium dictum sed in felis. Vivamus id tristique nibh. Phasellus\n' +
      '        quam tellus, viverra vitae tempor quis, fringilla quis tortor.',
  },
]

const trainerName = useField('trainerName')
const isFetching = false // TODO handle isFetching

const handleAddFriend = () => {
  // TODO handle add friend
}

const handleGetTrainerDetails = () => {
  // TODO get trainer details
}

const submitTrainer = handleSubmit(() => {
  handleGetTrainerDetails()
})

</script>
<template>
  <HeadlineL>{{ t('trainers-list') }} - WIP TODO PZ-17</HeadlineL>
  <form
    fast-fail
    class='ma-5'
    @submit.prevent='submitTrainer'
  >
    <HeadlineXS>{{ t('search-trainer') }}</HeadlineXS>
    <div class='d-flex align-center justify-center'>
      <v-text-field
        v-model='trainerName.value.value'
        :error-messages='trainerName.errorMessage.value ?? ""'
        :label='t(`form.trainer-name`)'
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
    :primary-action='{name: t("add-friend"), icon: "mdi-plus"}'
    :items='trainers'
    @on-primary-action='handleAddFriend'
  />
</template>
<i18n>{
  "en": {
    "add-friend": "Add friend",
    "form": {
      "trainer-name": "Trainer name"
    },
    "search-trainer": "Search trainer",
    "trainers-list": "Trainers list"
  },
  "pl": {
    "add-friend": "Dodaj znajomego",
    "form": {
      "trainer-name": "Nazwa trenera"
    },
    "search-trainer": "Wyszukaj trenera",
    "trainers-list": "Lista trenerów"
  }
}</i18n>