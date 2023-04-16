using MediatR;
using TeamProjectA.Domain.Entities.Users;
using TeamProjectA.Domain.Repositories;

namespace TeamProjectA.Application.Commands.Auth.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid?>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<Guid?> Handle(CreateUserCommand request, CancellationToken cancellationToken) =>
        _userRepository.CreateNewUser(new NewUser { Login = request.Login });
}