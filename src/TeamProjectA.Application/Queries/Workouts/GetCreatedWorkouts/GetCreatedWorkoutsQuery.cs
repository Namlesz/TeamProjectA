using MediatR;
using TeamProjectA.Domain.Entities.Workouts;

namespace TeamProjectA.Application.Queries.Workouts.GetCreatedWorkouts;

public record GetCreatedWorkoutsQuery : IRequest<List<WorkoutDto>>;