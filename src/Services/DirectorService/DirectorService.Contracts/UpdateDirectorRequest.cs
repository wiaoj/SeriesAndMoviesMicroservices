namespace DirectorService.Contracts;
public sealed record UpdateDirectorRequest(String? FirstName, String? LastName, Byte? Age, String? Country, String? Biography);