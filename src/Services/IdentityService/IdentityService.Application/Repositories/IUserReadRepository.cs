using BuildingBlocks.Core.Abstractions.Repositories;
using IdentityService.Domain.Users;
using IdentityService.Domain.Users.ValueObjects;

namespace IdentityService.Application.Repositories;
public interface IUserReadRepository : IAsyncReadRepository<User, UserId> {
    public Task<User?> GetUserByEmailAsync(Email email);
}