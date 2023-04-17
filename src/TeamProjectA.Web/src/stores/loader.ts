import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useLoaderStore = defineStore('loader', () => {
  const mainLinearLoader = ref<boolean>(false)
  const mainSpinLoader = ref<boolean>(false)

  function setMainLinearLoader(value: boolean) {
    mainLinearLoader.value = value
  }

  function setMainSpinLoader(value: boolean) {
    mainSpinLoader.value = value
  }

  return {
    mainLinearLoader,
    setMainLinearLoader,
    mainSpinLoader,
    setMainSpinLoader,
  }
})
