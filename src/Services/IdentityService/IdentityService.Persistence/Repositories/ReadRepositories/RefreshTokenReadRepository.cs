using BuildingBlocks.Core.Persistence.EntityFrameworkCore.Repositories;
using IdentityService.Application.Repositories.RefreshTokens;
using IdentityService.Domain.Users.Entities;
using IdentityService.Domain.Users.ValueObjects.RefreshTokenObjects;
using IdentityService.Persistence.Context;

namespace IdentityService.Persistence.Repositories.ReadRepositories;

public sealed class RefreshTokenReadRepository : ReadRepository<RefreshToken, RefreshTokenId, IdentityDbContext>, IRefreshTokenReadRepository {
    public RefreshTokenReadRepository(IdentityDbContext context) : base(context) { }
}