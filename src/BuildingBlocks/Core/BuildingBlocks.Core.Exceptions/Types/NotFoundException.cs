namespace BuildingBlocks.Core.Exceptions.Types;

public class NotFoundException : BaseException {
    public NotFoundException(String message) : base(message, HttpStatusCode.NotFound) { }
}