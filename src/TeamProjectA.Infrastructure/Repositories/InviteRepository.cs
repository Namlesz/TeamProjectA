using TeamProjectA.Domain.Repositories;
using TeamProjectA.Infrastructure.DAL;
using TeamProjectA.Infrastructure.Entities;

namespace TeamProjectA.Infrastructure.Repositories;

public class InviteRepository : IInviteRepository
{
    private readonly ITeamDbContext _context;

    public InviteRepository(ITeamDbContext context)
    {
        _context = context;
    }

    public async Task<Guid?> CreateInvite(Guid invitedUserId, Guid ownerId)
    {
        var invite = new InviteEntity
        {
            InvitedUserId = invitedUserId,
            OwnerId = ownerId
        };

        try
        {
            await _context.InvitesCollection.InsertOneAsync(invite);
            return invite.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}