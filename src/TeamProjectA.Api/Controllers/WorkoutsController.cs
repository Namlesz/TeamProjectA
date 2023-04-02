using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TeamProjectA.Application.Commands.Workouts.CreateWorkout;
using TeamProjectA.Application.Commands.Workouts.DeleteWorkout;
using TeamProjectA.Application.Queries.Workouts.GetWorkoutDetailsById;
using TeamProjectA.Application.Queries.Workouts.GetWorkoutsForUser;
using TeamProjectA.Domain.Entities.BaseModels;
using TeamProjectA.Domain.Entities.Workouts;

namespace TeamProjectA.Api.Controllers;

[ApiController, Route("api/[controller]/[action]"), Produces("application/json")]
public sealed class WorkoutsController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkoutsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerOperation("Create a new workout")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Can't save workout")]
    public async Task<ActionResult<IdResult>> CreateWorkout([FromBody] CreateWorkoutCommand request) =>
        await _mediator.Send(request) switch
        {
            { } workoutId => Ok(new IdResult(workoutId.ToString())),
            null => BadRequest()
        };

    [HttpGet]
    [SwaggerOperation("Get workout detail by id")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Workout not found")]
    public async Task<ActionResult<WorkoutDto>> GetWorkoutDetails([FromQuery] GetWorkoutDetailsByIdQuery request) =>
        await _mediator.Send(request) switch
        {
            { } workout => Ok(workout),
            null => NotFound()
        };

    [HttpDelete]
    [SwaggerOperation("Delete workout by id")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Can't delete workout")]
    public async Task<ActionResult<WorkoutDto>> DeleteWorkout([FromQuery] DeleteWorkoutByIdCommand request) =>
        await _mediator.Send(request) switch
        {
            true => NoContent(),
            false => BadRequest()
        };

    [HttpGet]
    [SwaggerOperation("Get workouts for user")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<WorkoutDto>>> GetWorkouts([FromQuery] GetWorkoutsForUserQuery request) =>
        Ok(await _mediator.Send(request));
}