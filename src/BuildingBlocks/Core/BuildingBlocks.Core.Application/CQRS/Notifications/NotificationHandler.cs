using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Abstractions.CQRS.Commands.Handler;
using MediatR;

namespace BuildingBlocks.Core.Application.CQRS.Notifications;
public abstract class NotificationHandler<TypeNotification> : INotificationHandler<TypeNotification>
    where TypeNotification : INotification {
    protected abstract Task HandleNotificationAsync(TypeNotification notification, CancellationToken cancellationToken);
    public async Task Handle(TypeNotification notification, CancellationToken cancellationToken) {
        await HandleNotificationAsync(notification, cancellationToken);
        await Task.CompletedTask;
    }    
}