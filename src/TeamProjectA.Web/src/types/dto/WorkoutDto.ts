export interface ExerciseDto {
  name: string
  reps: number
  sets: number
  description?: string
}

export interface WorkoutPlanDto {
  workoutName: string
  workoutDate: Date
  ownerId: string
  exercises: ExerciseDto[]
}
