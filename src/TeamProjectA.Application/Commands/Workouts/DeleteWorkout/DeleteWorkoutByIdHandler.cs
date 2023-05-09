using MediatR;
using TeamProjectA.Domain.Repositories;

namespace TeamProjectA.Application.Commands.Workouts.DeleteWorkout;

public class DeleteWorkoutByIdHandler : IRequestHandler<DeleteWorkoutByIdCommand, bool>
{
    private readonly IWorkoutsRepository _workoutRepository;

    public DeleteWorkoutByIdHandler(IWorkoutsRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public Task<bool> Handle(DeleteWorkoutByIdCommand request, CancellationToken cancellationToken) =>
        _workoutRepository.DeleteWorkoutById(request.Id);
}