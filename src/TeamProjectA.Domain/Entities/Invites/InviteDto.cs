namespace TeamProjectA.Domain.Entities.Invites;

public class InviteDto
{
    public Guid Id { get; set; }
    public Guid InvitedUserId { get; set; }
    public Guid InviteCreatorId { get; set; }
}