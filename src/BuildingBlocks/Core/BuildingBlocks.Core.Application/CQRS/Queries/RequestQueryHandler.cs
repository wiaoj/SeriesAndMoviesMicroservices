using BuildingBlocks.Core.Abstractions.CQRS.Queries;
using BuildingBlocks.Core.Abstractions.CQRS.Queries.Handler;
using MediatR;

namespace BuildingBlocks.Core.Application.CQRS.Queries;
public abstract class RequestQueryHandler<TypeQuery> : IRequestQueryHandler<TypeQuery>
    where TypeQuery : IRequestQuery {
    protected abstract Task<Unit> HandleQueryAsync(TypeQuery query, CancellationToken cancellationToken);
    public async Task<Unit> Handle(TypeQuery command, CancellationToken cancellationToken) {
        return await HandleQueryAsync(command, cancellationToken);
    }
}

public abstract class RequestQueryHandler<TypeQuery, TypeResponse> : IRequestQueryHandler<TypeQuery, TypeResponse>
    where TypeQuery : IRequestQuery<TypeResponse>
    where TypeResponse : notnull {
    protected abstract Task<TypeResponse> HandleQueryAsync(TypeQuery query, CancellationToken cancellationToken);
    public async Task<TypeResponse> Handle(TypeQuery request, CancellationToken cancellationToken) {
        return await HandleQueryAsync(request, cancellationToken);
    }
}