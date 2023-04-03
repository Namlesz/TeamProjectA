using System.ComponentModel.DataAnnotations;
using MediatR;

namespace TeamProjectA.Application.Commands.Workouts.DeleteWorkout;

public class DeleteWorkoutByIdCommand : IRequest<bool>
{
    [Required] public Guid Id { get; init; }
}