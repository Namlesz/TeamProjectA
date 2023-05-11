using MediatR;
using TeamProjectA.Domain.Entities.Users;
using TeamProjectA.Domain.Repositories;

namespace TeamProjectA.Application.Queries.Trainer.SearchTrainer;

public class SearchTrainerHandler : IRequestHandler<SearchTrainerQuery, List<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public SearchTrainerHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<List<UserDto>> Handle(SearchTrainerQuery request, CancellationToken cancellationToken) =>
        _userRepository.SearchUser(request.Login);
}