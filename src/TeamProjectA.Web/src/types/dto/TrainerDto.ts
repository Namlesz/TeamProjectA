import type { UserDto } from '@/types/dto/UserDto'

export type TrainerDto = UserDto & {
  initials: string
  description: string
}
