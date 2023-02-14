namespace ActorService.Contracts;
public sealed record UpdateActorRequest(String? FirstName, String? LastName, Byte? Age, String? Country, String? Biography);