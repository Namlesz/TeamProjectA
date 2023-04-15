using MongoDB.Bson.Serialization.Attributes;

namespace TeamProjectA.Infrastructure.Entities;

public class UserEntity
{
    [BsonId] public Guid Id { get; set; }
    public string Login { get; set; } = null!;
}