using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectA.Api.Auth;

namespace TeamProjectA.Api.Controllers;

[ApiController, Route("api/[controller]/[action]"), AllowAnonymous]
public sealed class AuthController : ControllerBase
{
    private readonly TokenManager _tokenManager;

    public AuthController(TokenManager tokenManager)
    {
        _tokenManager = tokenManager;
    }

    [HttpPost]
    public IActionResult Login([FromQuery] string login)
    {
        // TODO: Add user to db if not exists else get user from db
        var authClaims = new List<Claim>
        {
            // TODO: Claim for user id
            new("UserId", "2da7f6e6-326e-478c-a6a9-fa0983606e8c"),
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