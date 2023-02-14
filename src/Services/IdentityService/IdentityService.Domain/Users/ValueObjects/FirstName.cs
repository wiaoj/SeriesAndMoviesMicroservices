using BuildingBlocks.Core.Abstractions.Domain.Models;

namespace IdentityService.Domain.Users.ValueObjects;
public sealed class FirstName : ValueObject {
    public const Byte VALUE_MAX_LENGTH = 64;
    public String Value { get; private set; }

    private FirstName(String value) {
        Value = value;
    }

    public static FirstName Create(String value) {
        ArgumentNullException.ThrowIfNullOrEmpty(value);

        if(value.Length > VALUE_MAX_LENGTH)
            throw new ArgumentException($"İsminiz çok uzun, {VALUE_MAX_LENGTH}'den uzun olamaz.");

        return new(value.Trim());
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }
}