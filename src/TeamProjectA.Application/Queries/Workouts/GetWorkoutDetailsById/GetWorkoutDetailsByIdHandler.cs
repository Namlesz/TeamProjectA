using MediatR;
using TeamProjectA.Domain.Workouts;
using TeamProjectA.Infrastructure.Repositories.Interfaces;

namespace TeamProjectA.Application.Queries.Workouts.GetWorkoutDetailsById;

public sealed class GetWorkoutDetailsByIdHandler : IRequestHandler<GetWorkoutDetailsByIdQuery, WorkoutDto?>
{
    private readonly IWorkoutsRepository _workoutRepository;

    public GetWorkoutDetailsByIdHandler(IWorkoutsRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<WorkoutDto?> Handle(GetWorkoutDetailsByIdQuery request, CancellationToken cancellationToken) => 
        await _workoutRepository.GetWorkoutDetailsById(request.Id);
}