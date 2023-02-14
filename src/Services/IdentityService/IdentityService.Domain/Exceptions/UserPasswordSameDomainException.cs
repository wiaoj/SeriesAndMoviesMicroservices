using BuildingBlocks.Core.Domain.Exceptions;

namespace IdentityService.Domain.Exceptions;

public sealed class UserPasswordSameDomainException : DomainException {
    public UserPasswordSameDomainException() : base("Şifreniz aynı olamaz") { }
    public UserPasswordSameDomainException(String message) : base(message) { }
}