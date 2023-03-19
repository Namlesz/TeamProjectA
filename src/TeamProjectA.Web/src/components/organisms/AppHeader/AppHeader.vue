<script setup lang='ts'>
import { useDisplay, useTheme } from 'vuetify'
import { useAccountStore } from '@/stores/account'
import { storeToRefs } from 'pinia'

const { mobile } = useDisplay()
const theme = useTheme()
const accountStore = useAccountStore()
const { shouldMenuBeVisible, shouldMenuBeOpen } = storeToRefs(accountStore)

const toggleTheme = () => {
  theme.global.name.value = theme.global.current.value.dark ? 'light' : 'dark'
}
</script>
<template>
  <v-app-bar>
    <v-app-bar-title v-if='!mobile'>
      Test
    </v-app-bar-title>
    <v-app-bar-title v-if='mobile'>
      <IconButton
        v-if='shouldMenuBeVisible'
        icon='mdi-menu'
        @click='accountStore.setShouldMenuBeOpen(!shouldMenuBeOpen)'
      />
    </v-app-bar-title>
    <IconButton
      icon='mdi-theme-light-dark'
      @click='toggleTheme'
    />
  </v-app-bar>
</template>
