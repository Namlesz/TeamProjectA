<script setup lang='ts'>
import HeadlineS from '@/components/atoms/Typography/HeadlineS.vue'
import { useQuery } from '@tanstack/vue-query'
import axios from 'axios'
import WorkoutsListVirtualScroll from '@/components/organisms/WorkoutsListVirtualScroll/WorkoutsListVirtualScroll.vue'
import { useI18n } from 'vue-i18n'

const { t } = useI18n()

const { data, isFetching } = useQuery({
  queryKey: ['getWorkouts'],
  queryFn: () => axios.get('/api/Workouts/GetWorkouts', {
    headers: {
      Authorization: 'Bearer ' + localStorage.getItem('userToken'),
    },
  }),
  select: (response) => response.data,
})
</script>
<template>
  <HeadlineL>{{ t('home-page') }}</HeadlineL>
  <HeadlineS class='mx-5'>
    {{ t('yours-workout-plans') }}
  </HeadlineS>
  <WorkoutsListVirtualScroll
    v-if='data'
    :items='data'
    :is-loading='isFetching'
  />
</template>
<i18n>{
  "en": {
    "home-page": "Home page",
    "yours-workout-plans": "Yours workout plans"
  },
  "pl": {
    "home-page": "Strona główna",
    "yours-workout-plans": "Twoje plany treningowe"
  }
}
</i18n>
