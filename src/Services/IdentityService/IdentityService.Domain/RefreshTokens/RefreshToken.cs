//using BuildingBlocks.Core.Abstractions.Domain.Models;
//using IdentityService.Domain.Users;
//using IdentityService.Domain.Users.ValueObjects.RefreshTokenObjects;

//namespace IdentityService.Domain.RefreshTokens;

//public class RefreshToken : AggregateRoot<RefreshTokenId> {
//    public Guid UserId { get; private set; }
//    public String Token { get; private set; }
//    public DateTime Expires { get; private set; }
//    public DateTime Created { get; private set; }
//    public String CreatedByIp { get; private set; }
//    public DateTime? Revoked { get; private set; }
//    public String? RevokedByIp { get; private set; }
//    public String? ReplacedByToken { get; private set; }
//    public String? ReasonRevoked { get; private set; }
//    public User User { get; set; }

//    private RefreshToken(RefreshTokenId id,
//                        Guid userId,
//                        String token,
//                        DateTime expires,
//                        DateTime created,
//                        String createdByIp,
//                        DateTime? revoked,
//                        String? revokedByIp,
//                        String? replacedByToken,
//                        String? reasonRevoked) : base(id) {
//        UserId = userId;
//        Token = token;
//        Expires = expires;
//        Created = created;
//        CreatedByIp = createdByIp;
//        Revoked = revoked;
//        RevokedByIp = revokedByIp;
//        ReplacedByToken = replacedByToken;
//        ReasonRevoked = reasonRevoked;
//    }

//    public static RefreshToken Create(Guid userId,
//                        String token,
//                        DateTime expires,
//                        DateTime created,
//                        String createdByIp,
//                        DateTime? revoked,
//                        String? revokedByIp,
//                        String? replacedByToken,
//                        String? reasonRevoked) {
//        return new(RefreshTokenId.GenerateUnique, userId, token, expires, created, createdByIp, revoked, revokedByIp, replacedByToken, reasonRevoked);
//    }
//}