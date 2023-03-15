using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamProjectA.Application.Queries.Auth;

namespace TeamProjectA.Api.Controllers;

[ApiController, Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Test() => Ok(await _mediator.Send(new TestQuery()));
}