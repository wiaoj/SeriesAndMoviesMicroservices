namespace BuildingBlocks.Core.Exceptions.Types;

public class AppException : BaseException {
    public AppException(String message) : base(message, HttpStatusCode.BadRequest) { }
    public AppException(String message, HttpStatusCode statusCode) : base(message, statusCode) { }
}