using System.ComponentModel.DataAnnotations;
using MediatR;

namespace TeamProjectA.Application.Queries.Auth.GetUser;

public class GetUserQuery : IRequest<Guid?>
{
    [Required] public string Login { get; set; } = null!;
}