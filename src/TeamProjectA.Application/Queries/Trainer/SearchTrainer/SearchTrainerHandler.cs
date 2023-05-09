using MediatR;

namespace TeamProjectA.Application.Queries.Trainer.SearchTrainer;

public class SearchTrainerHandler : IRequestHandler<SearchTrainerQuery, object>
{
    public Task<object> Handle(SearchTrainerQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}