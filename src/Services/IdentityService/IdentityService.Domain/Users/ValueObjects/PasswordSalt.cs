using BuildingBlocks.Core.Abstractions.Domain.Models;

namespace IdentityService.Domain.Users.ValueObjects;
public sealed class PasswordSalt : ValueObject {
    public Byte[] Value { get; private set; }

    private PasswordSalt(Byte[] value) {
        Value= value;
    }

    public static PasswordSalt Create(Byte[] value) {
        return new(value);
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }
}
