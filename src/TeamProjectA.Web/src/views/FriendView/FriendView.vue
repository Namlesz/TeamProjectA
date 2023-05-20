<script setup lang='ts'>
import HeadlineL from '@/components/atoms/Typography/HeadlineL.vue'
import { useRoute } from 'vue-router'
import TextCaption from '@/components/atoms/Typography/TextCaption.vue'
import type { Friend } from '@/types/Friend'
import { useI18n } from 'vue-i18n'

const route = useRoute()
const { t } = useI18n()

const friend: Friend = {
  name: route.params.name.toString(),
  initials: 'TT',
  description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ornare dignissim ipsum, nec consequat\n' +
    '        ligula dignissim non. Ut ultricies feugiat pellentesque. Cras viverra pulvinar gravida. Duis ullamcorper ut orci\n' +
    '        in faucibus. Donec id tellus porttitor neque pretium dictum sed in felis. Vivamus id tristique nibh. Phasellus\n' +
    '        quam tellus, viverra vitae tempor quis, fringilla quis tortor.',
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
  <HeadlineXS class='ma-5'>{{ t('workout-plan') }} TODO PZ-67</HeadlineXS>
</template>
<i18n>{
  "en": {
    "workout-plan": "Workout plan"
  },
  "pl": {
    "workout-plan": "Plan treningowy"
  }
}</i18n>