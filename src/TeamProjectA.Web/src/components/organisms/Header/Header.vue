<script setup lang='ts'>
import { useTheme } from 'vuetify'

const theme = useTheme()

const toggleTheme = () => {
  theme.global.name.value = theme.global.current.value.dark ? 'light' : 'dark'
}
</script>
<template>
  <v-app-bar>
    <v-app-bar-title>Test</v-app-bar-title>
    <IconButton @click='toggleTheme' icon='mdi-theme-light-dark'>
    </IconButton>
  </v-app-bar>
</template>