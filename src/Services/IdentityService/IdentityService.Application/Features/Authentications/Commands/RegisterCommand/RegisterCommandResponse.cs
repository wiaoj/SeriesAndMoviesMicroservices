using IdentityService.Domain.Entities;
using IdentityService.Domain.Users.Entities;

namespace IdentityService.Application.Features.Authentications.Commands.RegisterCommand;

public sealed class RegisterCommandResponse {
    public AccessToken Token { get; set; }
    public RefreshToken RefreshToken { get; set; }
}