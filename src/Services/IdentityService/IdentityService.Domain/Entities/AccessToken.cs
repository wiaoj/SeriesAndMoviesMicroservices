using BuildingBlocks.Core.Abstractions.Domain.Models;

namespace IdentityService.Domain.Entities;

//public class AccessToken : ValueObject {
//    public String Token { get; set; }
//    public DateTime Expiration { get; set; }

//    private AccessToken() { }


//    public override IEnumerable<Object> GetEqualityComponents() {
//        throw new NotImplementedException();
//    }
//}

public class AccessToken {
    public String Token { get; set; }
    public DateTime Expiration { get; set; }
}