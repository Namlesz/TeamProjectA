using System.ComponentModel.DataAnnotations;
using MediatR;

namespace TeamProjectA.Application.Commands.Auth.CreateUser;

public class CreateUserCommand : IRequest<Guid?>
{
    [Required] public string Login { get; set; } = null!;
}