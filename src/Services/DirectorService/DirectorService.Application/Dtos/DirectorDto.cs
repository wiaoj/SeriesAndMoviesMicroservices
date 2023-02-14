namespace DirectorService.Application.Dtos;
public sealed record DirectorDto(Guid Id,
                                 String FirstName,
                                 String LastName,
                                 Byte Age,
                                 String Country,
                                 String Biography);