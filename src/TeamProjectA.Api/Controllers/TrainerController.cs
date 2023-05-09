using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeamProjectA.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TrainerController
{
    private readonly IMediator _mediator;

    public TrainerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> SearchTrainer()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> GetTrainers()
    {
        throw new NotImplementedException();
    }
}