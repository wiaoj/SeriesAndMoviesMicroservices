using BuildingBlocks.Core.Exceptions.Types;
using System.Net;

namespace BuildingBlocks.Core.Domain.Exceptions;
//public class DomainException : BaseException {
//    public DomainException(String message, params String[] errors) : base(message, HttpStatusCode.BadRequest, errors) { }
//    public DomainException(String message, HttpStatusCode statusCode, params String[] errors) : base(message, statusCode, errors) { }
//}

public class DomainException : Exception {
    public DomainException(String message) : base(message) { }
}