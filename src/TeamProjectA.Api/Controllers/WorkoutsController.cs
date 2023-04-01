using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TeamProjectA.Application.Commands.Workouts.CreateWorkout;
using TeamProjectA.Application.Queries.Workouts.GetWorkoutDetailsById;
using TeamProjectA.Domain.Workouts;

namespace TeamProjectA.Api.Controllers;

[ApiController, Route("api/[controller]/[action]")]
public sealed class WorkoutsController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkoutsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerOperation("Create a new workout")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Workout successful created")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Can't save workout")]
    public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutCommand command) =>
        await _mediator.Send(command) switch
        {
            { } workoutId => Ok(workoutId),
            null => BadRequest()
        };

    [HttpGet]
    [SwaggerOperation("Get workout detail by id")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Workout not found")]
    public async Task<ActionResult<WorkoutDto>> GetWorkoutDetailsById([FromQuery] GetWorkoutDetailsByIdQuery request) =>
        await _mediator.Send(request) switch
        {
            { } workout => Ok(workout),
            null => NotFound()
        };

    // TODO: Endpoint -> GetWorkoutListByDay
    // TODO: Endpoint -> Remove workout
}