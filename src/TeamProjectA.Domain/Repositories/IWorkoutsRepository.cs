using TeamProjectA.Domain.Entities.BaseModels;
using TeamProjectA.Domain.Entities.Workouts;

namespace TeamProjectA.Domain.Repositories;

public interface IWorkoutsRepository
{
    Task<Guid?> CreateWorkout(NewWorkout workout, CancellationToken cancellationToken);
    Task<WorkoutDto?> GetWorkoutDetailsById(Guid workoutId, CancellationToken cancellationToken);
    Task<bool> DeleteWorkoutById(Guid workoutId, CancellationToken cancellationToken);
    Task<List<WorkoutDto>> GetWorkoutsForUser(Guid userId, CancellationToken cancellationToken);
    Task<List<WorkoutDto>> GetCreatedWorkouts(Guid currentUserUserId, CancellationToken cancellationToken);
    Task<IdResult?> UpdateWorkout(WorkoutDto workout, CancellationToken cancellationToken);
}