namespace BuildingBlocks.Core.Exceptions.Types;

public class UnAuthorizedException : IdentityException {
    public UnAuthorizedException(String message) : base(message, HttpStatusCode.Unauthorized) { }
}