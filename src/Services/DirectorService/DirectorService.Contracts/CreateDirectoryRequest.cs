namespace DirectorService.Contracts;
public sealed record CreateDirectorRequest(String FirstName, String LastName, Byte Age, String Country, String Biography);