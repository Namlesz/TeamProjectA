<script setup lang='ts'>
import { useDisplay } from 'vuetify'
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import { useDateFormat } from '@vueuse/core'
import { i18n } from '@/main'
import HeadlineXS from '@/components/atoms/Typography/HeadlineXS.vue'
import TextButtonWithIcon from '@/components/atoms/Buttons/TextButtonWithIcon.vue'
import IconButton from '@/components/atoms/Buttons/IconButton.vue'
import { ref } from 'vue'
import type { ExerciseDto } from '@/types/dto/WorkoutDto'
import ExerciseListItem from '@/components/molecules/ExerciseListItem/ExerciseListItem.vue'
import { useI18n } from 'vue-i18n'

const { mobile } = useDisplay()

const props = defineProps<{ name: string, date: Date, exercises: ExerciseDto[] }>()

const openDetails = ref<boolean>(false)
const formattedDate = useDateFormat(props.date, 'D MMMM YYYY', { locales: i18n.global.locale.value })
const { t } = useI18n()
</script>
<template>
  <v-list-item
    border
    rounded='lg'
    class='mx-5 my-2'
  >
    <div class='d-flex flex-column'>
      <TextBody>{{ formattedDate }}</TextBody>
      <div class='d-flex justify-space-between'>
        <HeadlineXS>{{ name }}</HeadlineXS>
        <TextButtonWithIcon
          v-if='!mobile && !openDetails'
          icon='mdi-chevron-down'
          @click='openDetails = true'
        >
          {{ t('expand') }}
        </TextButtonWithIcon>
        <IconButton
          v-if='mobile && !openDetails'
          icon='mdi-chevron-down'
          @click='openDetails = true'
        />
        <TextButtonWithIcon
          v-if='!mobile && openDetails'
          icon='mdi-chevron-up'
          @click='openDetails = false'
        >
          {{ t('collapse') }}
        </TextButtonWithIcon>
        <IconButton
          v-if='mobile && openDetails'
          icon='mdi-chevron-up'
          @click='openDetails = false'
        />
      </div>
      <div v-if='openDetails'>
        <ExerciseListItem
          v-for='(exercise, index) in exercises'
          :key='index'
          :exercise='exercise'
        />
      </div>
    </div>
  </v-list-item>
</template>