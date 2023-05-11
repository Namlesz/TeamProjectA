using System.ComponentModel.DataAnnotations;
using MediatR;
using TeamProjectA.Domain.Entities.Users;

namespace TeamProjectA.Application.Queries.Trainer.SearchTrainer;

public class SearchTrainerQuery : IRequest<List<UserDto>>
{
    [Required] public string Login { get; set; } = null!;
}