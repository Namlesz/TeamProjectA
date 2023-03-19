<script setup lang='ts'>
import { useI18n } from 'vue-i18n'
import { computed } from 'vue'
import router from '@/router'
import { useAccountStore } from '@/stores/account'
import { useDisplay } from 'vuetify'

const tKey = 'menu-items'

const { mobile } = useDisplay()
const { t } = useI18n()
const accountStore = useAccountStore()

const activeMenuItem = computed({
  get() {
    return router.currentRoute.value.name?.toString() ?? null
  },
  set(newValue) {
    return newValue
  },
})

const menuItems = [
  {
    icon: 'mdi-home',
    title: t(`${tKey}.home`),
    value: 'home',
  },
  {
    icon: 'mdi-account-multiple-plus',
    title: t(`${tKey}.trainers`),
    value: 'trainers',
  },
  {
    icon: 'mdi-account-multiple-check',
    title: t(`${tKey}.invites`),
    value: 'invites',
  },
  {
    icon: 'mdi-account-multiple',
    title: t(`${tKey}.friends`),
    value: 'friends',
  },
]

const handleChangeMenuItem = (value: string) => {
  router.push({ name: value })
}

const handleLogout = () => {
  accountStore.logout()
}
</script>
<template>
  <v-navigation-drawer
    :expand-on-hover='!mobile'
    :rail='!mobile'
  >
    <v-sheet
      class='d-flex flex-column justify-space-between'
      height='100%'
    >
      <v-sheet>
        <v-list>
          <v-list-item
            prepend-avatar='https://randomuser.me/api/portraits/women/85.jpg'
            title='Sandra Adams'
            subtitle='sandra_a88@gmailcom'
          />
        </v-list>
        <v-divider />
        <v-list
          density='compact'
          nav
        >
          <v-list-item
            v-for='menuItem in menuItems'
            :key='menuItem.value'
            :prepend-icon='menuItem.icon'
            :title='menuItem.title'
            :value='menuItem.value'
            :active='activeMenuItem === menuItem.value'
            @click='handleChangeMenuItem(menuItem.value)'
          />
        </v-list>
      </v-sheet>
      <v-sheet>
        <v-list>
          <v-list-item
            prepend-icon='mdi-logout-variant'
            :title='t(`${tKey}.logout`)'
            value='logout'
            class='text-red'
            :active='false'
            @click-once='handleLogout'
          />
        </v-list>
      </v-sheet>
    </v-sheet>
  </v-navigation-drawer>
</template>
