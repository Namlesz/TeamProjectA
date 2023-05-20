using MediatR;
using TeamProjectA.Domain.Entities.Invites;

namespace TeamProjectA.Application.Queries.Invites.GetInvites;

public sealed record GetInvitesQuery : IRequest<List<InviteDto>>;