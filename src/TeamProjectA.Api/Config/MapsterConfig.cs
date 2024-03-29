using Mapster;
using TeamProjectA.Application.Commands.Workouts.CreateWorkout;
using TeamProjectA.Application.Commands.Workouts.UpdateWorkout;
using TeamProjectA.Domain.Entities.Workouts;

namespace TeamProjectA.Api.Config;

public sealed class MapsterConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateWorkoutCommand, NewWorkout>()
            .Map(dest => dest.WorkoutDate, src => src.WorkoutDate.ToDateTime(TimeOnly.Parse("00:00")));

        config
            .NewConfig<UpdateWorkoutCommand, WorkoutDto>()
            .Map(dest => dest.WorkoutDate, src => src.WorkoutDate.ToDateTime(TimeOnly.Parse("00:00")));
    }
}