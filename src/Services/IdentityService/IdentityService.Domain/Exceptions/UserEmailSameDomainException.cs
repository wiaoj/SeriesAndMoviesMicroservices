using BuildingBlocks.Core.Domain.Exceptions;

namespace IdentityService.Domain.Exceptions;

public sealed class UserEmailSameDomainException : DomainException {
    public UserEmailSameDomainException() : base("Emailiniz zaten aynı") { }
    public UserEmailSameDomainException(String message) : base(message) { }
}