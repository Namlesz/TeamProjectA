namespace TeamProjectA.Domain.Entities.Users;

public class UserDto
{
    public Guid Id { get; set; }
    public string Login { get; set; } = null!;
}