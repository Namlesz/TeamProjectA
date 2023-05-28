<script setup lang='ts'>
import { useField } from 'vee-validate'

const props = defineProps<{ name: string, type?: string, label: string, loading?: boolean }>()

const field = useField(() => props.name, undefined)
</script>
<template>
  <v-text-field
    v-model='field.value.value'
    :name='name'
    :label='label'
    :error-messages='field.errorMessage.value ?? ""'
    :type='type ?? "text"'
    :loading='loading ?? false'
  />
</template>