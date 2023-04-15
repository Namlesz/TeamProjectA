using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectA.Api.Auth;
using TeamProjectA.Application.Commands.Auth.CreateUser;
using TeamProjectA.Application.Queries.Auth.GetUser;

namespace TeamProjectA.Api.Controllers;

[ApiController, Route("api/[controller]/[action]"), AllowAnonymous]
public sealed class AuthController : ControllerBase
{
    private readonly TokenManager _tokenManager;
    private readonly IMediator _mediator;

    public AuthController(TokenManager tokenManager, IMediator mediator)
    {
        _tokenManager = tokenManager;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromQuery] string login)
    {
        var userId = await _mediator.Send(new GetUserQuery { Login = login.ToLower() }) ??
                     await _mediator.Send(new CreateUserCommand { Login = login.ToLower() });

        if (userId is null)
            return BadRequest("Can't create user");

        var authClaims = new List<Claim>
        {
            new("UserId", userId.ToString()!),
            new(ClaimTypes.Name, login),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = _tokenManager.GetToken(authClaims);
        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }
}