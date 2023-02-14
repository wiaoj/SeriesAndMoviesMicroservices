namespace ActorService.Application.Dtos;
public sealed record ActorDto(Guid Id,
                                 String FirstName,
                                 String LastName,
                                 Byte Age,
                                 String Country,
                                 String Biography);