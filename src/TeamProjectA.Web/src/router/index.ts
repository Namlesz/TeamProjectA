import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: () => {
        return { path: '/account/login' }
      },
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
    // error 404
    {
      path: '/:pathMatch(.*)',
      component: () => import('@/views/NotFoundView/NotFoundView.vue'),
    },
  ],
})

export default router
