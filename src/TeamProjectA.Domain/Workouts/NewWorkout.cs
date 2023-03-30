namespace TeamProjectA.Domain.Workouts;

public class NewWorkout
{
    public DateTime WorkoutDate { get; set; }
    public string WorkoutName { get; set; } = null!;
    public string AuthorId { get; set; } = null!;
    public IEnumerable<NewExercise> Exercises { get; set; } = null!;
}

public class NewExercise
{
    public string Name { get; set; } = null!;
    public int Reps { get; set; }
    public int Sets { get; set; }
    public string Description { get; set; } = null!;
}