using MapsterMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TeamProjectA.Domain.Workouts;
using TeamProjectA.Infrastructure.DAL;
using TeamProjectA.Infrastructure.Entities;
using TeamProjectA.Infrastructure.Repositories.Interfaces;

namespace TeamProjectA.Infrastructure.Repositories.Classes;

public sealed class WorkoutsRepository : IWorkoutsRepository
{
    private readonly WorkoutsContext _context;
    private readonly IMapper _mapper;

    public WorkoutsRepository(WorkoutsContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid?> CreateWorkout(NewWorkout workout)
    {
        var newWorkout = _mapper.Map<NewWorkout, WorkoutEntity>(workout);
        try
        {
            await _context.GetCollection().InsertOneAsync(newWorkout);
            return newWorkout.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<WorkoutDto?> GetWorkoutDetailsById(Guid id) =>
        _mapper.Map<WorkoutEntity, WorkoutDto>(await _context.GetCollection().AsQueryable()
            .Where(x => x.Id == id).FirstOrDefaultAsync());

    public async Task<bool> DeleteWorkoutById(Guid requestId)
    {
        var result = await _context.GetCollection().DeleteOneAsync(x => x.Id == requestId);
        return result.IsAcknowledged && result.DeletedCount == 1;
    }
}