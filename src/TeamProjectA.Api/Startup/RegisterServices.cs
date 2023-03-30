using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TeamProjectA.Application.Queries.Auth;
using TeamProjectA.Infrastructure.DAL;
using TeamProjectA.Infrastructure.Repositories.Classes;
using TeamProjectA.Infrastructure.Repositories.Interfaces;
using TeamProjectA.Infrastructure.Settings;

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

        builder.ConfigureMongoDbConnection();
        builder.Services.AddDbContexts();
        builder.Services.AddRepositories();
        builder.Services.AddMapster();
        builder.ConfigureIdentity();
        return builder;
    }

    private static void AddMapster(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddScoped<IMapper, ServiceMapper>();
    }

    private static void AddDbContexts(this IServiceCollection services)
    {
        services.AddSingleton<UserContext>();
        services.AddSingleton<WorkoutsContext>();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWorkoutsRepository, WorkoutsRepository>();
    }

    private static void ConfigureIdentity(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(options =>
                {
                    builder.Configuration.Bind("AzureAdB2C", options);

                    options.TokenValidationParameters.NameClaimType = "name";
                },
                options => { builder.Configuration.Bind("AzureAdB2C", options); });
    }

    private static void ConfigureMongoDbConnection(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<DbConfig>(builder.Configuration.GetSection("Database"));
        builder.Services.AddSingleton<IMongoDatabase>(sp =>
        {
            var dbConfig = sp.GetRequiredService<IOptions<DbConfig>>().Value;
            var mongoClient = new MongoClient(dbConfig.ConnectionString);

            return mongoClient.GetDatabase(dbConfig.DatabaseName);
        });

        // Set GuidRepresentation to Standard
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
    }
}