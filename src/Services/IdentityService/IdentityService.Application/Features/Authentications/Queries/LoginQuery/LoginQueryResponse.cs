using IdentityService.Domain.Entities;
using IdentityService.Domain.Users.Entities;

namespace IdentityService.Application.Features.Authentications.Queries.LoginQuery;

public sealed class LoginQueryResponse {
    public AccessToken Token { get; set; }
    public RefreshToken RefreshToken { get; set; }
}