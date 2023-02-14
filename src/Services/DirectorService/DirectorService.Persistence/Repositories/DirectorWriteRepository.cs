using BuildingBlocks.Core.Persistence.EntityFrameworkCore.Repositories;
using DirectorService.Application.Services.Repositories;
using DirectorService.Domain;
using DirectorService.Domain.ValueObjects;
using DirectorService.Persistence.Context;

namespace DirectorService.Persistence.Repositories;
public sealed class DirectorWriteRepository : WriteRepository<Director, DirectorId, DirectorDbContext>, IDirectorWriteRepository {
    public DirectorWriteRepository(DirectorDbContext context) : base(context) { }
}