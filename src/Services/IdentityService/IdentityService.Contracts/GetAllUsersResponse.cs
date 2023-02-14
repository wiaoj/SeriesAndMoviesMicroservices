using IdentityService.Domain.Users;

namespace IdentityService.Contracts;

public sealed record class GetAllUsersResponse(IEnumerable<User> Users);