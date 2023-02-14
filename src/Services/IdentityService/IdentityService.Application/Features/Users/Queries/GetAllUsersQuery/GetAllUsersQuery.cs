using BuildingBlocks.Core.Abstractions.CQRS.Queries;
using BuildingBlocks.Core.Application.CQRS.Queries;
using IdentityService.Application.Repositories;
using IdentityService.Contracts;
using IdentityService.Domain.Users;

namespace IdentityService.Application.Features.Users.Queries.GetAllUsersQuery;
public sealed class GetAllUsersQuery : IRequestQuery<GetAllUsersResponse> {
    private class GetAllUsersQueryHandler : RequestQueryHandler<GetAllUsersQuery, GetAllUsersResponse> {
        private readonly IUserReadRepository _userReadRepository;

        public GetAllUsersQueryHandler(IUserReadRepository userReadRepository) {
            _userReadRepository = userReadRepository;
        }

        protected override async Task<GetAllUsersResponse> HandleQueryAsync(GetAllUsersQuery query, CancellationToken cancellationToken) {
            IQueryable<User> users = await _userReadRepository.GetAllAsync(cancellationToken);
            return new(users);
        }
    }
}