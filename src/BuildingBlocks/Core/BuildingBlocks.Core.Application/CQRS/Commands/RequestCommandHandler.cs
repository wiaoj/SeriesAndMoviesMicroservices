using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Abstractions.CQRS.Commands.Handler;
using MediatR;

namespace BuildingBlocks.Core.Application.CQRS.Commands;
public abstract class RequestCommandHandler<TypeCommand> : IRequestCommandHandler<TypeCommand>
    where TypeCommand : IRequestCommand {
    protected abstract Task<Unit> HandleCommandAsync(TypeCommand command, CancellationToken cancellationToken);
    public async Task<Unit> Handle(TypeCommand command, CancellationToken cancellationToken) {
        return await HandleCommandAsync(command, cancellationToken);
    }
}

public abstract class RequestCommandHandler<TypeCommand, TypeResponse> : IRequestCommandHandler<TypeCommand, TypeResponse>
    where TypeCommand : IRequestCommand<TypeResponse>
    where TypeResponse : notnull {
    protected abstract Task<TypeResponse> HandleCommandAsync(TypeCommand command, CancellationToken cancellationToken);
    public async Task<TypeResponse> Handle(TypeCommand request, CancellationToken cancellationToken) {
        return await HandleCommandAsync(request, cancellationToken);
    }
}