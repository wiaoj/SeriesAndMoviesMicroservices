using IdentityService.Application.Common.Persistence.Interfaces;

namespace IdentityService.Persistence.Services;
public class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
}