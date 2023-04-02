using MongoDB.Driver;
using TeamProjectA.Infrastructure.Entities;

namespace TeamProjectA.Infrastructure.DAL;

public interface IWorkoutsContext
{
    public IMongoCollection<WorkoutEntity> GetCollection();
}