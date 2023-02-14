using IdentityService.Domain.Entities;
using IdentityService.Domain.Users;
using IdentityService.Domain.Users.Entities;
using IdentityService.Domain.Users.ValueObjects;

namespace IdentityService.Application.Services;

public interface IAuthenticationService {
    public Task<AccessToken> CreateAccessToken(User user);
    public Task<RefreshToken> CreateRefreshToken(User user, String ipAddress, CancellationToken cancellationToken);
    public Task<RefreshToken?> GetRefreshTokenByToken(String token);
    public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken, CancellationToken cancellationToken);
    public Task DeleteOldRefreshTokens(UserId userId, CancellationToken cancellationToken);
    public Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, String ipAddress, String reason);

    public Task RevokeRefreshToken(RefreshToken token, String ipAddress, String? reason = null,
                                   String? replacedByToken = null);

    public Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, String ipAddress);
    //public Task<EmailAuthenticator> CreateEmailAuthenticator(User user);
    //public Task<OtpAuthenticator> CreateOtpAuthenticator(User user);
    public Task<String> ConvertSecretKeyToString(Byte[] secretKey);
    public Task SendAuthenticatorCode(User user);
    public Task VerifyAuthenticatorCode(User user, String authenticatorCode);
}