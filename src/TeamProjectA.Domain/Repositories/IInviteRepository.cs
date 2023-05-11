namespace TeamProjectA.Domain.Repositories;

public interface IInviteRepository
{
    public Task<Guid?> CreateInvite(Guid invitedUserId, Guid ownerId);
}