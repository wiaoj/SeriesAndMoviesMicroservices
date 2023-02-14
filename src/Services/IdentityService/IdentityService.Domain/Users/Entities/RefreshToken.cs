using BuildingBlocks.Core.Abstractions.Domain.Models;
using IdentityService.Domain.Users.ValueObjects;
using IdentityService.Domain.Users.ValueObjects.RefreshTokenObjects;

namespace IdentityService.Domain.Users.Entities;

public class RefreshToken : Entity<RefreshTokenId> {
    public UserId UserId { get; private set; }
    public String Token { get; private set; }
    public DateTime Expires { get; private set; }
    public DateTime Created { get; private set; }
    public String CreatedByIp { get; private set; }
    public DateTime? Revoked { get; private set; }
    public String? RevokedByIp { get; private set; }
    public String? ReplacedByToken { get; private set; }
    public String? ReasonRevoked { get; private set; }
    public User User { get; private set; } = null!;

    private RefreshToken(RefreshTokenId id,
                        UserId userId,
                        String token,
                        DateTime expires,
                        DateTime created,
                        String createdByIp,
                        DateTime? revoked,
                        String? revokedByIp,
                        String? replacedByToken,
                        String? reasonRevoked) : base(id) {
        UserId = userId;
        Token = token;
        Expires = expires;
        Created = created;
        CreatedByIp = createdByIp;
        Revoked = revoked;
        RevokedByIp = revokedByIp;
        ReplacedByToken = replacedByToken;
        ReasonRevoked = reasonRevoked;
    }

    public static RefreshToken Create(UserId userId,
                        String token,
                        DateTime expires,
                        DateTime created,
                        String createdByIp,
                        DateTime? revoked,
                        String? revokedByIp,
                        String? replacedByToken,
                        String? reasonRevoked) {
        return new(RefreshTokenId.GenerateUnique, userId, token, expires, created, createdByIp, revoked, revokedByIp, replacedByToken, reasonRevoked);
    }
}