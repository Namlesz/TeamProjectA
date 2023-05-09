using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamProjectA.Application.Queries.Trainer.SearchTrainer;

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

    // TODO: Active
    [HttpGet]
    public async Task<IActionResult> SearchTrainer([FromQuery] SearchTrainerQuery request) =>
        Ok(await _mediator.Send(request));

    [HttpGet]
    public async Task<IActionResult> GetTrainers()
    {
        throw new NotImplementedException();
    }
}