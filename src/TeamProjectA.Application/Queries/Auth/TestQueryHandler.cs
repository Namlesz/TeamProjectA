using MediatR;
using TeamProjectA.Domain.Repositories;

namespace TeamProjectA.Application.Queries.Auth;

public class TestQueryHandler : IRequestHandler<TestQuery, bool>
{
    private readonly IUserRepository _userRepository;

    public TestQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(TestQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.TestMethod();
    }
}