namespace ActorService.Contracts;
public sealed record CreateActorRequest(String FirstName, String LastName, Byte Age, String Country, String Biography);