namespace BuildingBlocks.Core.Exceptions.Types;
public class BaseException : Exception {
    public HttpStatusCode StatusCode { get; private set; }
    public IEnumerable<String> ErrorMessages { get; private set; }
    public BaseException(String message, params String[] errors) : this(message, HttpStatusCode.InternalServerError, errors) { }
    public BaseException(String message, HttpStatusCode statusCode, params String[] errors) : base(message) {
        StatusCode = statusCode;
        ErrorMessages = errors;
    }
}