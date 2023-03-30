using System.ComponentModel.DataAnnotations;
using MediatR;

namespace TeamProjectA.Application.Commands.Workouts.CreateWorkout;

public class CreateWorkoutCommand : IRequest<bool>
{
    [Required] public DateOnly WorkoutDate { get; set; }
    [Required] public string WorkoutName { get; set; } = null!;
    [Required] public string AuthorId { get; set; } = null!;
    [Required] public IEnumerable<WorkoutExercise> Exercises { get; set; } = null!;
}

public class WorkoutExercise
{
    [Required] public string Name { get; set; } = null!;
    [Required] public int Reps { get; set; }
    [Required] public int Sets { get; set; }
    [Required] public string Description { get; set; } = null!;
}