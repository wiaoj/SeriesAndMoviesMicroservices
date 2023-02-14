using BuildingBlocks.Core.Domain.Exceptions;

namespace IdentityService.Domain.Exceptions;

public sealed class UserLastNameSameDomainException : DomainException {
    public UserLastNameSameDomainException() : base("Soyisminiz zaten aynı") { }
    public UserLastNameSameDomainException(String message) : base(message) { }
}