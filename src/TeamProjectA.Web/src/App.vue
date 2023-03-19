<script setup lang='ts'>
import { RouterView } from 'vue-router'
import { useAccountStore } from '@/stores/account'
import { storeToRefs } from 'pinia'
import { useDisplay } from 'vuetify'
import Menu from '@/components/organisms/Menu/Menu.vue'

const { mobile } = useDisplay()

const accountStore = useAccountStore()
const { shouldMenuBeVisible, shouldMenuBeOpen } = storeToRefs(accountStore)
</script>
<template>
  <v-app>
    <Menu v-if='shouldMenuBeVisible && mobile' v-model='shouldMenuBeOpen' />
    <Header />
    <Menu v-if='shouldMenuBeVisible && !mobile' />
    <v-main>
      <RouterView />
    </v-main>
  </v-app>
</template>
