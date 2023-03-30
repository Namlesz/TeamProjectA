using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TeamProjectA.Application.Commands.Workouts.CreateWorkout;

namespace TeamProjectA.Api.Controllers;

[ApiController, Route("api/[controller]/[action]")]
public class WorkoutsController : ControllerBase
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
            true => NoContent(),
            false => Problem()
        };
}