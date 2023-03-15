using TeamProjectA.Application.Queries.Auth;

namespace TeamProjectA.Api.Startup;

public static class RegisterServices
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(
            typeof(TestQuery).Assembly
        ));

        return builder;
    }
}