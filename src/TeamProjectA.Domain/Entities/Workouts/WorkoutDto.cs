namespace TeamProjectA.Domain.Entities.Workouts;

public sealed class WorkoutDto
{ 
    public Guid Id { get; set; }
    public DateTime WorkoutDate { get; set; }
    public string WorkoutName { get; set; } = null!;
    public Guid AuthorId { get; set; }
    public Guid OwnerId { get; set; }
    public IEnumerable<ExerciseDto> Exercises { get; set; } = null!;
}

public sealed class ExerciseDto
{
    public string Name { get; set; } = null!;
    public int Reps { get; set; }
    public int Sets { get; set; }
    public string Description { get; set; } = null!;
}