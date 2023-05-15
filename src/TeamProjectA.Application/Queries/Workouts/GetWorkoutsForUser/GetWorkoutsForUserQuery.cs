using MediatR;
using TeamProjectA.Domain.Entities.Workouts;

namespace TeamProjectA.Application.Queries.Workouts.GetWorkoutsForUser;

public record GetWorkoutsForUserQuery : IRequest<List<WorkoutDto>>;