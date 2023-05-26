<script setup lang='ts'>
import { useField } from 'vee-validate'

const props = defineProps<{ name: string, type?: string, label: string }>()

const { value, handleBlur, errors } = useField(() => props.name)
</script>

<template>
  <v-textarea
    v-model='value'
    :label='label'
    :error-messages='errors'
    :type='type ?? "text"'
    rows='2'
    auto-grow
    counter
    @blur='handleBlur'
  />
</template>