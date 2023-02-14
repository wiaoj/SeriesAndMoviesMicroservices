namespace BuildingBlocks.Core.Abstractions.Domain.Models;

public abstract class AggregateRoot<TypeId> : Entity<TypeId> where TypeId : notnull {
    protected AggregateRoot(TypeId id) : base(id) { }
}