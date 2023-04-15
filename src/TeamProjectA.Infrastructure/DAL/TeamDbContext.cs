using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TeamProjectA.Infrastructure.Entities;
using TeamProjectA.Infrastructure.Settings;

namespace TeamProjectA.Infrastructure.DAL;

public class TeamDbContext : ITeamDbContext
{
    private readonly IMongoDatabase _db;
    private readonly string _collectionName;

    public TeamDbContext(IMongoDatabase db, IOptions<DbConfig> dbConfig)
    {
        _db = db;
        _collectionName = dbConfig.Value.WorkoutsCollection;
    }

    public IMongoCollection<WorkoutEntity> WorkoutsCollection => _db.GetCollection<WorkoutEntity>(_collectionName);
}