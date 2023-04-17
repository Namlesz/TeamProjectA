import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useToasterStore = defineStore('toaster', () => {
  const message = ref<string>('')
  const variant = ref<'success' | 'info' | 'warning' | 'error'>('success')
  const open = ref<boolean>()

  function triggerToaster(
    newMessage: string,
    newVariant: 'success' | 'info' | 'warning' | 'error',
  ) {
    message.value = newMessage
    variant.value = newVariant

    open.value = true
  }

  return { message, variant, open, triggerToaster }
})
