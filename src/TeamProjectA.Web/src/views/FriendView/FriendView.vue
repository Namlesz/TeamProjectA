<script setup lang='ts'>
import HeadlineL from '@/components/atoms/Typography/HeadlineL.vue'
import { useRoute } from 'vue-router'

const route = useRoute()

const username = route.params.name

</script>
<template>
  <HeadlineL>Użytkownik {{ username }} TODO PZ-20</HeadlineL>
</template>