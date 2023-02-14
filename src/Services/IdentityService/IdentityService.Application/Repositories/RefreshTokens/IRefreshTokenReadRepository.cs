using BuildingBlocks.Core.Abstractions.Repositories;
using IdentityService.Domain.Users.Entities;
using IdentityService.Domain.Users.ValueObjects.RefreshTokenObjects;

namespace IdentityService.Application.Repositories.RefreshTokens;

public interface IRefreshTokenReadRepository : IAsyncReadRepository<RefreshToken, RefreshTokenId> { }