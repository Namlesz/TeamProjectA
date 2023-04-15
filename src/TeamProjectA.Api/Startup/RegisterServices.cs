using System.Reflection;
using System.Text;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TeamProjectA.Api.Auth;
using TeamProjectA.Application.Queries.Auth;
using TeamProjectA.Domain.Repositories;
using TeamProjectA.Domain.Shared;
using TeamProjectA.Infrastructure.DAL;
using TeamProjectA.Infrastructure.Repositories;
using TeamProjectA.Infrastructure.Settings;

namespace TeamProjectA.Api.Startup;

internal static class RegisterServices
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
        builder.AddJwtBearerAuthentication();
        builder.Services.ConfigureSwagger();
        builder.Services.AddScoped<CurrentUser>();
        // builder.ConfigureIdentity(); // <-- Use for B2C
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
        services.AddSingleton<ITeamDbContext, TeamDbContext>();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWorkoutsRepository, WorkoutsRepository>();
    }

    // Use for B2C authentication
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

    private static void AddJwtBearerAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"] ??
                                                                        throw new MissingFieldException(
                                                                            "Can't load jwt key.")))
                };
            });
    }

    private static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
            options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter the Bearer Authorization string as following: `Bearer [token]`",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            options.OperationFilter<BasicAuthOperationsFilter>();
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Team App API",
                Version = "v1",
                Description = ".NET 7 WebAPI"
            });
        });
    }

    private static void ConfigureMongoDbConnection(this WebApplicationBuilder builder)
    {
#pragma warning disable CS0618
        BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
#pragma warning restore CS0618
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        var connectionString = builder.Configuration.GetConnectionString("TeamProjectAppDb");
        builder.Services.Configure<DbConfig>(builder.Configuration.GetSection("Database"));
        builder.Services.AddSingleton<IMongoDatabase>(sp =>
        {
            var dbConfig = sp.GetRequiredService<IOptions<DbConfig>>().Value;
            var mongoClient = new MongoClient(connectionString);

            return mongoClient.GetDatabase(dbConfig.DatabaseName);
        });
    }
}