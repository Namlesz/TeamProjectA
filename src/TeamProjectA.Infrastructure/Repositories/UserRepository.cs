using MapsterMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TeamProjectA.Domain.Entities.Users;
using TeamProjectA.Domain.Repositories;
using TeamProjectA.Infrastructure.DAL;
using TeamProjectA.Infrastructure.Entities;

namespace TeamProjectA.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly ITeamDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(ITeamDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid?> CreateNewUser(NewUser newUser)
    {
        var user = new UserEntity
        {
            Login = newUser.Login
        };

        try
        {
            await _context.UsersCollection.InsertOneAsync(user);
            return user.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<Guid?> GetUser(string login) =>
        (await _context.UsersCollection
            .AsQueryable()
            .Where(x => x.Login == login)
            .FirstOrDefaultAsync())?.Id;

    public async Task<List<UserDto>> SearchUser(string login) =>
        _mapper.Map<List<UserEntity>, List<UserDto>>(await _context.UsersCollection
            .AsQueryable()
            .Where(x => x.Login.Contains(login))
            .ToListAsync());
}