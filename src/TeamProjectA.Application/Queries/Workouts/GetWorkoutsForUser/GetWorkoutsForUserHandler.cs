using MediatR;
using TeamProjectA.Domain.Entities.Workouts;
using TeamProjectA.Domain.Repositories;
using TeamProjectA.Domain.Shared;

namespace TeamProjectA.Application.Queries.Workouts.GetWorkoutsForUser;

public class GetWorkoutsForUserHandler : IRequestHandler<GetWorkoutsForUserQuery, List<WorkoutDto>>
{
    private readonly IWorkoutsRepository _workoutsRepository;
    private readonly CurrentUser _currentUser;

    public GetWorkoutsForUserHandler(IWorkoutsRepository workoutsRepository, CurrentUser currentUser)
    {
        _workoutsRepository = workoutsRepository;
        _currentUser = currentUser;
    }

    public async Task<List<WorkoutDto>> Handle(GetWorkoutsForUserQuery request, CancellationToken cancellationToken) =>
        await _workoutsRepository.GetWorkoutsForUser(_currentUser.UserId);
}