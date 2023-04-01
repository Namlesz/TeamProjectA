import { describe, test, expect, beforeEach, vi } from 'vitest'
import { setActivePinia, createPinia } from 'pinia'
import { useAccountStore } from '@/stores/account'
import router from '@/router'

const expiredJWT =
  'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyLCJleHAiOjE1MTYyMzkwMjJ9.4Adcj3UFYzPUVaVF43FmMab6RlaQD8A9V8wFzzht-KQ'

const validJWT =
  'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyLCJleHAiOjI1MTYyMzkwMjJ9.d9Bbx_4LikUHETu6aK5c4b-gO3PA8rzrIU2JwHna__s'

describe('AccountStore', () => {
  beforeEach(() => {
    setActivePinia(createPinia())
    localStorage.clear()
  })

  test('User token is null, checks user Authentication, sets isAuthenticated false and returns false', () => {
    // arrange
    const userStore = useAccountStore()

    // act
    userStore.checkUserAuthentication()

    // assert
    expect(userStore.isAuthenticated).toBe(false)
    expect(userStore.checkUserAuthentication()).toBe(false)
  })

  test('User token is expired, checks user Authentication, sets isAuthenticated false, redirects to login view and returns false', () => {
    // arrange
    const userStore = useAccountStore()
    localStorage.setItem('userToken', expiredJWT)

    // act
    userStore.checkUserAuthentication()

    // assert
    expect(userStore.isAuthenticated).toBe(false)
    expect(userStore.checkUserAuthentication()).toBe(false)
  })

  test('User token is valid, checks user Authentication, sets isAuthenticated true and returns true', () => {
    // arrange
    const userStore = useAccountStore()
    localStorage.setItem('userToken', validJWT)

    // act
    userStore.checkUserAuthentication()

    // assert
    expect(userStore.isAuthenticated).toBe(true)
    expect(userStore.checkUserAuthentication()).toBe(true)
  })
})
