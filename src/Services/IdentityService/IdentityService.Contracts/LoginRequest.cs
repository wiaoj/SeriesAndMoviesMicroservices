namespace IdentityService.Contracts;

public sealed record class LoginRequest(String Email, String Password);