using BuildingBlocks.Core.Abstractions.Domain.Models;

namespace IdentityService.Domain.Users.ValueObjects.RefreshTokenObjects;
public class RefreshTokenId : ValueObject {
    public Guid Value { get; private set; }
    private RefreshTokenId(Guid value) {
        Value = value;
    }

    public static RefreshTokenId GenerateUnique => new(Guid.NewGuid());


    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }
}