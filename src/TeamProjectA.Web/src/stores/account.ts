import { defineStore } from 'pinia'
import { ref } from 'vue'
import router from '@/router'
import { useJwt } from '@vueuse/integrations/useJwt'

export const useAccountStore = defineStore('account', () => {
  const shouldMenuBeVisible = ref<boolean>(false)
  const shouldMenuBeOpen = ref<boolean>(false)
  const isAuthenticated = ref<boolean>(false)
  const token = ref<string>('')

  function setShouldMenuBeVisible(value: boolean) {
    shouldMenuBeVisible.value = value
  }

  function setShouldMenuBeOpen(value: boolean) {
    shouldMenuBeOpen.value = value
  }

  function setToken(value: string) {
    token.value = value
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

          return false
        }
      }
    } else {
      isAuthenticated.value = false
      router.replace('/')

      return false
    }
  }

  function logout() {
    setToken('')
    localStorage.setItem('userToken', '')
    setShouldMenuBeVisible(false)
    router.replace({ name: 'landing page' })
  }

  function login(token: string) {
    setToken(token)
    localStorage.setItem('userToken', token)
    if (checkUserAuthentication()) {
      setShouldMenuBeVisible(true)
      router.replace({ name: 'home' })
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
