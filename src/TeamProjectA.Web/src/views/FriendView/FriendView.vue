<script setup lang='ts'>
import HeadlineL from '@/components/atoms/Typography/HeadlineL.vue'
import { useRoute } from 'vue-router'
import TextCaption from '@/components/atoms/Typography/TextCaption.vue'
import type { Friend } from '@/types/Friend'
import { useI18n } from 'vue-i18n'
import TextButtonWithIcon from '@/components/atoms/Buttons/TextButtonWithIcon.vue'
import WorkoutModal from '@/components/modals/WorkoutModal/WorkoutModal.vue'
import { onMounted, ref } from 'vue'
import { useDisplay } from 'vuetify'
import IconButton from '@/components/atoms/Buttons/IconButton.vue'
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import { useUserListStore } from '@/stores/userList'
import { storeToRefs } from 'pinia'
import router from '@/router'

const route = useRoute()
const { t } = useI18n()
const { mobile } = useDisplay()
const openWorkoutModal = ref<boolean>(false)
const { selectedUser } = storeToRefs(useUserListStore())

const friend: Friend = {
  id: '',
  name: route.params.name.toString(),
  initials: 'TT',
  description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ornare dignissim ipsum, nec consequat\n' +
    '        ligula dignissim non. Ut ultricies feugiat pellentesque. Cras viverra pulvinar gravida. Duis ullamcorper ut orci\n' +
    '        in faucibus. Donec id tellus porttitor neque pretium dictum sed in felis. Vivamus id tristique nibh. Phasellus\n' +
    '        quam tellus, viverra vitae tempor quis, fringilla quis tortor.',
}

onMounted(() => {
  if (!selectedUser || selectedUser.value?.login !== route.params.name.toString()) {
    router.replace({ name: 'friends' })

    return
  } else {
    friend.id = selectedUser.value!.id
  }
})

const handleAddWorkout = () => {
  openWorkoutModal.value = true
}

const handleCloseModal = () => {
  openWorkoutModal.value = false
}

</script>
<template>
  <v-sheet
    class='d-flex ma-5 align-center pa-2'
    rounded='lg'
  >
    <v-avatar
      color='red'
      class='text-white'
      size='80'
    >
      {{ friend.initials }}
    </v-avatar>
    <HeadlineL>{{ friend.name }}</HeadlineL>
  </v-sheet>
  <v-sheet
    class='ma-5 pa-1'
    rounded='lg'
  >
    <TextCaption v-if='friend.description'>
      {{ friend.description }}
    </TextCaption>
  </v-sheet>
  <div class='d-flex align-center justify-space-between ma-5'>
    <HeadlineXS>{{ t('workout-plan') }}</HeadlineXS>
    <TextButtonWithIcon
      v-if='!mobile'
      icon='mdi-plus'
      variant='primary'
      @click='handleAddWorkout'
    >
      {{ t('add-workout-plan') }}
    </TextButtonWithIcon>
    <IconButton
      v-if='mobile'
      icon='mdi-plus'
      variant='primary'
      @click='handleAddWorkout'
    />
  </div>
  <v-sheet
    class='ma-5 pa-1'
    rounded='lg'
  >
    <TextBody>
      Plany treningowe znajomego TODO PZ-77
    </TextBody>
  </v-sheet>
  <WorkoutModal
    :id='friend.id'
    v-model='openWorkoutModal'
    @on-close='handleCloseModal'
  />
</template>
<i18n>{
  "en": {
    "add-workout-plan": "Add workout plan",
    "workout-plan": "Workout plan"
  },
  "pl": {
    "add-workout-plan": "Dodaj plan treningowy",
    "workout-plan": "Plan treningowy"
  }
}</i18n>