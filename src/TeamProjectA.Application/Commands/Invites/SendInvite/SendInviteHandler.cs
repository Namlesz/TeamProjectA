using MediatR;
using TeamProjectA.Domain.Repositories;
using TeamProjectA.Domain.Shared;

namespace TeamProjectA.Application.Commands.Invites.SendInvite;

public class SendInviteHandler : IRequestHandler<SendInviteCommand, Guid?>
{
    private readonly IInviteRepository _inviteRepository;
    private readonly CurrentUser _currentUser;

    public SendInviteHandler(IInviteRepository inviteRepository, CurrentUser currentUser)
    {
        _inviteRepository = inviteRepository;
        _currentUser = currentUser;
    }

    public Task<Guid?> Handle(SendInviteCommand request, CancellationToken cancellationToken) =>
        _inviteRepository.CreateInvite(request.UserIdToInvite, _currentUser.UserId);
}