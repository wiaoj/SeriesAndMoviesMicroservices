using BuildingBlocks.Core.Persistence.EntityFrameworkCore.Repositories;
using DirectorService.Application.Services.Repositories;
using DirectorService.Domain;
using DirectorService.Domain.ValueObjects;
using DirectorService.Persistence.Context;

namespace DirectorService.Persistence.Repositories;
public sealed class DirectorReadRepository : ReadRepository<Director, DirectorId, DirectorDbContext>, IDirectorReadRepository {
    public DirectorReadRepository(DirectorDbContext context) : base(context) { }
}