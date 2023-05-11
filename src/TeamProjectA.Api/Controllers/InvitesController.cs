using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeamProjectA.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class InvitesController : ControllerBase
{
    private readonly IMediator _mediator;

    public InvitesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SendInvite()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> GetInvites()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> ApproveInvite()
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public async Task<IActionResult> RejectInvite()
    {
        throw new NotImplementedException();
    }
}