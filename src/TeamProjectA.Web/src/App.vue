<script setup lang="ts">
import { RouterView } from 'vue-router'
import { useAccountStore } from '@/stores/account'
import { storeToRefs } from 'pinia'

const accountStore = useAccountStore()
const { shouldMenuBeVisible } = storeToRefs(accountStore)
</script>
<template>
  <v-app>
    <Header />
    <Menu v-if="shouldMenuBeVisible" />
    <v-main>
      <RouterView />
    </v-main>
  </v-app>
</template>
