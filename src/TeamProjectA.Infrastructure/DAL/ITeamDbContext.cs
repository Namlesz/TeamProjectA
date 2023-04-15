using MongoDB.Driver;
using TeamProjectA.Infrastructure.Entities;

namespace TeamProjectA.Infrastructure.DAL;

public interface ITeamDbContext
{
    public IMongoCollection<WorkoutEntity> WorkoutsCollection { get; }
    public IMongoCollection<UserEntity> UsersCollection { get; }

}