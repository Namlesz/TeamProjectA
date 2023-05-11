using System.ComponentModel.DataAnnotations;
using MediatR;

namespace TeamProjectA.Application.Commands.Invites.SendInvite;

public record SendInviteCommand([Required] Guid UserIdToInvite) : IRequest<Guid?>;