using MapsterMapper;
using MediatR;
using TeamProjectA.Domain.Entities.Workouts;
using TeamProjectA.Domain.Repositories;
using TeamProjectA.Domain.Shared;

namespace TeamProjectA.Application.Commands.Workouts.CreateWorkout;

public sealed class CreateWorkoutHandler : IRequestHandler<CreateWorkoutCommand, Guid?>
{
    private readonly IWorkoutsRepository _workoutRepository;
    private readonly IMapper _mapper;
    private readonly CurrentUser _currentUser;

    public CreateWorkoutHandler(IWorkoutsRepository workoutRepository, IMapper mapper, CurrentUser currentUser)
    {
        _workoutRepository = workoutRepository;
        _mapper = mapper;
        _currentUser = currentUser;
    }

    public Task<Guid?> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout = _mapper.Map<CreateWorkoutCommand, NewWorkout>(request);
        workout.AuthorId = _currentUser.UserId;

        return _workoutRepository.CreateWorkout(workout);
    }
}