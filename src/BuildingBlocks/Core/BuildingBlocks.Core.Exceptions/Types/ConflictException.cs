namespace BuildingBlocks.Core.Exceptions.Types;

public class ConflictException : BaseException {
    public ConflictException(String message) : base(message, HttpStatusCode.Conflict) { }
}