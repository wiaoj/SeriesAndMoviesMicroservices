public abstract class ValueObject : IEquatable<ValueObject> {
    public abstract IEnumerable<Object> GetEqualityComponents();

    public override Boolean Equals(Object? @object) {
        if(@object is null || @object.GetType() != GetType())
            return false;
        ValueObject? valueObject = @object as ValueObject;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public static Boolean operator ==(ValueObject left, ValueObject right) => Equals(left, right);
    public static Boolean operator !=(ValueObject left, ValueObject right) => Equals(left, right) is false;
    public override Int32 GetHashCode() => GetEqualityComponents().Select(x => x?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
    public Boolean Equals(ValueObject? other) => Equals((Object?)other);

    //public Boolean Equals(this ValueObject valueObject, ValueObject otherValueObject) {
    //    return this.GetEqualityComponents() == otherValueObject.GetEqualityComponents();
    //}
}
