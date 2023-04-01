using MapsterMapper;
using MediatR;
using TeamProjectA.Domain.Entities.Workouts;
using TeamProjectA.Domain.Repositories;

namespace TeamProjectA.Application.Commands.Workouts.CreateWorkout;

public sealed class CreateWorkoutHandler : IRequestHandler<CreateWorkoutCommand, Guid?>
{
    private readonly IWorkoutsRepository _workoutRepository;
    private readonly IMapper _mapper;

    public CreateWorkoutHandler(IWorkoutsRepository workoutRepository, IMapper mapper)
    {
        _workoutRepository = workoutRepository;
        _mapper = mapper;
    }

    public async Task<Guid?> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken) =>
        await _workoutRepository.CreateWorkout(_mapper.Map<CreateWorkoutCommand, NewWorkout>(request));
}