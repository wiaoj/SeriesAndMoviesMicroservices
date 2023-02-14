namespace BuildingBlocks.Core.Exceptions.Types;

public class ApiException : BaseException {
    public ApiException(String message) : base(message, HttpStatusCode.InternalServerError) { }
    public ApiException(String message, HttpStatusCode httpStatusCode) : base(message, httpStatusCode) { }
}