import { defineStore } from 'pinia'
import { ref } from 'vue'
import router from '@/router'

export const useAccountStore = defineStore('account', () => {
  const shouldMenuBeVisible = ref<boolean>(false)

  function setShouldMenuBeVisible(value: boolean) {
    shouldMenuBeVisible.value = value
  }

  function logout() {
    setShouldMenuBeVisible(false)
    router.replace({ name: 'login' })
  }

  function login() {
    setShouldMenuBeVisible(true)
    router.replace({ name: 'home' })
  }

  return { shouldMenuBeVisible, setShouldMenuBeVisible, logout, login }
})