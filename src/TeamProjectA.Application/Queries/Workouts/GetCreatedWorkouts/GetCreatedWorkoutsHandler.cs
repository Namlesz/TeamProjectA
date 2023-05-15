using MediatR;
using TeamProjectA.Domain.Entities.Workouts;
using TeamProjectA.Domain.Repositories;
using TeamProjectA.Domain.Shared;

namespace TeamProjectA.Application.Queries.Workouts.GetCreatedWorkouts;

public class GetCreatedWorkoutsHandler : IRequestHandler<GetCreatedWorkoutsQuery, List<WorkoutDto>>
{
    private readonly IWorkoutsRepository _workoutsRepository;
    private readonly CurrentUser _currentUser;

    public GetCreatedWorkoutsHandler(IWorkoutsRepository workoutsRepository, CurrentUser currentUser)
    {
        _workoutsRepository = workoutsRepository;
        _currentUser = currentUser;
    }

    public Task<List<WorkoutDto>> Handle(GetCreatedWorkoutsQuery request, CancellationToken cancellationToken) =>
        _workoutsRepository.GetCreatedWorkouts(_currentUser.UserId, cancellationToken);
}