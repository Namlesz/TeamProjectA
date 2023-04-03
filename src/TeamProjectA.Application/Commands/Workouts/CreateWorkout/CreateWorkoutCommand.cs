using System.ComponentModel.DataAnnotations;
using MediatR;

namespace TeamProjectA.Application.Commands.Workouts.CreateWorkout;

public sealed class CreateWorkoutCommand : IRequest<Guid?>
{
    [Required] public DateOnly WorkoutDate { get; init; }
    [Required] public string WorkoutName { get; init; } = null!;
    [Required] public Guid AuthorId { get; init; }
    [Required] public Guid OwnerId { get; init; }
    [Required] public IEnumerable<WorkoutExercise> Exercises { get; init; } = null!;
}

public sealed class WorkoutExercise
{
    [Required] public string Name { get; init; } = null!;
    [Required] public int Reps { get; init; }
    [Required] public int Sets { get; init; }
    [Required] public string Description { get; init; } = null!;
}