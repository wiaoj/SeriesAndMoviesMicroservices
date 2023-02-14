using BuildingBlocks.Core.Abstractions.CQRS.Notifications;
using IdentityService.Domain.Users;

namespace IdentityService.Domain.Events;
public  class UserCreatedDomainEvent : INotification {
    public required User User { get; set; }
}