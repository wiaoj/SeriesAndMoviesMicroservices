using BuildingBlocks.Core.Abstractions.Domain.Models;
using IdentityService.Domain.Exceptions;

namespace IdentityService.Domain.Users.ValueObjects;

public sealed class Email : ValueObject {
    public String Value { get; private set; }

    private Email(String value) {
        Value = value;
    }

    public static Email Create(String email) {
        return new(email);
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }


    public Email Update(String email) {
        if(Value.Equals(email))
            throw new UserEmailSameDomainException();

        return new(email);
    }

    //public static implicit operator Email(String email) => new(email);
    //public static implicit operator String(Email email) => email.Value;
}