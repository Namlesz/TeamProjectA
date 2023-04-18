<script setup lang='ts'>
import { RouterView } from 'vue-router'
import { useAccountStore } from '@/stores/account'
import { storeToRefs } from 'pinia'
import { useDisplay } from 'vuetify'
import { useLoaderStore } from '@/stores/loader'
import FullscreenLoader from '@/components/molecules/FullscreenLoader/FullscreenLoader.vue'
import { onMounted } from 'vue'
import ToastAlert from '@/components/atoms/ToastAlert/ToastAlert.vue'
import { useToasterStore } from '@/stores/toaster'

const { mobile } = useDisplay()

const accountStore = useAccountStore()
const { shouldMenuBeVisible, shouldMenuBeOpen } = storeToRefs(accountStore)

const loaderStore = useLoaderStore()
const { mainLinearLoader, mainSpinLoader } = storeToRefs(loaderStore)

const toasterStore = useToasterStore()
const { open, message, variant } = storeToRefs(toasterStore)

onMounted(() => {
  if (accountStore.checkUserAuthentication()) {
    accountStore.setShouldMenuBeVisible(true)
  }
})

</script>
<template>
  <v-app>
    <NavigationMenu
      v-if='shouldMenuBeVisible && mobile'
      v-model='shouldMenuBeOpen'
    />
    <AppHeader />
    <NavigationMenu v-if='shouldMenuBeVisible && !mobile' />
    <v-main>
      <v-progress-linear
        :active='mainLinearLoader'
        :indeterminate='mainLinearLoader'
        bottom
        color='indigo'
      />
      <FullscreenLoader :is-loading='mainSpinLoader' />
      <ToastAlert
        v-model='open'
        :variant='variant'
        :message='message'
      />
      <RouterView />
    </v-main>
  </v-app>
</template>
