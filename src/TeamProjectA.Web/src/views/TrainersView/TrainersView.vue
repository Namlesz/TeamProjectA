<script setup lang='ts'>

import UserListItem from '@/components/molecules/UserListItem/UserListItem.vue'

type Trainer = {
  name: string
}

const trainers: Trainer[] = [
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  }, {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
  {
    name: 'Trener Testowy 1',
  },
  {
    name: 'Trener Testowy 2',
  },
]

const handleAddFriend = () => {
  // TODO handle add friend
}

</script>
<template>
  <HeadlineL>Lista trenerów</HeadlineL>
  <v-virtual-scroll
    :items='trainers'
    item-height='48'
  >
    <template #default='{ item }'>
      <UserListItem
        initials='TT'
        :name='item.name'
        description='Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ornare dignissim ipsum, nec consequat
        ligula dignissim non. Ut ultricies feugiat pellentesque. Cras viverra pulvinar gravida. Duis ullamcorper ut orci
        in faucibus. Donec id tellus porttitor neque pretium dictum sed in felis. Vivamus id tristique nibh. Phasellus
        quam tellus, viverra vitae tempor quis, fringilla quis tortor.'
        action-name='Dodaj znajomego'
        @on-action='handleAddFriend'
      />
    </template>
  </v-virtual-scroll>
</template>
