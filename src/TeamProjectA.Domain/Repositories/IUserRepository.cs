using TeamProjectA.Domain.Entities.Users;

namespace TeamProjectA.Domain.Repositories;

public interface IUserRepository
{
    public Task<Guid?> CreateNewUser(NewUser newUser);
    public Task<Guid?> GetUser(string login);
    public Task<List<UserDto>> SearchUser(string login);
}