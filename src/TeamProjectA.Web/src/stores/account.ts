import { defineStore } from 'pinia'
import { ref } from 'vue'
import router from '@/router'
import { useJwt } from '@vueuse/integrations/useJwt'

export const useAccountStore = defineStore('account', () => {
  const shouldMenuBeVisible = ref<boolean>(false)
  const shouldMenuBeOpen = ref<boolean>(false)
  const isAuthenticated = ref<boolean>(false)

  function setShouldMenuBeVisible(value: boolean) {
    shouldMenuBeVisible.value = value
  }

  function setShouldMenuBeOpen(value: boolean) {
    shouldMenuBeOpen.value = value
  }

  function logout() {
    setShouldMenuBeVisible(false)
    router.replace({ name: 'login' })
  }

  function login() {
    setShouldMenuBeVisible(true)
    router.replace({ name: 'home' })
  }

  function checkUserAuthentication() {
    const token = localStorage.getItem('userToken')
    if (token) {
      const { payload } = useJwt(token)

      if (payload.value) {
        const exp = payload.value.exp
        const dateTimeNow = Date.now() / 1000

        if (exp! > dateTimeNow) {
          isAuthenticated.value = true

          return true
        } else {
          isAuthenticated.value = false
          router.replace('/')
          localStorage.removeItem('userToken')
          localStorage.removeItem('userId')

          return false
        }
      }
    } else {
      isAuthenticated.value = false

      return false
    }
  }

  return {
    shouldMenuBeVisible,
    shouldMenuBeOpen,
    setShouldMenuBeVisible,
    setShouldMenuBeOpen,
    logout,
    login,
    isAuthenticated,
    checkUserAuthentication,
  }
})
