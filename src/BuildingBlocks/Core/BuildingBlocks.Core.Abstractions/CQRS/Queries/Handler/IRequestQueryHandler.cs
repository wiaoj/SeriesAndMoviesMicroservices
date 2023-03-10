using MediatR;

namespace BuildingBlocks.Core.Abstractions.CQRS.Queries.Handler;
public interface IRequestQueryHandler<in TypeQuery, TypeResponse> : IRequestHandler<TypeQuery, TypeResponse>
    where TypeQuery : IRequestQuery<TypeResponse>
    where TypeResponse : notnull { }
public interface IRequestQueryHandler<in TypeQuery> : IRequestQueryHandler<TypeQuery, Unit>
    where TypeQuery : IRequestQuery<Unit> { }