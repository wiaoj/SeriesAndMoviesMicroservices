namespace IdentityService.Persistence.Services.Authentication;
public class JwtSettings {
    public const String SECTION_NAME = nameof(JwtSettings);
    public String Secret { get; init; } = null!;
    public String Audience { get; init; } = null!;
    public String Issuer { get; init; } = null!;
    public Int32 ExpiryMinutes { get; init; }
    public String SecurityKey { get; init; } = null!;
    public Int32 RefreshTokenTTL { get; init; }
}