using MapsterMapper;
using MediatR;
using TeamProjectA.Domain.Entities.BaseModels;
using TeamProjectA.Domain.Entities.Workouts;
using TeamProjectA.Domain.Repositories;
using TeamProjectA.Domain.Shared;

namespace TeamProjectA.Application.Commands.Workouts.UpdateWorkout;

public class UpdateWorkoutHandler : IRequestHandler<UpdateWorkoutCommand, IdResult?>
{
    private readonly IMapper _mapper;
    private readonly CurrentUser _currentUser;
    private readonly IWorkoutsRepository _workoutRepository;

    public UpdateWorkoutHandler(IMapper mapper, CurrentUser currentUser, IWorkoutsRepository workoutRepository)
    {
        _mapper = mapper;
        _currentUser = currentUser;
        _workoutRepository = workoutRepository;
    }

    public Task<IdResult?> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout = _mapper.Map<UpdateWorkoutCommand, WorkoutDto>(request);
        workout.AuthorId = _currentUser.UserId;

        return _workoutRepository.UpdateWorkout(workout, cancellationToken);
    }
}