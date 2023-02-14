using BuildingBlocks.Core.Persistence.EntityFrameworkCore.Repositories;
using IdentityService.Application.Repositories;
using IdentityService.Domain.Users;
using IdentityService.Domain.Users.ValueObjects;
using IdentityService.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Persistence.Repositories.ReadRepositories;
public sealed class UserReadRepository : ReadRepository<User, UserId, IdentityDbContext>, IUserReadRepository {
    public UserReadRepository(IdentityDbContext context) : base(context) { }

    public async Task<User?> GetUserByEmailAsync(Email email) {
        return await Task.FromResult(await base.Table.SingleOrDefaultAsync(x => x.Email.Equals(email)));
    }
}