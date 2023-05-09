import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useUserListStore = defineStore('userList', () => {
  const selectedUser = ref<string>('')

  function setSelectedUser(name: string) {
    selectedUser.value = name
  }

  return { selectedUser, setSelectedUser }
})
