using MediatR;
using TeamProjectA.Domain.Repositories;

namespace TeamProjectA.Application.Queries.Auth.GetUser;

public class GetUserHandler : IRequestHandler<GetUserQuery, Guid?>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid?> Handle(GetUserQuery request, CancellationToken cancellationToken) =>
        await _userRepository.GetUser(request.Login);
}