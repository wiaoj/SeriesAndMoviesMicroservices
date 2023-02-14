using BuildingBlocks.Core.Abstractions.Repositories;
using DirectorService.Domain;
using DirectorService.Domain.ValueObjects;

namespace DirectorService.Application.Services.Repositories;
public interface IDirectorReadRepository : IAsyncReadRepository<Director, DirectorId> { }