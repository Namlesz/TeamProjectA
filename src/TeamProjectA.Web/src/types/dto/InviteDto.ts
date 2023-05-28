import type { UserDto } from '@/types/dto/UserDto'

export type InviteDto = UserDto & {
  initials?: string
}
