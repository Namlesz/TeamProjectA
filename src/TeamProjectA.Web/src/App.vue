<script setup lang='ts'>
import { RouterView } from 'vue-router'
</script>
<template>
  <v-app>
    <Header />
    <div class="appWrapper">
      <RouterView />
    </div>
  </v-app>
</template>
<style scoped>
.appWrapper{
  position: fixed;
  top: 64px;
}
</style>
