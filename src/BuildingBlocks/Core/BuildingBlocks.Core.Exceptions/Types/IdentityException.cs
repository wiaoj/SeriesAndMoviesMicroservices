namespace BuildingBlocks.Core.Exceptions.Types;

public class IdentityException : BaseException {
    public IdentityException(String message, params String[] errors) : base(message, HttpStatusCode.BadRequest, errors) { }
    public IdentityException(String message, HttpStatusCode statusCode, params String[] errors) : base(message, statusCode, errors) { }
}