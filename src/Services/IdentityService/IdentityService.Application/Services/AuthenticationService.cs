using IdentityService.Application.Common.Authentication;
using IdentityService.Application.Common.Persistence.Interfaces;
using IdentityService.Application.Repositories;
using IdentityService.Application.Repositories.RefreshTokens;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Users;
using IdentityService.Domain.Users.Entities;
using IdentityService.Domain.Users.ValueObjects;

namespace IdentityService.Application.Services;
public class AuthenticationService : IAuthenticationService {
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;
    private readonly IRefreshTokenReadRepository _refreshTokenReadRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,
                                 IDateTimeProvider dateTimeProvider,
                                 IRefreshTokenWriteRepository refreshTokenWriteRepository,
                                 IRefreshTokenReadRepository refreshTokenReadRepository) {
        _jwtTokenGenerator = jwtTokenGenerator;
        _dateTimeProvider = dateTimeProvider;
        _refreshTokenWriteRepository = refreshTokenWriteRepository;
        _refreshTokenReadRepository = refreshTokenReadRepository;
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken, CancellationToken cancellationToken) {
        await _refreshTokenWriteRepository.AddAsync(refreshToken, cancellationToken);
        //await _refreshTokenWriteRepository.SaveChangesAsync(cancellationToken);
        return refreshToken;
    }

    public Task<String> ConvertSecretKeyToString(Byte[] secretKey) {
        throw new NotImplementedException();
    }

    public async Task<AccessToken> CreateAccessToken(User user) {
        return await Task.FromResult(_jwtTokenGenerator.GenerateToken(user));
    }

    public async Task<RefreshToken> CreateRefreshToken(User user, String ipAddress, CancellationToken cancellationToken) {
        return await Task.FromResult(await AddRefreshToken(_jwtTokenGenerator.GenerateRefreshToken(user, ipAddress), cancellationToken));
    }

    public async Task DeleteOldRefreshTokens(UserId userId, CancellationToken cancellationToken) {
        IQueryable<RefreshToken> refreshTokens = await _refreshTokenReadRepository.FindAsync(
            expression: x => x.UserId.Equals(userId) && 
            x.Revoked == null && 
            x.Expires >= _dateTimeProvider.UtcNow && 
            x.Created.AddDays(2) <= _dateTimeProvider.UtcNow,
            cancellationToken: cancellationToken);

        //foreach(RefreshToken refreshToken in refreshTokens)
        //    await _refreshTokenWriteRepository.DeleteAsync(refreshToken, cancellationToken);
        await _refreshTokenWriteRepository.DeleteRangeAsync(refreshTokens, cancellationToken);
        //await _refreshTokenWriteRepository.SaveChangesAsync(cancellationToken);
        await Task.CompletedTask;
    }

    public Task<RefreshToken?> GetRefreshTokenByToken(String token) {
        throw new NotImplementedException();
    }

    public Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, String ipAddress, String reason) {
        throw new NotImplementedException();
    }

    public Task RevokeRefreshToken(RefreshToken token, String ipAddress, String? reason = null, String? replacedByToken = null) {
        throw new NotImplementedException();
    }

    public Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, String ipAddress) {
        throw new NotImplementedException();
    }

    public Task SendAuthenticatorCode(User user) {
        throw new NotImplementedException();
    }

    public Task VerifyAuthenticatorCode(User user, String authenticatorCode) {
        throw new NotImplementedException();
    }
}