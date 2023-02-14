namespace IdentityService.Contracts;
public sealed record class RegisterRequest(String FirstName, String LastName, String Email, String Password);