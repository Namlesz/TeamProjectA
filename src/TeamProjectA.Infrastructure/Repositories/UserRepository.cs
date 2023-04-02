using MongoDB.Bson.Serialization.Attributes;
using TeamProjectA.Domain.Repositories;
using TeamProjectA.Infrastructure.DAL;

namespace TeamProjectA.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly UserContext _context;

    public UserRepository(UserContext context)
    {
        _context = context;
    }

    public async Task<bool> TestMethod()
    {
        try
        {
            await _context.GetCollection<TestPost>().InsertOneAsync(new TestPost { Name = "test" });
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}

internal class TestPost
{
    [BsonId] public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}