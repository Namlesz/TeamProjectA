using MediatR;
using TeamProjectA.Domain.Entities.Workouts;
using TeamProjectA.Domain.Repositories;

namespace TeamProjectA.Application.Queries.Workouts.GetWorkoutDetailsById;

public sealed class GetWorkoutDetailsByIdHandler : IRequestHandler<GetWorkoutDetailsByIdQuery, WorkoutDto?>
{
    private readonly IWorkoutsRepository _workoutRepository;

    public GetWorkoutDetailsByIdHandler(IWorkoutsRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public Task<WorkoutDto?> Handle(GetWorkoutDetailsByIdQuery request, CancellationToken cancellationToken) =>
        _workoutRepository.GetWorkoutDetailsById(request.Id);
}