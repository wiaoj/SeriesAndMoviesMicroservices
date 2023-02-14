using BuildingBlocks.Core.Abstractions.Repositories;
using IdentityService.Domain.Users;
using IdentityService.Domain.Users.ValueObjects;

namespace IdentityService.Application.Repositories;

public interface IUserWriteRepository : IAsyncWriteRepository<User, UserId> { }