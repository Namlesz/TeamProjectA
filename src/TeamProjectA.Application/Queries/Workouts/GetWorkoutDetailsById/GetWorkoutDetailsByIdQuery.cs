using System.ComponentModel.DataAnnotations;
using MediatR;
using TeamProjectA.Domain.Entities.Workouts;

namespace TeamProjectA.Application.Queries.Workouts.GetWorkoutDetailsById;

public sealed class GetWorkoutDetailsByIdQuery : IRequest<WorkoutDto?>
{
    [Required] public Guid Id { get; init; }
}