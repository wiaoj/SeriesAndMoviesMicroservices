using BuildingBlocks.Core.Persistence.EntityFrameworkCore.Repositories;
using IdentityService.Application.Repositories;
using IdentityService.Domain.Users;
using IdentityService.Domain.Users.ValueObjects;
using IdentityService.Persistence.Context;

namespace IdentityService.Persistence.Repositories.WriteRepositories;
public sealed class UserWriteRepository : WriteRepository<User, UserId, IdentityDbContext>, IUserWriteRepository {
    public UserWriteRepository(IdentityDbContext context) : base(context) { }
}