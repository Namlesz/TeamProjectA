using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TeamProjectA.Infrastructure.Entities;
using TeamProjectA.Infrastructure.Settings;

namespace TeamProjectA.Infrastructure.DAL;

public class WorkoutsContext : IWorkoutsContext
{
    private readonly IMongoDatabase _db;
    private readonly string _collectionName;

    public WorkoutsContext(IMongoDatabase db, IOptions<DbConfig> dbConfig)
    {
        _db = db;
        _collectionName = dbConfig.Value.WorkoutsCollection;
    }

    public IMongoCollection<WorkoutEntity> GetCollection() => _db.GetCollection<WorkoutEntity>(_collectionName);
}