using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using IdentityService.Application.Repositories;
using IdentityService.Domain.Users;
using IdentityService.Domain.Users.ValueObjects;
using MediatR;

namespace IdentityService.Application.Features.Users.Queries.GetByIdUserQuery;
public sealed class GetByIdUserQuery : IRequestCommand {
    public required UserId Id { get; set; }

    private class GetByIdUserQueryHandler : RequestCommandHandler<GetByIdUserQuery> {
        private readonly IUserReadRepository _userReadRepository;

        public GetByIdUserQueryHandler(IUserReadRepository userReadRepository) {
            _userReadRepository = userReadRepository;
        }

        protected override async Task<Unit> HandleCommandAsync(GetByIdUserQuery command, CancellationToken cancellationToken) {
            User? user = await _userReadRepository.GetByIdAsync(command.Id, cancellationToken);
            return default;
        }
    }
}