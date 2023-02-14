using IdentityService.Domain.Users.ValueObjects;

namespace IdentityService.Contracts;

public sealed record class DeleteUserRequest(Guid Id);