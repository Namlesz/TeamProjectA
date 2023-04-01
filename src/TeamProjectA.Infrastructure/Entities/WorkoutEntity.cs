using MongoDB.Bson.Serialization.Attributes;

namespace TeamProjectA.Infrastructure.Entities;

public class WorkoutEntity
{
    [BsonId] public Guid Id { get; set; }
    public DateTime WorkoutDate { get; set; }
    public string WorkoutName { get; set; }
    public Guid AuthorId { get; set; }
    public Guid OwnerId { get; set; }
    public IEnumerable<Exercise> Exercises { get; set; } = null!;
}

public class Exercise
{
    public string Name { get; set; } = null!;
    public int Reps { get; set; }
    public int Sets { get; set; }
    public string Description { get; set; } = null!;
}