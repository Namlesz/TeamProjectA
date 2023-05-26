<script setup lang='ts'>
import CenteredModal from '@/components/organisms/CenteredModal/CenteredModal.vue'
import { useI18n } from 'vue-i18n'
import { useForm, useFieldArray, useField } from 'vee-validate'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { object, string, date, array, number } from 'yup'
import HeadlineS from '@/components/atoms/Typography/HeadlineS.vue'
import IconButton from '@/components/atoms/Buttons/IconButton.vue'
import HeadlineXS from '@/components/atoms/Typography/HeadlineXS.vue'
import TextFieldWithValidation from '@/components/atoms/TextFieldWithValidation/TextFieldWithValidation.vue'
import TextAreaWithValidation from '@/components/atoms/TextAreaWithValidation/TextAreaWithValidation.vue'
import { useToasterStore } from '@/stores/toaster'
import { useQuery } from '@tanstack/vue-query'
import axios from 'axios'
import { useLoaderStore } from '@/stores/loader'

interface Exercise {
  name: string
  reps: number
  sets: number
  description?: string
}

interface WorkoutPlan {
  workoutName: string
  workoutDate: Date
  ownerId: string
  exercises: Exercise[]
}

const emit = defineEmits(['on-close'])
const { t } = useI18n()
const toasterStore = useToasterStore()
const loaderStore = useLoaderStore()

const schema = object({
  workoutName: string().required(t('errors.field-is-empty-error')),
  workoutDate: date().required(t('errors.field-is-empty-error')).min(new Date(), t('errors.date-is-in-past-error')),
  exercises: array().of(
    object({
      name: string().required(t('errors.field-is-empty-error')),
      reps: number().required(t('errors.field-is-empty-error')),
      sets: number().required(t('errors.field-is-empty-error')),
      description: string().notRequired(),
    }),
  ),
})

const { handleSubmit, values } = useForm<WorkoutPlan>({
  validationSchema: schema,
})

useField('workoutName')
useField('workoutDate')
const { remove, push, fields } = useFieldArray('exercises')

values.ownerId = 'a886dc5f-cd0a-4477-850d-b7c1fa061467' // TODO get selected user Id

const { refetch: postCreateWorkout, isFetched, isError } = useQuery({
  queryKey: ['createWorkout'],
  queryFn: () => axios.post('/api/Workouts/CreateWorkout', values, {
    headers: {
      Authorization: 'Bearer ' + localStorage.getItem('userToken'),
    },
  }),
  select: (response) => response.data,
  enabled: false,
})

const submit = handleSubmit(async () => {
  if (!values.exercises) {
    toasterStore.triggerToaster(t('errors.at-least-one-exercise-error'), 'warning')

    return
  }

  loaderStore.setMainLinearLoader(true)

  await postCreateWorkout()

  if (isFetched.value) {
    loaderStore.setMainLinearLoader(false)

    if (isError.value) {
      toasterStore.triggerToaster(t('errors.internal-server-error'), 'error')

      return
    }

    toasterStore.triggerToaster(t('form.added-new-workout-plan'), 'success')
    emit('on-close')
  }
})
</script>
<template>
  <CenteredModal
    width='500px'
    @on-close='$emit("on-close")'
  >
    <template #title>
      {{ t('create-workout-plan') }}
    </template>
    <template #body>
      <v-form
        @submit.prevent='submit'
      >
        <TextFieldWithValidation
          name='workoutName'
          :label='t("form.workout-name")'
        />
        <TextFieldWithValidation
          name='workoutDate'
          :label='t("form.workout-date")'
          type='date'
        />
        <div class='d-flex justify-space-between'>
          <HeadlineS>
            {{ t('form.exercises') }}
          </HeadlineS>
          <IconButton
            icon='mdi-plus'
            variant='positive'
            @click='push(undefined)'
          />
        </div>
        <div
          v-for='(field, idx) in fields'
          :key='field.key'
        >
          <div class='d-flex justify-space-between'>
            <HeadlineXS>
              {{ t('form.exercise.title', { number: idx + 1 }) }}
            </HeadlineXS>
            <IconButton
              icon='mdi-delete'
              variant='negative'
              @click='remove(idx)'
            />
          </div>
          <TextFieldWithValidation
            :name='`exercises[${idx}].name`'
            :label='t("form.exercise.name")'
          />
          <TextFieldWithValidation
            :name='`exercises[${idx}].reps`'
            :label='t("form.exercise.reps")'
            type='number'
          />
          <TextFieldWithValidation
            :name='`exercises[${idx}].sets`'
            :label='t("form.exercise.sets")'
            type='number'
          />
          <TextAreaWithValidation
            :name='`exercises[${idx}].description`'
            :label='t("form.exercise.description")'
          />
        </div>
        <TextButton
          full-width
          variant='primary'
          type='submit'
          class='mt-5'
        >
          {{ t('add') }}
        </TextButton>
      </v-form>
    </template>
  </CenteredModal>
</template>
<i18n>{
  "en": {
    "create-workout-plan": "Create workout plan",
    "form": {
      "added-new-workout-plan": "Added new workout plan",
      "exercise": {
        "description": "Description",
        "name": "Exercise name",
        "reps": "Repetitions",
        "sets": "Sets",
        "title": "Exercise {number}"
      },
      "exercises": "Exercises",
      "workout-date": "Workout date",
      "workout-name": "Workout plan name"
    }
  },
  "pl": {
    "create-workout-plan": "Utwórz plan treningowy",
    "form": {
      "added-new-workout-plan": "Dodano nowy plan treningowy",
      "exercise": {
        "description": "Opis",
        "name": "Nazwa ćwiczenia",
        "reps": "Powtórzenia",
        "sets": "Zestawy",
        "title": "Ćwiczenie {number}"
      },
      "exercises": "Ćwiczenia",
      "workout-date": "Data treningu",
      "workout-name": "Nazwa planu treningowego"
    }
  }
}</i18n>