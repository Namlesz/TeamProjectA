using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeamProjectA.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class FriendsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FriendsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetFriends()
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveFriend()
    {
        throw new NotImplementedException();
    }
}