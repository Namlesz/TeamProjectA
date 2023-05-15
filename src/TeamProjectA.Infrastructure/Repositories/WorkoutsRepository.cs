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

    public async Task<Guid?> CreateWorkout(NewWorkout workout, CancellationToken cancellationToken)
    {
        var newWorkout = _mapper.Map<NewWorkout, WorkoutEntity>(workout);
        try
        {
            await _context.WorkoutsCollection.InsertOneAsync(newWorkout, cancellationToken: cancellationToken);
            return newWorkout.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<WorkoutDto?> GetWorkoutDetailsById(Guid workoutId, CancellationToken cancellationToken) =>
        _mapper.Map<WorkoutEntity, WorkoutDto>(await _context.WorkoutsCollection
            .AsQueryable()
            .Where(x => x.Id == workoutId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken));

    public async Task<bool> DeleteWorkoutById(Guid workoutId, CancellationToken cancellationToken)
    {
        var result =
            await _context.WorkoutsCollection.DeleteOneAsync(x => x.Id == workoutId,
                cancellationToken: cancellationToken);
        return result.IsAcknowledged && result.DeletedCount == 1;
    }

    public async Task<List<WorkoutDto>> GetWorkoutsForUser(Guid userId, CancellationToken cancellationToken) =>
        _mapper.Map<List<WorkoutEntity>, List<WorkoutDto>>(await _context.WorkoutsCollection
            .AsQueryable()
            .Where(x => x.OwnerId == userId)
            .ToListAsync(cancellationToken: cancellationToken));

    public async Task<List<WorkoutDto>> GetCreatedWorkouts(
        Guid currentUserUserId,
        CancellationToken cancellationToken
    ) =>
        _mapper.Map<List<WorkoutEntity>, List<WorkoutDto>>(await _context.WorkoutsCollection
            .AsQueryable()
            .Where(x => x.OwnerId == currentUserUserId)
            .ToListAsync(cancellationToken: cancellationToken));
}