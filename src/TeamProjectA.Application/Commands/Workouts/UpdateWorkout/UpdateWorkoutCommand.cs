using System.ComponentModel.DataAnnotations;
using MediatR;
using TeamProjectA.Domain.Entities.BaseModels;

namespace TeamProjectA.Application.Commands.Workouts.UpdateWorkout;

public class UpdateWorkoutCommand : IRequest<IdResult?>
{
    [Required] public Guid Id { get; init; }
    [Required] public DateOnly WorkoutDate { get; init; }
    [Required] public string WorkoutName { get; init; } = null!;
    [Required] public Guid OwnerId { get; init; }
    [Required] public IEnumerable<WorkoutExerciseUpdate> Exercises { get; init; } = null!;
}

public sealed class WorkoutExerciseUpdate
{
    [Required] public string Name { get; init; } = null!;
    [Required] public int Reps { get; init; }
    [Required] public int Sets { get; init; }
    [Required] public string Description { get; init; } = null!;
}