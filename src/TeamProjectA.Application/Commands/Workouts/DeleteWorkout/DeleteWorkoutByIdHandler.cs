using MediatR;
using TeamProjectA.Infrastructure.Repositories.Interfaces;

namespace TeamProjectA.Application.Commands.Workouts.DeleteWorkout;

public class DeleteWorkoutByIdHandler : IRequestHandler<DeleteWorkoutByIdCommand, bool>
{
    private readonly IWorkoutsRepository _workoutRepository;

    public DeleteWorkoutByIdHandler(IWorkoutsRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<bool> Handle(DeleteWorkoutByIdCommand request, CancellationToken cancellationToken) =>
        await _workoutRepository.DeleteWorkoutById(request.Id);
}