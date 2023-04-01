using TeamProjectA.Domain.Workouts;

namespace TeamProjectA.Infrastructure.Repositories.Interfaces;

public interface IWorkoutsRepository
{
    Task<Guid?> CreateWorkout(NewWorkout workout);
    Task<WorkoutDto?> GetWorkoutDetailsById(Guid requestId);
    Task<bool> DeleteWorkoutById(Guid requestId);
}