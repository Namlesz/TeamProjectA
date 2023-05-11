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
    private readonly ITeamDbContext _context;
    private readonly IMapper _mapper;

    public WorkoutsRepository(ITeamDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid?> CreateWorkout(NewWorkout workout)
    {
        var newWorkout = _mapper.Map<NewWorkout, WorkoutEntity>(workout);
        try
        {
            await _context.WorkoutsCollection.InsertOneAsync(newWorkout);
            return newWorkout.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<WorkoutDto?> GetWorkoutDetailsById(Guid workoutId) =>
        _mapper.Map<WorkoutEntity, WorkoutDto>(await _context.WorkoutsCollection
            .AsQueryable()
            .Where(x => x.Id == workoutId)
            .FirstOrDefaultAsync());

    public async Task<bool> DeleteWorkoutById(Guid workoutId)
    {
        var result = await _context.WorkoutsCollection.DeleteOneAsync(x => x.Id == workoutId);
        return result.IsAcknowledged && result.DeletedCount == 1;
    }

    public async Task<List<WorkoutDto>> GetWorkoutsForUser(Guid userId) =>
        _mapper.Map<List<WorkoutEntity>, List<WorkoutDto>>(await _context.WorkoutsCollection
            .AsQueryable()
            .Where(x => x.OwnerId == userId)
            .ToListAsync());
}