using MapsterMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TeamProjectA.Domain.Entities.Workouts;
using TeamProjectA.Domain.Repositories;
using TeamProjectA.Infrastructure.DAL;
using TeamProjectA.Infrastructure.Entities;

namespace TeamProjectA.Infrastructure.Repositories;

public sealed class WorkoutsRepository : IWorkoutsRepository
{
    private readonly IWorkoutsContext _context;
    private readonly IMapper _mapper;

    public WorkoutsRepository(IWorkoutsContext context, IMapper mapper)
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

    public async Task<WorkoutDto?> GetWorkoutDetailsById(Guid workoutId) =>
        _mapper.Map<WorkoutEntity, WorkoutDto>(await _context.GetCollection().AsQueryable()
            .Where(x => x.Id == workoutId).FirstOrDefaultAsync());

    public async Task<bool> DeleteWorkoutById(Guid workoutId)
    {
        var result = await _context.GetCollection().DeleteOneAsync(x => x.Id == workoutId);
        return result.IsAcknowledged && result.DeletedCount == 1;
    }

    public async Task<List<WorkoutDto>> GetWorkoutsForUser(Guid userId)
    {
        var workouts = await _context.GetCollection().AsQueryable().Where(x => x.OwnerId == userId).ToListAsync();
        return _mapper.Map<List<WorkoutEntity>, List<WorkoutDto>>(workouts);
    }
}