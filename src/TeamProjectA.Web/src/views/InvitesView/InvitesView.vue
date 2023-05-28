<script setup lang='ts'>
import { useI18n } from 'vue-i18n'
import UserListVirtualScroll from '@/components/organisms/UserListVirtualScroll/UserListVirtualScroll.vue'
import type { InviteDto } from '@/types/dto/InviteDto'

const { t } = useI18n()

// TODO delete when data will be fetched from backend
const invites: InviteDto[] = [
  {
    id: '34e4fa85-015d-4213-9635-142a721ea744',
    login: 'Trener Testowy',
    initials: 'TT',
  },
]

const acceptInvite = () => {
// TODO handle accpet invite
}

const declineInvite = () => {
// TODO handle decline invite
}

</script>
<template>
  <HeadlineL>{{ t('invites-list') }} - WIP TODO PZ-18</HeadlineL>
  <UserListVirtualScroll
    :primary-action='{name: t("accept-invitation"), icon: "mdi-account-plus"}'
    :secondary-action='{name: t("decline-invitation"), icon: "mdi-account-remove"}'
    :items='invites'
    @on-primary-action='acceptInvite'
    @on-secondary-action='declineInvite'
  />
</template>
<i18n>
{
  "pl": {
    "invites-list": "Zaproszenia do znajomych",
    "accept-invitation": "Zaakceptuj",
    "decline-invitation": "Odrzuć"
  },
  "en": {
    "invites-list": "Invites to friends",
    "accept-invitation": "Accept",
    "decline-invitation": "Decline"
  }
}
</i18n>
