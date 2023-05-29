<script setup lang='ts'>
import type { ExerciseDto } from '@/types/dto/WorkoutDto'
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import HeadlineXS from '@/components/atoms/Typography/HeadlineXS.vue'
import { useI18n } from 'vue-i18n'

defineProps<{ exercise: ExerciseDto }>()

const { t } = useI18n()
</script>
<template>
  <v-sheet
    class='d-flex flex-column ma-5'
    rounded='lg'
  >
    <HeadlineXS>{{ exercise.name }}</HeadlineXS>
    <TextBody>{{ t('reps') }} {{ exercise.reps }}</TextBody>
    <TextBody>{{ t('sets') }} {{ exercise.sets }}</TextBody>
    <TextBody>{{ t('description') }} {{ exercise.description }}</TextBody>
  </v-sheet>
</template>
<i18n>{
  "en": {
    "description": "Description:",
    "reps": "Repetitions:",
    "sets": "Sets:"
  },
  "pl": {
    "description": "Opis:",
    "reps": "Powtórzenia:",
    "sets": "Zestawy:"
  }
}</i18n>