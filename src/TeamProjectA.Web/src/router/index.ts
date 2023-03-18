import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'landing page',
      component: () => import('@/views/LandingPage/LandingPage.vue'),
    },
    {
      path: '/account',
      redirect: () => {
        return { path: '/account/login' }
      },
    },
    {
      path: '/account/login',
      name: 'login',
      component: () => import('@/views/AccountViews/LoginView/LoginView.vue'),
    },
    {
      path: '/account/register',
      name: 'register',
      component: () => import('@/views/AccountViews/RegisterView/RegisterView.vue'),
    },
    {
      path: '/home',
      name: 'home',
      component: () => import('@/views/HomeView/HomeView.vue'),
    },
    {
      path: '/trainers',
      name: 'trainers',
      component: () => import('@/views/TrainersView/TrainersView.vue'),
    },
    {
      path: '/invites',
      name: 'invites',
      component: () => import('@/views/InvitesView/InvitesView.vue'),
    },
    {
      path: '/friends',
      name: 'friends',
      component: () => import('@/views/FriendsView/FriendsView.vue'),
    },
    // error 404
    {
      path: '/:pathMatch(.*)',
      component: () => import('@/views/NotFoundView/NotFoundView.vue'),
    },
  ],
})

export default router
