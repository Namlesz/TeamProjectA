import type { UserDto } from '@/types/dto/UserDto'

export type FriendDto = UserDto & {
  initials?: string
}
