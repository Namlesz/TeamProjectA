using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TeamProjectA.Infrastructure.Settings;

namespace TeamProjectA.Infrastructure.DAL;

public class WorkoutsContext
{
    private readonly IMongoDatabase _db;
    private readonly string _collectionName;

    public WorkoutsContext(IMongoDatabase db, IOptions<DbConfig> dbConfig)
    {
        _db = db;
        _collectionName = dbConfig.Value.WorkoutsCollection;
    }


    // TODO: Consider using a not generic method (defined object)
    public IMongoCollection<TDocument> GetCollection<TDocument>()
    {
        return _db.GetCollection<TDocument>(_collectionName);
    }
}