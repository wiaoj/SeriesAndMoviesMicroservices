using IdentityService.Domain.Entities;
using IdentityService.Domain.Users;
using IdentityService.Domain.Users.Entities;

namespace IdentityService.Application.Common.Authentication;
public interface IJwtTokenGenerator {
    public AccessToken GenerateToken(User user);
    public RefreshToken GenerateRefreshToken(User user, String ipAddress);
}