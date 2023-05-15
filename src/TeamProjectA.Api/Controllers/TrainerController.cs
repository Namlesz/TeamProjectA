using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TeamProjectA.Application.Queries.Trainer.SearchTrainer;
using TeamProjectA.Domain.Entities.Users;

namespace TeamProjectA.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TrainerController : ControllerBase
{
    private readonly IMediator _mediator;

    public TrainerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation("Search users by login, show all results containing part of login")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<UserDto>>> SearchTrainer([FromQuery] SearchTrainerQuery request) =>
        Ok(await _mediator.Send(request));
}