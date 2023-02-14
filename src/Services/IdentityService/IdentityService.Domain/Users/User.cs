using BuildingBlocks.Core.Abstractions.Domain.Models;
using IdentityService.Domain.Exceptions;
using IdentityService.Domain.Users.ValueObjects;
using System.Security.Cryptography;
using System.Text;

namespace IdentityService.Domain.Users;
public sealed class User : AggregateRoot<UserId> {
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public PasswordSalt PasswordSalt { get; private set; }
    public PasswordHash PasswordHash { get; private set; }

    //public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    //public ICollection<RefreshToken> RefreshTokens { get; set; }
    //private readonly List<RefreshToken> _refreshTokens = new();
    //public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

    private User() : base(UserId.Create()) { }
    private User(UserId id,
                 FirstName firstName,
                 LastName lastName,
                 Email email,
                 PasswordSalt passwordSalt,
                 PasswordHash passwordHash) : base(id) {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        //_ = new UserCreatedDomainEvent() {
        //    User = this
        //};
    }

    public static User Create(FirstName firstName,
                              LastName lastName,
                              Email email,
                              String password) {
        (PasswordSalt passwordSalt, PasswordHash passwordHash) = CreatePassword(password);
        return new(UserId.Create(), firstName, lastName, email, passwordSalt, passwordHash);
    }

    public static User Create(String firstName, String lastName, String email, String password) {
        return Create(FirstName.Create(firstName), LastName.Create(lastName), Email.Create(email), password);
    }

    private static (PasswordSalt, PasswordHash) CreatePassword(String password) {
        using HMACSHA512 hmac = new();

        Byte[] passwordSalt = hmac.Key;
        Byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return (PasswordSalt.Create(passwordSalt), PasswordHash.Create(passwordHash));
    }

    public void VerifyPassword(String loginPassword) {
        using HMACSHA512 hmac = new(PasswordSalt.Value);

        Byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginPassword));

        if(computedHash.SequenceEqual(PasswordHash.Value) is false) {
            throw new Exception("Şifreniz yanlış");
        }
    }
}