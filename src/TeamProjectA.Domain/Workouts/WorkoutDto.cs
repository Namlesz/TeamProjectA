namespace TeamProjectA.Domain.Workouts;

public sealed class WorkoutDto
{ 
    public Guid Id { get; set; }
    public DateTime WorkoutDate { get; set; }
    public string WorkoutName { get; set; } = null!;
    public string AuthorId { get; set; } = null!;
    public IEnumerable<ExerciseDto> Exercises { get; set; } = null!;
}

public sealed class ExerciseDto
{
    public string Name { get; set; } = null!;
    public int Reps { get; set; }
    public int Sets { get; set; }
    public string Description { get; set; } = null!;
}