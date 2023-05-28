import { defineStore } from 'pinia'
import { ref } from 'vue'
import type { UserDto } from '@/types/dto/UserDto'

export const useUserListStore = defineStore('userList', () => {
  const selectedUser = ref<UserDto>()

  function setSelectedUser(user: UserDto) {
    selectedUser.value = user
  }

  return { selectedUser, setSelectedUser }
})
