using Mapster;
using TeamProjectA.Application.Commands.Workouts.CreateWorkout;
using TeamProjectA.Domain.Workouts;

namespace TeamProjectA.Api.Config;

public class MapsterConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateWorkoutCommand, NewWorkout>()
            .Map(dest => dest.WorkoutDate, src => src.WorkoutDate.ToDateTime(TimeOnly.Parse("00:00")));
    }
}