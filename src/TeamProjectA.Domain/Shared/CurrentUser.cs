namespace TeamProjectA.Domain.Shared;

public class CurrentUser
{
    public string Login { get; set; } = null!;
    public Guid UserId { get; set; }
}