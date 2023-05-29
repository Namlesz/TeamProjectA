<script setup lang='ts'>
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import { useI18n } from 'vue-i18n'
import ProgressCircular from '@/components/atoms/ProgressCircular/ProgressCircular.vue'
import WorkoutListItem from '@/components/molecules/WorkoutListItem/WorkoutListItem.vue'

defineProps<{
  items: any[],
  clickableRow?: boolean,
  isLoading?: boolean
}>()
const emit = defineEmits(['onListItemClick'])

const { t } = useI18n()

</script>
<template>
  <div
    v-if='isLoading'
    class='d-flex align-center justify-center'
  >
    <ProgressCircular />
  </div>
  <v-virtual-scroll
    v-else-if='items.length >= 1'
    :items='items'
    item-height='48'
  >
    <template #default='{ item }'>
      <WorkoutListItem
        :name='item.workoutName'
        :date='item.workoutDate'
        :exercises='item.exercises'
        v-on='clickableRow && emit("onListItemClick")'
      />
    </template>
  </v-virtual-scroll>
  <div
    v-else
    class='d-flex justify-center align-center flex-column'
  >
    <v-icon icon='mdi-alert-circle' />
    <TextBody>
      {{ t('errors.not-found-error') }}
    </TextBody>
  </div>
</template>