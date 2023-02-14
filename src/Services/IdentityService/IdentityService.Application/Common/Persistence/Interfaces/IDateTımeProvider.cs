namespace IdentityService.Application.Common.Persistence.Interfaces;
public interface IDateTimeProvider {
    public DateTime UtcNow { get; }
}