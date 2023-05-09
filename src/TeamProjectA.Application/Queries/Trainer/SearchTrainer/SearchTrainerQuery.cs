using System.ComponentModel.DataAnnotations;
using MediatR;

namespace TeamProjectA.Application.Queries.Trainer.SearchTrainer;

public class SearchTrainerQuery : IRequest<object>
{
    [Required] public string Login { get; set; } = null!;
}