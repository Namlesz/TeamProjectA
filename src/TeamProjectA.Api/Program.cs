using TeamProjectA.Api.Startup;

WebApplication
    .CreateBuilder(args)
    .ConfigureServices()
    .Build()
    .SetupMiddleware()
    .Run();