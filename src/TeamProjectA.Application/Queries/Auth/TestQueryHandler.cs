using MediatR;

namespace TeamProjectA.Application.Queries.Auth;

public class TestQueryHandler : IRequestHandler<TestQuery, string>
{
    public Task<string> Handle(TestQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Hello World!");
    }
}