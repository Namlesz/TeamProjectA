import { createRouter, createWebHistory } from 'vue-router'
import { useAccountStore } from '@/stores/account'

function checkAuthentication() {
  const accountStore = useAccountStore()
  accountStore.checkUserAuthentication()
}

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'landing page',
      component: () => import('@/views/LandingPage/LandingPage.vue'),
    },
    {
      path: '/home',
      name: 'home',
      component: () => import('@/views/HomeView/HomeView.vue'),
      beforeEnter: () => checkAuthentication(),
    },
    {
      path: '/trainers',
      name: 'trainers',
      component: () => import('@/views/TrainersView/TrainersView.vue'),
      beforeEnter: () => checkAuthentication(),
    },
    {
      path: '/invites',
      name: 'invites',
      component: () => import('@/views/InvitesView/InvitesView.vue'),
      beforeEnter: () => checkAuthentication(),
    },
    {
      path: '/friends',
      name: 'friends',
      component: () => import('@/views/FriendsView/FriendsView.vue'),
      beforeEnter: () => checkAuthentication(),
    },
    // error 404
    {
      path: '/:pathMatch(.*)',
      component: () => import('@/views/NotFoundView/NotFoundView.vue'),
    },
  ],
})

export default router
