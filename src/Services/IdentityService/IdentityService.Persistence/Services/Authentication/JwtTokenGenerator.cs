using IdentityService.Application.Common.Authentication;
using IdentityService.Application.Common.Persistence.Interfaces;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Users;
using IdentityService.Domain.Users.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace IdentityService.Persistence.Services.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator {
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings, IDateTimeProvider dateTimeProvider) {
        _jwtSettings = jwtSettings.Value;
        _dateTimeProvider = dateTimeProvider;
    }

    public AccessToken GenerateToken(User user) {
        DateTime tokenExpiration = _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes);
        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        Claim[] claims = GetClaims(user);

        JwtSecurityToken jwtSecurityToken = CreateJwtSecurityToken(tokenExpiration, signingCredentials, claims);

        return new() {
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Expiration = tokenExpiration
        };
    }

    public RefreshToken GenerateRefreshToken(User user, String ipAddress) {
        DateTime time = _dateTimeProvider.UtcNow;
        RefreshToken refreshToken = RefreshToken.Create(
            userId: user.Id,
            token: GenerateRandomRefreshToken(),
            expires: time.AddDays(7),
            created: time,
            createdByIp: ipAddress,
            revoked: time,
            revokedByIp: "",
            replacedByToken: "",
            reasonRevoked: "");

        return refreshToken;
    }

    private Claim[] GetClaims(User user) {
        return new Claim[] {
            new(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
            new(JwtRegisteredClaimNames.GivenName, user.FirstName.Value),
            new(JwtRegisteredClaimNames.FamilyName, user.LastName.Value),
            new(JwtRegisteredClaimNames.Name, $"{user.FirstName.Value} {user.LastName.Value}"),
            new(JwtRegisteredClaimNames.Jti, $"{Guid.NewGuid()}-{Guid.NewGuid()}"),
            new(JwtRegisteredClaimNames.Email, user.Email.Value),
            new(JwtRegisteredClaimNames.AuthTime, _dateTimeProvider.UtcNow.ToString())
        };
    }

    private JwtSecurityToken CreateJwtSecurityToken(DateTime tokenExpiration,
                                                    SigningCredentials signingCredentials,
                                                    Claim[] claims) {
        return new(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            notBefore: _dateTimeProvider.UtcNow,
            expires: tokenExpiration,
            signingCredentials: signingCredentials);
    }

    private String GenerateRandomRefreshToken() {
        Byte[] numberByte = new Byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(numberByte);
        return Convert.ToBase64String(numberByte);
    }
}