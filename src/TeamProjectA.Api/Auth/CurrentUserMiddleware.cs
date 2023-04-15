using System.Security.Claims;
using TeamProjectA.Domain.Shared;

namespace TeamProjectA.Api.Auth;

internal sealed class CurrentUserMiddleware
{
    private readonly RequestDelegate _next;

    public CurrentUserMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, CurrentUser currentUser)
    {
        try
        {
            if (context.User.Identity is ClaimsIdentity { IsAuthenticated: true } identity)
            {
                currentUser.Login = identity.Claims.Where(x =>
                        x.Type == ClaimTypes.Name && !string.IsNullOrEmpty(x.Value))
                    .Select(x => x.Value).FirstOrDefault() ?? throw new MissingMemberException();

                currentUser.UserId = context.User.FindFirst("UserId")?.Value switch
                {
                    { } userId => Guid.Parse(userId),
                    null => throw new MissingMemberException()
                };
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
        finally
        {
            await _next.Invoke(context);
        }
    }
}