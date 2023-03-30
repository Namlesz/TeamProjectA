using TeamProjectA.Domain.Workouts;

namespace TeamProjectA.Infrastructure.Repositories.Interfaces;

public interface IWorkoutsRepository
{
    Task<bool> CreateWorkout(NewWorkout workout);
}