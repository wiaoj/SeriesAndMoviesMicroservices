using IdentityService.Domain.Entities;
using IdentityService.Domain.Users.Entities;

namespace IdentityService.Contracts;
public sealed record class AuthenticationResponse(AccessToken Token, RefreshToken RefreshToken);