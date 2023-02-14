namespace BuildingBlocks.Core.Abstractions.Domain.Models;
public abstract class Entity<TypeId> : IEquatable<Entity<TypeId>> where TypeId : notnull {
    public TypeId Id { get; protected set; }
    protected Entity(TypeId id) => Id = id;

    public sealed override Boolean Equals(Object? @object) => @object is Entity<TypeId> entity && Id.Equals(entity.Id);
    public Boolean Equals(Entity<TypeId>? other) => Equals((Object?)other);
    public static Boolean operator ==(Entity<TypeId> left, Entity<TypeId> right) => Equals(left, right);
    public static Boolean operator !=(Entity<TypeId> left, Entity<TypeId> right) => Equals(left, right) is false;
    public sealed override Int32 GetHashCode() => Id.GetHashCode();
    public sealed override String ToString() {
        ArgumentNullException.ThrowIfNull(nameof(Id));
        return $"{Id}";
    }
}