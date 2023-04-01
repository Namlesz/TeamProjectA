namespace TeamProjectA.Domain.Entities.Workouts;

public sealed class NewWorkout
{
    public DateTime WorkoutDate { get; set; }
    public string WorkoutName { get; set; } = null!;
    public Guid AuthorId { get; set; }
    public Guid OwnerId { get; set; }
    public IEnumerable<NewExercise> Exercises { get; set; } = null!;
}

public sealed class NewExercise
{
    public string Name { get; set; } = null!;
    public int Reps { get; set; }
    public int Sets { get; set; }
    public string Description { get; set; } = null!;
}