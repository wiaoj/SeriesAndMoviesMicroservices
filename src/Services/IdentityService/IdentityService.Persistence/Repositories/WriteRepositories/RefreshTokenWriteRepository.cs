using BuildingBlocks.Core.Persistence.EntityFrameworkCore.Repositories;
using IdentityService.Application.Repositories.RefreshTokens;
using IdentityService.Domain.Users.Entities;
using IdentityService.Domain.Users.ValueObjects.RefreshTokenObjects;
using IdentityService.Persistence.Context;

namespace IdentityService.Persistence.Repositories.WriteRepositories;

public sealed class RefreshTokenWriteRepository : WriteRepository<RefreshToken, RefreshTokenId, IdentityDbContext>, IRefreshTokenWriteRepository {
    public RefreshTokenWriteRepository(IdentityDbContext context) : base(context) { }
}