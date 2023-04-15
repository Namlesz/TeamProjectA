using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TeamProjectA.Infrastructure.Entities;
using TeamProjectA.Infrastructure.Settings;

namespace TeamProjectA.Infrastructure.DAL;

public class TeamDbContext : ITeamDbContext
{
    private readonly IMongoDatabase _db;
    private readonly IOptions<DbConfig> _dbConfig;

    public TeamDbContext(IMongoDatabase db, IOptions<DbConfig> dbConfig)
    {
        _db = db;
        _dbConfig = dbConfig;
    }

    public IMongoCollection<WorkoutEntity> WorkoutsCollection =>
        _db.GetCollection<WorkoutEntity>(_dbConfig.Value.WorkoutsCollection);
}