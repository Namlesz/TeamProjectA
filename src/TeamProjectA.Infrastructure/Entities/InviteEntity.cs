using MongoDB.Bson.Serialization.Attributes;

namespace TeamProjectA.Infrastructure.Entities;

public class InviteEntity
{
    [BsonId] public Guid Id { get; set; }
    public Guid InvitedUserId { get; set; }
    public Guid InviteCreatorId { get; set; }
}