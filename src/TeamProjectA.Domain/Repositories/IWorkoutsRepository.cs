using TeamProjectA.Domain.Entities.Workouts;

namespace TeamProjectA.Domain.Repositories;

public interface IWorkoutsRepository
{
    Task<Guid?> CreateWorkout(NewWorkout workout);
    Task<WorkoutDto?> GetWorkoutDetailsById(Guid workoutId);
    Task<bool> DeleteWorkoutById(Guid workoutId);
    Task<List<WorkoutDto>> GetWorkoutsForUser(Guid userId);
}