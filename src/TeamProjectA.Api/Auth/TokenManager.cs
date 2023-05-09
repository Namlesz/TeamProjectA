using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TeamProjectA.Api.Auth;

public sealed class TokenManager
{
    private readonly IConfiguration _configuration;

    public TokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["JWT:Secret"] ?? throw new MissingFieldException("Can't load encode key.")
            )
        );

        var token = new JwtSecurityToken(
            claims: authClaims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }

    public string GetTokenString(IEnumerable<Claim> authClaims) =>
        new JwtSecurityTokenHandler().WriteToken(GetToken(authClaims));
}