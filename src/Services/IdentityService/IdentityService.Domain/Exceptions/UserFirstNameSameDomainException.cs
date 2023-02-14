using BuildingBlocks.Core.Domain.Exceptions;
using System.Net;

namespace IdentityService.Domain.Exceptions;
//public sealed class UserNotFoundDomainException : DomainException {
//    public UserNotFoundDomainException(String message, params String[] errors) : base(message, errors) { }
//}

public sealed class UserFirstNameSameDomainException : DomainException {
    public UserFirstNameSameDomainException() : base("İsminiz zaten aynı") { }
    public UserFirstNameSameDomainException(String message) : base(message) { }
}