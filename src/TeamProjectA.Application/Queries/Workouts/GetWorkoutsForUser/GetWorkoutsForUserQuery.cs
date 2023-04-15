using MediatR;
using TeamProjectA.Domain.Entities.Workouts;

namespace TeamProjectA.Application.Queries.Workouts.GetWorkoutsForUser;

public class GetWorkoutsForUserQuery : IRequest<List<WorkoutDto>>
{
}