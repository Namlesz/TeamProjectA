namespace TeamProjectA.Infrastructure.Settings;

public sealed class DbConfig
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string UsersCollection { get; set; } = null!;
    public string WorkoutsCollection { get; set; } = null!;
}