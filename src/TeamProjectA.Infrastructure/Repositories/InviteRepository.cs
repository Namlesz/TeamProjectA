using MapsterMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TeamProjectA.Domain.Entities.Invites;
using TeamProjectA.Domain.Repositories;
using TeamProjectA.Infrastructure.DAL;
using TeamProjectA.Infrastructure.Entities;

namespace TeamProjectA.Infrastructure.Repositories;

public class InviteRepository : IInviteRepository
{
    private readonly ITeamDbContext _context;
    private readonly IMapper _mapper;

    public InviteRepository(ITeamDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid?> CreateInvite(Guid invitedUserId, Guid ownerId)
    {
        var invite = new InviteEntity
        {
            InvitedUserId = invitedUserId,
            InviteCreatorId = ownerId
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

    public async Task<List<InviteDto>> GetInvites(Guid userId) =>
        _mapper.Map<List<InviteEntity>, List<InviteDto>>(await _context.InvitesCollection
            .AsQueryable()
            .Where(x => x.InvitedUserId == userId)
            .ToListAsync());
}