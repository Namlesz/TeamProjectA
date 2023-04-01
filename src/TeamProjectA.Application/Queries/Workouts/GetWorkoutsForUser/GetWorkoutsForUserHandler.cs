using MediatR;
using TeamProjectA.Domain.Entities.Workouts;
using TeamProjectA.Domain.Repositories;

namespace TeamProjectA.Application.Queries.Workouts.GetWorkoutsForUser;

public class GetWorkoutsForUserHandler : IRequestHandler<GetWorkoutsForUserQuery, List<WorkoutDto>>
{
    private readonly IWorkoutsRepository _workoutsRepository;

    public GetWorkoutsForUserHandler(IWorkoutsRepository workoutsRepository)
    {
        _workoutsRepository = workoutsRepository;
    }

    public async Task<List<WorkoutDto>> Handle(GetWorkoutsForUserQuery request, CancellationToken cancellationToken) =>
        await _workoutsRepository.GetWorkoutsForUser(request.UserId);
}