using TeamProjectA.Domain.Workouts;
using TeamProjectA.Infrastructure.DAL;
using TeamProjectA.Infrastructure.Repositories.Interfaces;

namespace TeamProjectA.Infrastructure.Repositories.Classes;

public class WorkoutsRepository : IWorkoutsRepository
{
    private readonly WorkoutsContext _context;

    public WorkoutsRepository(WorkoutsContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateWorkout(NewWorkout workout)
    {
        try
        {
            await _context.GetCollection<NewWorkout>().InsertOneAsync(workout);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}