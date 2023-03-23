using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TeamProjectA.Application.Queries.Auth;

namespace TeamProjectA.Api.Controllers;

[ApiController, Route("api/[controller]/[action]")]
[RequiredScope("taskread")]
[Authorize]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
    }


    [HttpGet]
    public Task<IActionResult> Hello() =>
        Task.FromResult<IActionResult>(Ok("_httpContextAccessor.HttpContext?.User.Identity?.Name"));


    [HttpGet]
    public async Task<IActionResult> Test() => Ok(await _mediator.Send(new TestQuery()));
}