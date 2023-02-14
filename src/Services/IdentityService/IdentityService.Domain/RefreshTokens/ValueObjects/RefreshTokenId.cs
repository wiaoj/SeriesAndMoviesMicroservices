//using BuildingBlocks.Core.Abstractions.Domain.Models;

//namespace IdentityService.Domain.RefreshTokens.ValueObjects;
//public class RefreshTokenId : ValueObject {
//    public Guid Value { get; private set; }
//    private RefreshTokenId(Guid value) {
//        Value = value;
//    }

//    public static RefreshTokenId GenerateUnique => new(Guid.NewGuid());


//    public override IEnumerable<Object> GetEqualityComponents() {
//        yield return Value;
//    }

//    public static implicit operator RefreshTokenId(Guid id) => new(id);
//}