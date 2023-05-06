<script setup lang='ts'>

import UserListItem from '@/components/molecules/UserListItem/UserListItem.vue'
import { useI18n } from 'vue-i18n'

const { t } = useI18n()

type Trainer = {
  name: string,
  initials: string,
  description: string
}

// TODO delete when data will be fetched from backend
const trainers: Trainer[] = [
  {
    name: 'Trener Testowy',
    initials: 'TT',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ornare dignissim ipsum, nec consequat\n' +
      '        ligula dignissim non. Ut ultricies feugiat pellentesque. Cras viverra pulvinar gravida. Duis ullamcorper ut orci\n' +
      '        in faucibus. Donec id tellus porttitor neque pretium dictum sed in felis. Vivamus id tristique nibh. Phasellus\n' +
      '        quam tellus, viverra vitae tempor quis, fringilla quis tortor.',
  },
]

const handleAddFriend = () => {
  // TODO handle add friend
}

</script>
<template>
  <HeadlineL>{{ t('trainers-list') }}</HeadlineL>
  <v-virtual-scroll
    :items='trainers'
    item-height='48'
  >
    <template #default='{ item }'>
      <UserListItem
        :initials='item.initials'
        :name='item.name'
        :description='item.description'
        :action-name='t("add-friend")'
        @on-action='handleAddFriend'
      />
    </template>
  </v-virtual-scroll>
</template>
<i18n>
{
  "pl": {
    "trainers-list": "Lista trenerów",
    "add-friend": "Dodaj znajomego"
  },
  "en": {
    "trainers-list": "Trainers list",
    "add-friend": "Add friend"
  }
}
</i18n>