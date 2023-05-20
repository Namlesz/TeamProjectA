using MediatR;
using TeamProjectA.Domain.Entities.Invites;
using TeamProjectA.Domain.Repositories;
using TeamProjectA.Domain.Shared;

namespace TeamProjectA.Application.Queries.Invites.GetInvites;

public class GetInvitesHandler : IRequestHandler<GetInvitesQuery, List<InviteDto>>
{
    private readonly IInviteRepository _inviteRepository;
    private readonly CurrentUser _currentUser;

    public GetInvitesHandler(IInviteRepository inviteRepository, CurrentUser currentUser)
    {
        _inviteRepository = inviteRepository;
        _currentUser = currentUser;
    }

    public Task<List<InviteDto>> Handle(GetInvitesQuery request, CancellationToken cancellationToken) =>
        _inviteRepository.GetInvites(_currentUser.UserId);
}