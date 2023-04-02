using Mapster;
using MapsterMapper;
using TeamProjectA.Api.Config;

namespace TeamProjectA.Tests;

public static class AddMapsterForUnitTests
{
    public static Mapper GetMapper()
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(MapsterConfig).Assembly);
        return new Mapper(config);
    }
}