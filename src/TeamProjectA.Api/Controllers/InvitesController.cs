using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TeamProjectA.Application.Commands.Invites.SendInvite;
using TeamProjectA.Domain.Entities.BaseModels;

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
    [SwaggerOperation("Create invite for user")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Can't create invite")]
    public async Task<ActionResult<IdResult>> SendInvite([FromBody] SendInviteCommand request) =>
        await _mediator.Send(request) switch
        {
            { } inviteId => Ok(new IdResult(inviteId.ToString())),
            null => BadRequest()
        };

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