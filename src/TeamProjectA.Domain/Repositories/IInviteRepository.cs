using TeamProjectA.Domain.Entities.Invites;

namespace TeamProjectA.Domain.Repositories;

public interface IInviteRepository
{
    public Task<Guid?> CreateInvite(Guid invitedUserId, Guid ownerId);
    public Task<List<InviteDto>> GetInvites(Guid userId);
}