using Microsoft.Extensions.Options;
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

        return builder;
    }

    private static void AddDbContexts(this IServiceCollection services)
    {
        services.AddSingleton<UserContext>();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
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