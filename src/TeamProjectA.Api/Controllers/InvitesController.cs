using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TeamProjectA.Application.Commands.Invites.SendInvite;
using TeamProjectA.Application.Queries.Invites.GetInvites;
using TeamProjectA.Domain.Entities.BaseModels;
using TeamProjectA.Domain.Entities.Invites;

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
    public async Task<ActionResult<IdResult>> SendInvite([FromQuery] SendInviteCommand request) =>
        await _mediator.Send(request) switch
        {
            { } inviteId => Ok(new IdResult(inviteId.ToString())),
            null => BadRequest()
        };

    [HttpGet]
    [SwaggerOperation("Get invites for user")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<InviteDto>>> GetInvites() =>
        Ok(await _mediator.Send(new GetInvitesQuery()));

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